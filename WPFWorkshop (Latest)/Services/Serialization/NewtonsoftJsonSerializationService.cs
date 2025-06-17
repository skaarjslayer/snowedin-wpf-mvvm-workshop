using Newtonsoft.Json;

namespace WPFWorkshop.Services.Serialization
{
    class NewtonsoftJsonSerializationService : ISerializationService
    {
        #region Fields

        private JsonSerializerSettings _serializerSettings;

        #endregion Fields

        #region Constructors

        public NewtonsoftJsonSerializationService(JsonSerializerSettings serializerSettings)
        {
            _serializerSettings = serializerSettings;
        }

        #endregion Constructors

        #region Methods

        public string Serialize(object input)
        {
            try
            {
                return JsonConvert.SerializeObject(input, _serializerSettings);
            }
            catch (Exception exception)
            {
                throw new Exception("Serialization failed. Reason: " + exception);
            }
        }

        public object Deserialize(string input)
        {
            try
            {
                return JsonConvert.DeserializeObject(input, _serializerSettings);
            }
            catch (Exception exception)
            {
                throw new Exception("Deserialization failed. Reason: " + exception);
            }
        }

        #endregion Methods
    }
}