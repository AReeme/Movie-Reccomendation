using Movie_Recommendation.Models;

namespace Movie_Recommendation.Interface
{
    public interface IDataAccessLayerSnack
    {
        IEnumerable<Snack> GetSnacks();
        void AddSnack(Snack snack);
        void RemoveSnack(int? id);
        void EditSnack(Snack s);
        Movie GetSnack(int? id);
    }
}
