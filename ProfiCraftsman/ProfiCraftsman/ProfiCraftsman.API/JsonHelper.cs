﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Dependencies;
using ProfiCraftsman.API.Models;
using ProfiCraftsman.Contracts.Managers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using CoreBase.Models;
using CoreBase;

namespace ProfiCraftsman.API
{
    public static partial class JsonHelper
    {
        //TODO Need to be removed
        public static string GetCurrentUserJson(IDependencyResolver resolver)
        {
            var result = new LoggedUserModel();
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                result.IsAuthenticated = false;
            else
            {
                var userManager = resolver.GetService<IUserManager>();
                var permissionsRspManager = resolver.GetService<IRolePermissionRspManager>();
                var permissionsManager = resolver.GetService<IPermissionManager>();

                var user = userManager.GetByLogin(HttpContext.Current.User.Identity.Name);

                result.IsAuthenticated = true;
                result.Name = user.Name;
                var permissionsQuery = from permissionRsp in permissionsRspManager.GetEntities()
                                       join permission in permissionsManager.GetEntities() on permissionRsp.PermissionId equals permission.Id
                                       where permissionRsp.RoleId == user.RoleId && !permissionRsp.DeleteDate.HasValue
                                       select permission.Name;
                result.Permissions = permissionsQuery.ToList();
            }

            return JsonConvert.SerializeObject(result, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        //TODO Need to be removed
        public static void SetCurrentCulture()
        {
        }

        private static readonly Lazy<Dictionary<string, TableMapping>> TableMappings = new Lazy<Dictionary<string, TableMapping>>(LoadTableMappings, LazyThreadSafetyMode.ExecutionAndPublication);
        private static Dictionary<string, TableMapping> LoadTableMappings()
        {
            var mappings = new Dictionary<string, TableMapping>();

            ProfiCraftsmanTableMappings(mappings);

            if (mappings.ContainsKey("SYS_TABLES"))
            {
                mappings["SYS_TABLES"].Add("TABLE_DESCRIPTION", "tableDescription");
            }

            return mappings;
        }

        //TODO Need to be removed
        public static string GetSystemTablesJson(IDependencyResolver resolver)
        {
            var tableNames = new Dictionary<string, SysTableWithColumnsModel>();
            tableNames.Add("ProductMaterialRsp", new SysTableWithColumnsModel()
            {
                ReadOnlyColumns = new List<string>() { "materialId" },
                EditMode = 3
            });

            var result = new GlobalSysTableModel
            {
                TableNames = tableNames
            };

            return JsonConvert.SerializeObject(result, new JsonSerializerSettings { });
        }
    }
}
