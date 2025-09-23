namespace CD_WithModifiedContact.Calculation.RollerParameters
{
    public class R0smax
    {
        public static void GetValue(decimal r0smin, out decimal r0smax)
        {
            r0smax = 0;
            if (r0smin == 0.3m) r0smax = r0smin + 0.5m;
            else if (r0smin == 0.5m) r0smax = r0smin + 0.7m;
            else if (r0smin == 0.7m) r0smax = r0smin + 0.8m;
            else if (r0smin == 0.9m) r0smax = r0smin + 0.8m;
            else if (r0smin == 1.1m) r0smax = r0smin + 1.0m;
        }
    }
}
