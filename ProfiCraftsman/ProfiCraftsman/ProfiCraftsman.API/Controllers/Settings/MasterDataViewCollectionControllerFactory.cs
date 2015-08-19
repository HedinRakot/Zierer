using CoreBase.Controllers;
using ProfiCraftsman.API.Controllers;
using ProfiCraftsman.Contracts.Entities;
using ProfiCraftsman.Contracts.Managers;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace ProfiCraftsman.API.Controllers
{
    /// <summary>
    ///     MasterDataViewCollectionControllerFactory class
    /// </summary>
    public class MasterDataViewCollectionControllerFactory: ViewCollectionControllerFactoryBase
    {
        public void GetViewCollections(IDependencyResolver resolver, CollectionTypesModel model, Dictionary<string, IEnumerable<object>> result)
        {
            if (model.Materials)
            	result.Add("Materials", GetViewCollection<Materials, int, IMaterialsManager>(
            		(IMaterialsManager)resolver.GetService(typeof(IMaterialsManager))));

            if (model.Autos)
            	result.Add("Autos", GetViewCollection<Autos, int, IAutosManager>(
            		(IAutosManager)resolver.GetService(typeof(IAutosManager))));

            if (model.Permission)
            	result.Add("Permission", GetViewCollection<Permission, int, IPermissionManager>(
            		(IPermissionManager)resolver.GetService(typeof(IPermissionManager))));

            if (model.JobPositions)
            	result.Add("JobPositions", GetViewCollection<JobPositions, int, IJobPositionsManager>(
            		(IJobPositionsManager)resolver.GetService(typeof(IJobPositionsManager))));

            if (model.Role)
            	result.Add("Role", GetViewCollection<Role, int, IRoleManager>(
            		(IRoleManager)resolver.GetService(typeof(IRoleManager))));

            if (model.Employees)
            	result.Add("Employees", GetViewCollection<Employees, int, IEmployeesManager>(
            		(IEmployeesManager)resolver.GetService(typeof(IEmployeesManager))));

            if (model.TransportProducts)
            	result.Add("TransportProducts", GetViewCollection<TransportProducts, int, ITransportProductsManager>(
            		(ITransportProductsManager)resolver.GetService(typeof(ITransportProductsManager))));

            if (model.ProductTypes)
            	result.Add("ProductTypes", GetViewCollection<ProductTypes, int, IProductTypesManager>(
            		(IProductTypesManager)resolver.GetService(typeof(IProductTypesManager))));

        }
    }
}
