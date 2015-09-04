using ProfiCraftsman.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfiCraftsman.Lib.Import
{
    public class MaterialImportResults
    {
        public MaterialImportResults()
        {
            CreatedMaterials = new List<Materials>();
            UpdatedMaterials = new List<Materials>();
            Errors = new List<ImportResultError>();
        }

        public ICollection<Materials> CreatedMaterials { get; private set; }
        public ICollection<Materials> UpdatedMaterials { get; private set; }

        public List<ImportResultError> Errors { get; private set; }

        public void AddError(int rowNumber, string description)
        {
            Errors.Add(new ImportResultError
            {
                Description = description,
                RowNumber = rowNumber
            });
        }
    }
}
