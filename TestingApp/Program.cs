using CD_WithModifiedContact.Calculation;
using CD_WithModifiedContact.Calculation.InnerRingParameters;
using CD_WithModifiedContact.Calculation.LayoutParameters;
using CD_WithModifiedContact.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Math.Round(245.95284, MidpointRounding.AwayFromZero).ToString());
        }
    }
}
