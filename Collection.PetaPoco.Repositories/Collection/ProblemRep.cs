using Collection.Entity.CollectionModel;
using PetaPoco.NetCore;

namespace Collection.PetaPoco.Repositories.Collection {
    public class ProblemRep
    {
        public object Insert(Problem model) {
            return CollectionDB.GetInstance().Insert(model);
        }
        public int Update(Problem model) {
            return CollectionDB.GetInstance().Update(model);
        }
        public int Delete(Problem model) {
            return CollectionDB.GetInstance().Delete(model);
        }


        public Problem GetProblem(Problem model) {
            string sql = string.Empty;
            string wherestr = string.Empty;
            
                wherestr += "and ProblemId =@0";
            
            sql = string.Format(@"
SELECT  *
FROM    dbo.Problem
WHERE 1=1 {0}
ORDER BY MotifyTime DESC", wherestr);
            return CollectionDB.GetInstance().SingleOrDefault<Problem>(sql, model.ProblemId);
        }
        public Page<Problem> GetProblemList(int pageindex, int pagesize, string Title) {
            string sql = string.Empty;
            string wherestr = string.Empty;
            if (!string.IsNullOrWhiteSpace(Title)) {
                wherestr += "and Title =@0";
            }
            sql = string.Format(@"
SELECT  *
FROM    dbo.Problem
WHERE 1=1 {0}
ORDER BY MotifyTime DESC", wherestr);
            return CollectionDB.GetInstance().Page<Problem>(pageindex, pagesize, sql, Title);
        }

        public int UpdateProblem(Problem model) {
            string sql = string.Empty;
            sql = "SET Title=@0,Body=@1,MotifyTime=@2 WHERE ProblemId = @3";
            return CollectionDB.GetInstance().Update<Problem>(sql, model.Title,model.Body,model.MotifyTime,model.ProblemId);
        }
    }
}
