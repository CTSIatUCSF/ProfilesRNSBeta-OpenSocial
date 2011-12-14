using Microsoft.Practices.EnterpriseLibrary.Caching;

namespace Connects.Profiles.BusinessLogic
{
    public class BaseBL
    {
        protected ICacheManager primitivesCache;

        public BaseBL()
        {
            primitivesCache = CacheFactory.GetCacheManager();
        }

    }
}
