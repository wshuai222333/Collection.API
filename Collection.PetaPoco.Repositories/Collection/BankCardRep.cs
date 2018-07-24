using Collection.Entity.CollectionModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Collection.PetaPoco.Repositories.Collection {
    public class BankCardRep {
        public object Insert(BankCard model) {
            return CollectionDB.GetInstance().Insert(model);
        }
        public int Delete(int BankCardId) {
            return CollectionDB.GetInstance().Delete(BankCardId);
        }

        public List<BankCard> GetBankCardList(int UserAccountId) {
            string sql = string.Empty;
            string wherestr = string.Empty;
            wherestr += "and Title =@0";
            sql = string.Format(@"
SELECT  *
FROM    dbo.Problem
WHERE 1=1 {0}
ORDER BY MotifyTime DESC", wherestr);
            return CollectionDB.GetInstance().Fetch<BankCard>(sql, UserAccountId);
        }
    }
}
