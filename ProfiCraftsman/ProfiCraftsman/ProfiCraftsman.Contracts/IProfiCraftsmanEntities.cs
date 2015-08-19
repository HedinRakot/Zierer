﻿








using ProfiCraftsman.Contracts.Entities;
using System.Linq;

namespace ProfiCraftsman.Contracts
{
    /// <summary>
    ///     Interface for ProfiCraftsman context
    /// </summary>
    public partial interface IProfiCraftsmanEntities
    {
        /// <summary>
        ///     Set of <see cref="Orders"/> entities from table dbo.Orders
        /// </summary>
        IQueryable<Orders> Orders{get;}
        /// <summary>
        ///     Set of <see cref="Positions"/> entities from table dbo.Positions
        /// </summary>
        IQueryable<Positions> Positions{get;}
        /// <summary>
        ///     Set of <see cref="Invoices"/> entities from table dbo.Invoices
        /// </summary>
        IQueryable<Invoices> Invoices{get;}
        /// <summary>
        ///     Set of <see cref="InvoicePositions"/> entities from table dbo.InvoicePositions
        /// </summary>
        IQueryable<InvoicePositions> InvoicePositions{get;}
        /// <summary>
        ///     Set of <see cref="Materials"/> entities from table dbo.Materials
        /// </summary>
        IQueryable<Materials> Materials{get;}
        /// <summary>
        ///     Set of <see cref="PositionMaterialRsp"/> entities from table dbo.Position_Material_Rsp
        /// </summary>
        IQueryable<PositionMaterialRsp> PositionMaterialRsp{get;}
        /// <summary>
        ///     Set of <see cref="ProductMaterialRsp"/> entities from table dbo.Product_Material_Rsp
        /// </summary>
        IQueryable<ProductMaterialRsp> ProductMaterialRsp{get;}
        /// <summary>
        ///     Set of <see cref="Autos"/> entities from table dbo.Autos
        /// </summary>
        IQueryable<Autos> Autos{get;}
        /// <summary>
        ///     Set of <see cref="Permission"/> entities from table dbo.Permission
        /// </summary>
        IQueryable<Permission> Permission{get;}
        /// <summary>
        ///     Set of <see cref="JobPositions"/> entities from table dbo.JobPositions
        /// </summary>
        IQueryable<JobPositions> JobPositions{get;}
        /// <summary>
        ///     Set of <see cref="Role"/> entities from table dbo.Role
        /// </summary>
        IQueryable<Role> Role{get;}
        /// <summary>
        ///     Set of <see cref="Employees"/> entities from table dbo.Employees
        /// </summary>
        IQueryable<Employees> Employees{get;}
        /// <summary>
        ///     Set of <see cref="RolePermissionRsp"/> entities from table dbo.Role_Permission_Rsp
        /// </summary>
        IQueryable<RolePermissionRsp> RolePermissionRsp{get;}
        /// <summary>
        ///     Set of <see cref="InvoiceStornos"/> entities from table dbo.InvoiceStornos
        /// </summary>
        IQueryable<InvoiceStornos> InvoiceStornos{get;}
        /// <summary>
        ///     Set of <see cref="User"/> entities from table dbo.User
        /// </summary>
        IQueryable<User> User{get;}
        /// <summary>
        ///     Set of <see cref="AdditionalCosts"/> entities from table dbo.AdditionalCosts
        /// </summary>
        IQueryable<AdditionalCosts> AdditionalCosts{get;}
        /// <summary>
        ///     Set of <see cref="Taxes"/> entities from table dbo.Taxes
        /// </summary>
        IQueryable<Taxes> Taxes{get;}
        /// <summary>
        ///     Set of <see cref="TransportProducts"/> entities from table dbo.TransportProducts
        /// </summary>
        IQueryable<TransportProducts> TransportProducts{get;}
        /// <summary>
        ///     Set of <see cref="Customers"/> entities from table dbo.Customers
        /// </summary>
        IQueryable<Customers> Customers{get;}
        /// <summary>
        ///     Set of <see cref="CommunicationPartners"/> entities from table dbo.CommunicationPartners
        /// </summary>
        IQueryable<CommunicationPartners> CommunicationPartners{get;}
        /// <summary>
        ///     Set of <see cref="TransportOrders"/> entities from table dbo.TransportOrders
        /// </summary>
        IQueryable<TransportOrders> TransportOrders{get;}
        /// <summary>
        ///     Set of <see cref="ProductTypes"/> entities from table dbo.ProductTypes
        /// </summary>
        IQueryable<ProductTypes> ProductTypes{get;}
        /// <summary>
        ///     Set of <see cref="TransportPositions"/> entities from table dbo.TransportPositions
        /// </summary>
        IQueryable<TransportPositions> TransportPositions{get;}
        /// <summary>
        ///     Set of <see cref="Products"/> entities from table dbo.Products
        /// </summary>
        IQueryable<Products> Products{get;}
    }
}
