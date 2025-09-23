using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;

namespace CD_WithModifiedContact.Calculation.OuterRingParameters
{
    public partial class OuterRingParameters
    {
        private List<FormulaDetails> resultOfCalculations = new List<FormulaDetails>();

        public List<FormulaDetails> GetFormulasInfo()
        {
            return resultOfCalculations;
        }
    }
}
