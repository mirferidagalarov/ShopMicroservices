// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Shop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {

            new ApiResource("ResourceCatalog")
            {
                Scopes={"CatalogFullPermission","CatalogReadPermission"}
            },

            new ApiResource("ResourceDiscount")
            {
                Scopes={ "DiscountFullPermission", "DiscountReadPermission" }
            },

              new ApiResource("ResourceOrder")
            {
                Scopes={ "OrderFullPermission", "OrderReadPermission" }
            }
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
           new IdentityResources.OpenId(),
           new IdentityResources.Email(),
           new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full Authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading Authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Full Authority for discount operations"),
            new ApiScope("DiscountReadPermission","Reading Authority for discount operations"),
            new ApiScope("OrderFullPermission","Full Authority for order operations"),
            new ApiScope("OrderReadPermission","Reading Authority for order operations")
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                    ClientId="ShopVisitorId",
                    ClientName="Shop Visitor User",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets={new Secret("shopsecret".Sha256()) },
                    AllowedScopes={ "CatalogReadPermission" }
            },

              //Manager
            new Client
            {
                    ClientId="ShopManagerId",
                    ClientName="Shop Manager User",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets={new Secret("shopsecret".Sha256()) },
                    AllowedScopes={"CatalogFullPermission" }
            },

               //Admin
            new Client
            {
                    ClientId="ShopAdminId",
                    ClientName="Shop Admin User",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets={new Secret("shopsecret".Sha256()) },
                    AllowedScopes={"CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission",
                     
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,  
                    IdentityServerConstants.StandardScopes.Profile,
                    },
                    AccessTokenLifetime=600
            }
        };
    }
}