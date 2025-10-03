using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;

namespace CD_WithModifiedContact.Helpers.Xml
{
    public class XmlRemover
    {
        public static void RemoveElementByName(string filePath, string elementName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            XmlElement xRoot = xmlDocument.DocumentElement ??
                throw new InvalidOperationException("Некорректный формат XML: отсутствует корневой элемент.");

            foreach (XmlElement xnode in xRoot)
            {
                foreach (XmlNode node in xnode.ChildNodes)
                {
                    if (node.Name == "Name" && node.InnerText == elementName)
                    {
                        xRoot.RemoveChild(xnode);
                    }
                }
            }
            xmlDocument.Save(filePath);
        }

        public static void RemoveElementById(string filePath, string id)
        {
            XDocument xmlDoc = XDocument.Load(filePath) ??
                throw new InvalidOperationException("Файл по указанному пути отсутствует или повреждён.");

            var root = xmlDoc.Element("Bearings") ??
                throw new InvalidOperationException("Некорректный формат XML: отсутствует корневой элемент 'Bearings'.");

            var elementToRemove = root.Elements("InitialParameters")
                                      .FirstOrDefault(el => (string)el.Attribute("Id") == id);

            if (elementToRemove != null)
            {
                elementToRemove.Remove();
                xmlDoc.Save(filePath);
            }
            else
            {
                //throw new InvalidOperationException($"Элемент с Id = '{id}' не найден.");
                ErrorHandler.ShowError($"Элемент с Id = '{id}' не найден.");
            }
        }
    }
}
