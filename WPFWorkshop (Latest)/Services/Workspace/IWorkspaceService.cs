using WPFWorkshop.Data;

namespace WPFWorkshop.Services.Workspace
{
    interface IWorkspaceService
    {
        #region Events

        event Action CurrentFileChanged;

        #endregion Events

        #region Properties

        WorkspaceFile CurrentFile { get; }

        #endregion Properties

        #region Methods

        void StartNewFile();
        void LoadFile(string filepath);
        void SaveCurrentFile(string filepath);
        bool IsCurrentFileDirty();

        #endregion Methods
    }
}