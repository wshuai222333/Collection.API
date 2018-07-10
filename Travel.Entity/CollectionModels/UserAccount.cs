using Collection.DDD.Domain;
using System;

namespace Collection.Entity.CollectionModels {
    public class UserAccount : EntityBase {
        public int UserAccountId { get; set; }

        public string UserName { get; set; }

        public string UserPwd { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ModifyTime { get; set; }

        public int Memberlevel { get; set; }

        public string Phone { get; set; }
    }
}
