using Collection.DDD.Domain;
using Collection.Entity.CollectionModels;
using Collection.Repositories.EF;
using Microsoft.EntityFrameworkCore;

namespace Collection.Entity.EFRepositories {
    public class CollectionEfRepository<T> : EFRepository<T> where T : class, IEntity {
        public CollectionEfRepository(DbContext db)
           : base(db ?? new CollectionContext()) {
        }
    }
}
