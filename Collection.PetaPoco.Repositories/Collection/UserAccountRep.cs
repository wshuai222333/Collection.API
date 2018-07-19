using Collection.Entity.CollectionModel;
using PetaPoco.NetCore;

namespace Collection.PetaPoco.Repositories.Collection {
    public class UserAccountRep
    {
        public object Insert(UserAccount model) {
            return  CollectionDB.GetInstance().Insert(model);
        }

        public int Update(UserAccount model) {
            return CollectionDB.GetInstance().Update(model);
        }

        public int UpdateMemberlevel(int UserAccountId,int Memberlevel) {
            string wherestr = string.Empty;
            wherestr = " AND UserAccountId=" + UserAccountId;
            string sql = string.Format("SET Memberlevel={0} WHERE 1=1 {1}", Memberlevel, wherestr);
            return CollectionDB.GetInstance().Update<UserAccount>(sql);
        }
        public UserAccount GetUserAccount(UserAccount model) {
            #region sql
            string wherestr = string.Empty;
            if (!string.IsNullOrEmpty(model.UserName)) {
                wherestr += " AND (UserName = @0 OR Phone = @0)";
            }
            if (!string.IsNullOrEmpty(model.UserPwd)) {
                wherestr += " AND UserPwd = @1";
            }
            string sql = string.Format(@"
            SELECT  *
            FROM    dbo.UserAccount
            WHERE   1 = 1
            {0}
            ", wherestr);
            #endregion
            return CollectionDB.GetInstance().SingleOrDefault<UserAccount>(sql,
                              model.UserName, model.UserPwd);
        }
        public Page<UserAccount> GetUserList(int pageindex, int pagesize,string UserName,string Phone) {
            string sql = string.Empty;
            string wherestr = string.Empty;
            if (!string.IsNullOrWhiteSpace(UserName)) {
                wherestr += " and UserName =@0 ";
            }
            if (!string.IsNullOrWhiteSpace(Phone)) {
                wherestr += " and Phone =@1 ";
            }

            sql = string.Format(@"
SELECT  *
FROM    dbo.UserAccount
WHERE 1=1 {0}
ORDER BY CreateTime DESC", wherestr);
            return CollectionDB.GetInstance().Page<UserAccount>(pageindex, pagesize, sql, UserName, Phone);
        }
    }
}
