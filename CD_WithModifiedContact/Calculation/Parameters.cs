using CD_WithModifiedContact.Calculation.LayoutParameters;
using CD_WithModifiedContact.Helpers;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;

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
