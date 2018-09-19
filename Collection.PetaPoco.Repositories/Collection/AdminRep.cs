using Collection.Entity.CollectionModel;

namespace Collection.PetaPoco.Repositories.Collection {
    public class AdminRep {
        public Admin GetAdminLogin(Admin model) {
            #region sql
            string wherestr = string.Empty;
            if (!string.IsNullOrEmpty(model.UserName)) {
                wherestr += " AND UserName = @0";
            }
            if (!string.IsNullOrEmpty(model.UserPwd)) {
                wherestr += " AND UserPwd = @1 ";
            }
            string sql = string.Format(@"
            SELECT  *
            FROM    dbo.Admin
            WHERE   1 = 1
            {0}
            ", wherestr);
            #endregion
            return CollectionDB.GetInstance().SingleOrDefault<Admin>(sql,
                              model.UserName, model.UserPwd);
        }
    }
}
