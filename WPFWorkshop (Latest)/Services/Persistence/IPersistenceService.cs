namespace WPFWorkshop.Services.File
{
    interface IPersistenceService
    {
        void Save(object input, string filepath);
        object Load(string filepath);
    }
}