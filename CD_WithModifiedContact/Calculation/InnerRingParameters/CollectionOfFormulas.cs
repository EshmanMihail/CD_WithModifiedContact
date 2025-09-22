using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;

namespace CD_WithModifiedContact.Calculation.InnerRingParameters
{
    public partial class InnerRingParameters
    {
        private List<FormulaDetails> resultOfCalculations = new List<FormulaDetails>();

        public List<FormulaDetails> GetFormulasInfo()
        {
            return resultOfCalculations;
        }
    }
}
