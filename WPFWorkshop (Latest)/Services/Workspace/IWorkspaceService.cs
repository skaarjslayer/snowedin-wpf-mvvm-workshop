using WPFWorkshop.Data;

namespace WPFWorkshop.Services.Workspace
{
    interface IWorkspaceService
    {
        #region Properties

        ref WorkspaceFile CurrentFile { get; }

        #endregion Properties

        #region Methods

        void StartNewFile();
        void LoadFile(string filepath);
        void SaveCurrentFile(string filepath);
        bool IsCurrentFileDirty();

        #endregion Methods
    }
}