using Movie_Recommendation.Models;

namespace Movie_Recommendation.Interface
{
    public interface IDataAccessLayerSnack
    {
        IEnumerable<Snack> GetSnacks();
        Snack GetSnack(int? id);
    }
}
