using Collection.DDD.IRepositories;
using Collection.Entity.CollectionModels;
using Collection.Entity.EFRepositories;

namespace Collection.Entity {
    /// <summary>
    /// 数据库连接
    /// </summary>
    public class DbBase {
        #region
        protected readonly CollectionContext collectionContext;
        public readonly IExtensionRepository<UserAccount> userAccount;


        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        public DbBase() {
            #region
            var collectionContext = new CollectionContext();
            userAccount = new CollectionEfRepository<UserAccount>(collectionContext);
            #endregion
        }
    }
}

