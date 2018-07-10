using Collection.Entity.CollectionModel;

namespace Collection.PetaPoco.Repositories.Collection {
    public class AdviceRep
    {
        public object Insert(Advice model) {
            return CollectionDB.GetInstance().Insert(model);
        }
    }
}
