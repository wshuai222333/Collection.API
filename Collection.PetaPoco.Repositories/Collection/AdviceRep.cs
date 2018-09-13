using Collection.Entity.CollectionModel;
using PetaPoco.NetCore;

namespace Collection.PetaPoco.Repositories.Collection {
    public class AdviceRep
    {
        public object Insert(Advice model) {
            return CollectionDB.GetInstance().Insert(model);
        }
        public Page<Advice> GetAdviceList(int pageindex, int pagesize) {
            string sql = string.Empty;
            string wherestr = string.Empty;
            
            sql = string.Format(@"
SELECT  *
FROM    dbo.Advice
WHERE 1=1 {0}
ORDER BY CreateTime DESC", wherestr);
            return CollectionDB.GetInstance().Page<Advice>(pageindex, pagesize, sql);
        }
    }
}
