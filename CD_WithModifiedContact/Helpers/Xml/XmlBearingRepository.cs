using System.Collections.Generic;
using CD_WithModifiedContact.Calculation;

namespace CD_WithModifiedContact.Helpers.Xml
{
    public class XmlBearingRepository : IBearingRepository
    {
        private readonly string _filePath;

        public XmlBearingRepository(string filePath)
        {
            _filePath = filePath;
        }

        public List<InitialParameters> GetAll()
        {
            return XmlReaderHelper.LoadInitialParametersFromFile(_filePath);
        }

        public void Add(InitialParameters parameters)
        {
            XmlWriterHelper.SaveInitialParameterToXml(parameters, _filePath);
        }

        public void Update(InitialParameters parameters)
        {
            XmlUpdater.UpdateElementInXml(_filePath, parameters.Id, parameters);
        }

        public void Delete(string id)
        {
            XmlRemover.RemoveElementById(_filePath, id);
        }
    }
}
