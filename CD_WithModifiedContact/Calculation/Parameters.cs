using System;
using System.Collections.Generic;
using CD_WithModifiedContact.Helpers;
using CD_WithModifiedContact.Calculation.LayoutParameters;

namespace CD_WithModifiedContact.Calculation
{
    public interface Parameters
    {
        event Action StopCalculation;

        void MessageHendler(ShowMessage messageMethod);

        List<FormulaDetails> GetFormulasInfo();

        void ClearFormulasInfo();
    }
}
