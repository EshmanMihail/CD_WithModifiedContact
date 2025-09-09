using System;
using System.Xml.Linq;

namespace CD_WithModifiedContact.Calculation
{
    public static class XmlWriterHelper
    {
        public static void SaveInitialParameterToXml(InitialParameters parameters, string filePath)
        {
            XDocument xmlDoc = XDocument.Load(filePath) ??
                throw new InvalidOperationException("Файл по пути:" + filePath + " отсутствует");

            var root = xmlDoc.Element("Bearings") ??
                throw new InvalidOperationException("Некорректный формат XML: отсутствует корневой элемент 'Bearings'.");

            var initialParametersElement = new XElement("InitialParameters",
                new XAttribute("Id", parameters.Id),
                new XElement("Name", parameters.Name),
                new XElement("AccuracyClass", parameters.AccuracyClass),
                new XElement("D", parameters.D.ToString()),
                new XElement("d", parameters.d.ToString()),
                new XElement("B", parameters.B.ToString()),
                new XElement("r_s_min", parameters.r_s_min.ToString()),
                new XElement("Gr1", parameters.Gr1.ToString()),
                new XElement("Gr2", parameters.Gr2.ToString()),
                new XElement("lambda_B", parameters.lambda_B.ToString()),
                new XElement("lambda_H", parameters.lambda_H.ToString()),
                new XElement("X1", parameters.X1.ToString()),
                new XElement("X2", parameters.X2.ToString()),
                new XElement("Bm", parameters.Bm.ToString()),
                new XElement("k", parameters.k)
            );

            root.Add(initialParametersElement);

            xmlDoc.Save(filePath);
        }
    }
}