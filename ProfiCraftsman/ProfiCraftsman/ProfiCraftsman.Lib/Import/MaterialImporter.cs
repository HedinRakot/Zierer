using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Enums;
using ProfiCraftsman.Contracts.Managers;
using ProfiCraftsman.Lib.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using EntityFramework.BulkInsert.Extensions;
using System.Data.Entity;

namespace ProfiCraftsman.Lib.Import
{
    public class MaterialImporter
    {
        public MaterialImporter(IMaterialsManager materialmanager)
        {
            this.MaterialManager = materialmanager;
        }

        private IMaterialsManager MaterialManager { get; set; }

        public async Task<MaterialImportResults> ImportFromStream(Stream stream)
        {
            var result = new MaterialImportResults();
            int rowIndex = 0;
            int innerRowIndex = 0;
            try
            {
                stream.Position = 0;
                var materials = MaterialManager.GetEntities().ToList();
                using (StreamReader sr = new StreamReader(stream))
                {
                    var currentMaterialNumber = String.Empty;
                    var fullText = String.Empty;
                    var needProcess = false;
                    while (sr.Peek() >= 0)
                    {
                        rowIndex++;

                        var line = sr.ReadLine();
                        var parts = line.Split(';');

                        if(parts.Length > 3) //TODO
                        {
                            if(String.IsNullOrEmpty(currentMaterialNumber) || currentMaterialNumber == parts[2])
                            {
                                fullText += line;
                                currentMaterialNumber = parts[2];
                            }
                            else
                            {
                                needProcess = true;
                            }
                        }
                        else
                        {
                            needProcess = true;
                        }

                        if (needProcess)
                        {
                            if (!String.IsNullOrEmpty(currentMaterialNumber))
                            {
                                var material = materials.FirstOrDefault(o => o.Number == currentMaterialNumber);

                                if (material == null)
                                {
                                    material = new Materials();
                                    material.Number = currentMaterialNumber;

                                    var fullTextParts = fullText.Split(';');
                                    if (fullTextParts.Length > 6)
                                    {
                                        material.Name = fullTextParts[6];
                                    }

                                    material.CreateDate = DateTime.Now;
                                    material.ChangeDate = DateTime.Now;


                                    //todo
                                    material.MaterialAmountType = (int)MaterialAmountTypes.Item;
                                    //todo default
                                    material.ProceedsAccountId = 1;

                                    result.CreatedMaterials.Add(material);
                                }
                                else
                                {
                                    result.UpdatedMaterials.Add(material);
                                }

                                fullText = line;
                                if (parts.Length >= 2)
                                {
                                    currentMaterialNumber = parts[2];
                                }
                            }

                            needProcess = false;
                        }
                    }
                }

                //foreach (var material in result.CreatedMaterials)
                //    MaterialManager.AddEntity(material);
                
                //await MaterialManager.SaveChangesAsynchron();

                using (var transactionScope = new TransactionScope())
                {
                    (MaterialManager.DataContext as DbContext).BulkInsert(result.CreatedMaterials);
                    
                    transactionScope.Complete();
                }
            }
            catch (Exception e)
            {
                result.AddError(Math.Max(rowIndex, innerRowIndex), String.Format("Import abgebrochen: \"{0}\"", e.Message));
            }

            return result;
        }        
    }
}
