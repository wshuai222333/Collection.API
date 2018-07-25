using Collection.Entity.CollectionModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            wherestr += "and UserAccountId =@0";
            sql = string.Format(@"
SELECT  *
FROM    dbo.BankCard
WHERE 1=1 {0}
ORDER BY CreateTime DESC", wherestr);
            return CollectionDB.GetInstance().Fetch<BankCard>(sql, UserAccountId);
        }
        public BankCard GetBankCard(BankCard model) {
            string sql = string.Empty;
            string wherestr = string.Empty;
            wherestr += "and CardId =@0";
            wherestr += "and UserAccountId =@1";
            sql = string.Format(@"
SELECT  *
FROM    dbo.BankCard
WHERE 1=1 {0}
ORDER BY CreateTime DESC", wherestr);
            return CollectionDB.GetInstance().Fetch<BankCard>(sql,model.CardId,model.UserAccountId).FirstOrDefault();
        }
    }
}
