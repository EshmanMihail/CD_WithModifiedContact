using CD_WithModifiedContact.Calculation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CD_WithModifiedContact.Helpers
{
    public class XmlReaderHelper
    {
        public static List<InitialParameters> LoadInitialParametersFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Файл не найден: {filePath}");
            }

            List<InitialParameters> parametersList = new List<InitialParameters>();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlElement xRoot = xmlDocument.DocumentElement ??
                throw new InvalidOperationException(
                    "Некорректный формат XML: отсутствует корневой элемент.");

            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    string id = xnode.GetAttribute("Id");
                    string name = "";
                    int accClass = 0;
                    decimal D = 0, d = 0, B = 0;
                    decimal rsmin = 0, Gr1 = 0, Gr2 = 0;
                    decimal lambda_B = 0, X1 = 0, X2 = 0;
                    decimal bm = 0;
                    string k = "";

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "Name") name = childnode.InnerText;
                        if (childnode.Name == "AccuracyClass") accClass = int.Parse(childnode.InnerText);
                        if (childnode.Name == "D") D = decimal.Parse(childnode.InnerText);
                        if (childnode.Name == "d") d = decimal.Parse(childnode.InnerText);
                        if (childnode.Name == "B") B = decimal.Parse(childnode.InnerText);
                        if (childnode.Name == "r_s_min") rsmin = decimal.Parse(childnode.InnerText);
                        if (childnode.Name == "Gr1") Gr1 = decimal.Parse(childnode.InnerText);
                        if (childnode.Name == "Gr2") Gr2 = decimal.Parse(childnode.InnerText);
                        if (childnode.Name == "lambda_B") lambda_B = decimal.Parse(childnode.InnerText);
                        if (childnode.Name == "X1") X1 = decimal.Parse(childnode.InnerText);
                        if (childnode.Name == "X2") X2 = decimal.Parse(childnode.InnerText);
                        if (childnode.Name == "Bm") bm = decimal.Parse(childnode.InnerText);
                        if (childnode.Name == "k") k = childnode.InnerText;
                    }

                    parametersList.Add(new InitialParameters(id, name, accClass, D, d, B, rsmin, Gr1, Gr2, lambda_B, X1, X2, bm, k));
                }
            }
            return parametersList;
        }
    }
}