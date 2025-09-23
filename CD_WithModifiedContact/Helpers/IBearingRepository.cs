using System.Collections.Generic;
using CD_WithModifiedContact.Calculation;

namespace CD_WithModifiedContact.Helpers
{
    public interface IBearingRepository
    {
        List<InitialParameters> GetAll();
        void Add(InitialParameters parameters);
        void Update(InitialParameters parameters);
        void Delete(string id);
    }
}
