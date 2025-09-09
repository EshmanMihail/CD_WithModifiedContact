
using System;

namespace CD_WithModifiedContact.Calculation
{
    public class InitialParameters : Parameters
    {
        public string Id { get; private set; }
        public string Name { get; set; }

        public int AccuracyClass { get; set; }

        public decimal D { get; set; }

        public decimal d { get; set; }

        public decimal B { get; set; }

        public decimal r_s_min { get; set; }

        public decimal Gr1 { get; set; }

        public decimal Gr2 { get; set; }

        public decimal lambda_B { get; set; }

        public decimal lambda_H { get; set; }

        public decimal X1 { get; set; }

        public decimal X2 { get; set; }

        public decimal Bm { get; set; }

        public string k { get; set; }

        public InitialParameters(string Name, int AccuracyClass, decimal D, decimal d, decimal B,
            decimal r_s_min, decimal Gr1, decimal Gr2, decimal lambda_B, decimal X1, decimal X2,
            decimal Bm, string k)
        {
            Id = Guid.NewGuid().ToString();
            this.Name = Name;
            this.AccuracyClass = AccuracyClass;
            this.D = D;
            this.d = d;
            this.B = B;
            this.r_s_min = r_s_min;
            this.Gr1 = Gr1;
            this.Gr2 = Gr2;
            this.lambda_B = lambda_B;
            this.lambda_H = lambda_B;
            this.X1 = X1;
            this.X2 = X2;
            this.Bm = Bm;
            this.k = k;
        }

        public InitialParameters(string id, string name, int accuracyClass, decimal D, decimal d, decimal B, decimal r_s_min,
                                 decimal gr1, decimal gr2, decimal lambda_B, decimal x1, decimal x2, decimal bm, string k)
            : this(name, accuracyClass, D, d, B, r_s_min, gr1, gr2, lambda_B, x1, x2, bm, k)
        {
            Id = id;
        }
    }
}
