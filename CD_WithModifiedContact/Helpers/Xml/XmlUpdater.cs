using System;
using System.Linq;
using System.Xml.Linq;
using CD_WithModifiedContact.Calculation;

namespace CD_WithModifiedContact.Helpers.Xml
{
    public class XmlUpdater
    {
        /// <summary>
        /// Обновляет элемент в XML-файле по его Id.
        /// </summary>
        /// <param name="filePath">Путь к XML-файлу.</param>
        /// <param name="id">Id элемента для обновления.</param>
        /// <param name="updatedParameters">Обновленные параметры элемента.</param>
        public static void UpdateElementInXml(string filePath, string id, InitialParameters updatedParameters)
        {
            XDocument xmlDoc = XDocument.Load(filePath) ??
                throw new InvalidOperationException("Файл по указанному пути отсутствует или повреждён.");

            var root = xmlDoc.Element("Bearings") ??
                throw new InvalidOperationException("Некорректный формат XML: отсутствует корневой элемент 'Bearings'.");

            var elementToUpdate = root.Elements("InitialParameters")
                                      .FirstOrDefault(el => (string)el.Attribute("Id") == id);

            if (elementToUpdate != null)
            {
                elementToUpdate.Element("Name")?.SetValue(updatedParameters.Name);
                elementToUpdate.Element("AccuracyClass")?.SetValue(updatedParameters.AccuracyClass.ToString());
                elementToUpdate.Element("D")?.SetValue(updatedParameters.D.ToString());
                elementToUpdate.Element("d")?.SetValue(updatedParameters.d.ToString());
                elementToUpdate.Element("B")?.SetValue(updatedParameters.B.ToString());
                elementToUpdate.Element("r_s_min")?.SetValue(updatedParameters.r_s_min.ToString());
                elementToUpdate.Element("Gr1")?.SetValue(updatedParameters.Gr1.ToString());
                elementToUpdate.Element("Gr2")?.SetValue(updatedParameters.Gr2.ToString());
                elementToUpdate.Element("lambda_B")?.SetValue(updatedParameters.lambda_B.ToString());
                elementToUpdate.Element("lambda_H")?.SetValue(updatedParameters.lambda_H.ToString());
                elementToUpdate.Element("X1")?.SetValue(updatedParameters.X1.ToString());
                elementToUpdate.Element("X2")?.SetValue(updatedParameters.X2.ToString());
                elementToUpdate.Element("Bm")?.SetValue(updatedParameters.Bm.ToString());
                elementToUpdate.Element("k")?.SetValue(updatedParameters.k);

                xmlDoc.Save(filePath);
            }
            else
            {
                throw new InvalidOperationException($"Элемент с Id = '{id}' не найден.");
            }
        }
    }
}
