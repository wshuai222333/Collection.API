using Collection.DDD.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.Entity.CollectionModels
{
    public class CollectionContext : DbContext {
        public virtual DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(JsonConfig.JsonRead("collectioConnection"));
            }
        }
    }
}
