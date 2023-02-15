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
            return db.Snacks.OrderBy(m => m.Name).ToList();
        }
    }
}
