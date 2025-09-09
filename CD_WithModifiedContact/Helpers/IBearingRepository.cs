using CD_WithModifiedContact.Calculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
