using System.Data.Entity.SqlServer;

namespace Breed.Business
{
    internal static class MissingDllHack
    {
        private static SqlProviderServices instance = SqlProviderServices.Instance;
    }
}
