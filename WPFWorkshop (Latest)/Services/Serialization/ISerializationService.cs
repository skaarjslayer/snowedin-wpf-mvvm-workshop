namespace WPFWorkshop.Services.Serialization
{
    interface ISerializationService
    {
        bool TrySerialize(object input, out string output);
        bool TryDeserialize(string input, out object output);
    }
}