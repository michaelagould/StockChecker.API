using IdentityServer4.Models;
using IdentityServer4.Test;

namespace StockChecker.IdentityServer.Helpers
{
    public static class IdentityServerHelper
    {
        internal static IEnumerable<Client> GetClients()
        {
            var clients = new List<Client>
            {
                new Client
                {
                    ClientId = "StockChecker",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "StockCheckerApi" }
                }
            };
            return clients;
        }

        internal static List<TestUser> GetUsers()
        {
            var users = new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "Lucy",
                    Password = "password123"
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "Morris",
                    Password = "password123"
                },
                new TestUser
                {
                    SubjectId = "3",
                    Username = "Graham",
                    Password = "password123"
                }
            };
            return users;
        }

        internal static IEnumerable<ApiScope> GetApiResources()
        {
            var resources = new List<ApiScope>
            {
                new ApiScope("StockCheckerApi", "Stock Checker API")
            };
            return resources;
        }
    }
}
