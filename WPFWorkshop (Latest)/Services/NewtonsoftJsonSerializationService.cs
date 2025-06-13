using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace WPFWorkshop.Services
{
    class NewtonsoftJsonSerializationService : SingletonBase<NewtonsoftJsonSerializationService>
    {
        #region Fields

        private JsonSerializerSettings _serializerSettings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.All,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Full
        };

        #endregion Fields

        #region Methods

        public bool TrySerialize(object input, out string output)
        {
            Debug.WriteLine("Attempting to serialize C# object of type: " + input.GetType());

            try
            {
                Debug.WriteLine("Serialization succeeded.");
                output = JsonConvert.SerializeObject(input, _serializerSettings);
                return true;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Serialization failed. Reason: " + exception);
                output = null;
                return false;
            }
        }

        public bool TryDeserialize(string input, out object output)
        {
            Debug.WriteLine("Attempting to deserialize JSON object: " + input);

            try
            {
                Debug.WriteLine("Deserialization succeeded.");
                output = JsonConvert.DeserializeObject(input, _serializerSettings);
                return true;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Deserialization failed. Reason: " + exception);
                output = null;
                return false;
            }
        }

        #endregion Methods
    }
}