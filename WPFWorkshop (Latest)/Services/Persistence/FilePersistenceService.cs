using System.IO;
using WPFWorkshop.Services.Serialization;

namespace WPFWorkshop.Services.File
{
    class FilePersistenceService : IPersistenceService
    {
        #region Fields

        private ISerializationService _serializationService;

        #endregion Fields

        #region Constructors

        public FilePersistenceService(ISerializationService serializationService)
        {
            _serializationService = serializationService;
        }

        #endregion Constructors

        #region Methods

        public void Save(object input, string filepath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(System.IO.File.Open(filepath, FileMode.OpenOrCreate)))
                {
                    writer.Write(_serializationService.Serialize(input));
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Save request failed. Reason: " + exception.Message);
            }
        }

        public object Load(string filepath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(System.IO.File.Open(filepath, FileMode.Open)))
                {
                    string buffer = reader.ReadToEnd();
                    return _serializationService.Deserialize(buffer);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Load request failed. Reason: " + exception.Message);
            }
        }

        #endregion Methods
    }
}