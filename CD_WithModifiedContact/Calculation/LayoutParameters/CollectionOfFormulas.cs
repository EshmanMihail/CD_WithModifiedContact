using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CD_WithModifiedContact.Calculation.LayoutParameters
{
    public partial class LayoutParameters
    {
        private List<FormulaDetails> resultOfCalculations = new List<FormulaDetails>();

        public List<FormulaDetails> GetFormulasInfo()
        {
            return resultOfCalculations;
        }

        public void AddFormula(FormulaDetails formula)
        {
            resultOfCalculations.Add(formula);
        }
    }
}
