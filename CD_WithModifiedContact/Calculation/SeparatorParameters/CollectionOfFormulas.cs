using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;

namespace CD_WithModifiedContact.Calculation.SeparatorParameters
{
    public partial class SeparatorParameters
    {
        private List<FormulaDetails> resultOfCalculations = new List<FormulaDetails>();

        public List<FormulaDetails> GetFormulasInfo()
        {
            return resultOfCalculations;
        }
    }
}
