using CD_WithModifiedContact.Helpers;
using System.Collections.Generic;

namespace CD_WithModifiedContact.Calculation.RollerParameters
{
    public partial class RollerParameters
    {
        private List<FormulaDetails> resultOfCalculations = new List<FormulaDetails>();

        public List<FormulaDetails> GetFormulasInfo()
        {
            return resultOfCalculations;
        }
    }
}
