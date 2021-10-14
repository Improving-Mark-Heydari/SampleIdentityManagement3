using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System.Collections.Generic;
using static IdentityModel.OidcConstants;

using static Duende.IdentityServer.IdentityServerConstants;
using Duende.IdentityServer.Services;
using Duende.IdentityServer.Stores;
using Duende.IdentityServer.Events;
using Duende.IdentityServer.Extensions;

namespace GB.IdentityServer
{
	public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "gb.m2m",
                    ClientName = "GB",

                    AllowedGrantTypes = Duende.IdentityServer.Models.GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secretgbkey".Sha256()) },

                    AllowedScopes = { IdentityServerConstants.LocalApi.ScopeName }
                },

                new Client
                {
                    ClientId = "gb.oidc",
                    ClientName = "GB",
                    AllowedGrantTypes = Duende.IdentityServer.Models.GrantTypes.Implicit,
                    
                    RedirectUris = {
                        "https://localhost:5009/assets/signin-callback.html",
                        "https://localhost:5009/assets/silent-callback.html",
                    },
                    PostLogoutRedirectUris = {
                        "https://localhost:5009/signout-oidc",
                        "https://localhost:5009/signout-oidc"
                    },
                    AllowedCorsOrigins = {
                        "https://localhost:5009",
                    },
                    
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId },
                    AllowAccessTokensViaBrowser = true,
                },

                new Client
                {
                    ClientId = "interactive.confidential.hybrid",
                    ClientName = "Sample",
                    AllowedGrantTypes = Duende.IdentityServer.Models.GrantTypes.Hybrid,
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    RedirectUris = {
                        "https://localhost:44306/",
                    },
                    PostLogoutRedirectUris = {
                        "https://localhost:44306/",
                    },
                    AllowedCorsOrigins = {
                        "https://localhost:44306",
                    },

                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile },
                    AllowAccessTokensViaBrowser = true,
                    RequirePkce = false, // false when using hybrid flow
                },
            };
    }
}