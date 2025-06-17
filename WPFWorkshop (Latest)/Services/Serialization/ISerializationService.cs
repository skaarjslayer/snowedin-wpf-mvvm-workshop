namespace WPFWorkshop.Services.Serialization
{
    interface ISerializationService
    {
        string Serialize(object input);
        object Deserialize(string input);
    }
}