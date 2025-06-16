namespace WPFWorkshop.Services.File
{
    interface IPersistenceService
    {
        bool TrySave(string filepath, string buffer);
        bool TryLoad(string filepath, out string buffer);
    }
}