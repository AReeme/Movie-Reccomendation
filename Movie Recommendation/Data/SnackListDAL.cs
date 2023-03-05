using Movie_Recommendation.Interface;
using Movie_Recommendation.Models;

namespace Movie_Recommendation.Data
{
    public class SnackListDAL : IDataAccessLayerSnack
    {
        private AppDbContext db;
        public SnackListDAL(AppDbContext indb)
        {
            db = indb;
        }

        public Snack GetSnack(int? id)
        {
            return db.Snacks.Where(m => m.Id == id).FirstOrDefault();
        }

        public IEnumerable<Snack> GetSnacks()
        {
            return db.Snacks;
        }

        public IEnumerable<Snack> FilterSnacks(string type, string isGlutenFree)
        {
            var snacks = GetSnacks();
            if (!string.IsNullOrEmpty(type)) snacks = snacks.Where(x => x.Type.ToLower().Contains(type.ToLower())); 
            if (!string.IsNullOrEmpty(isGlutenFree)) snacks = snacks.Where(x => x.isGlutenFree.ToLower().Contains(isGlutenFree.ToLower()));

            return snacks;
        }
    }
}
