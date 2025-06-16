using System.Diagnostics;
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

        public bool TrySave(object input, string filepath)
        {
            try
            {
                if()
                using (StreamWriter writer = new StreamWriter(System.IO.File.Open(filepath, FileMode.OpenOrCreate)))
                {
                    Debug.WriteLine("Save request complete.");
                    writer.Write(input);
                    return true;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Save request failed. Reason: " + exception.Message);
                return false;
            }
        }

        public bool TryLoad(string filepath, out string buffer)
        {
            try
            {
                using (StreamReader reader = new StreamReader(System.IO.File.Open(filepath, FileMode.Open)))
                {
                    Debug.WriteLine("Load request complete.");
                    buffer = reader.ReadToEnd();
                    return true;
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Load request failed. Reason: " + exception.Message);
                buffer = null;
                return false;
            }
        }

        #endregion Methods
    }
}