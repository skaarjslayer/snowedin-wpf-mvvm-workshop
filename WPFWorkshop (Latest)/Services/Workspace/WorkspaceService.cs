using WPFWorkshop.Data;
using WPFWorkshop.Services.File;

namespace WPFWorkshop.Services.Workspace
{
    class WorkspaceService : IWorkspaceService
    {
        #region Events

        public event Action CurrentFileChanged;

        #endregion Events

        #region Properties

        public WorkspaceFile CurrentFile => _currentFile;

        #endregion Properties

        #region Fields

        private IPersistenceService _persistenceService;
        private WorkspaceFile _savedFile;
        private WorkspaceFile _currentFile;

        #endregion Fields

        #region Constructors

        public WorkspaceService(IPersistenceService persistenceService)
        {
            _persistenceService = persistenceService;
            _savedFile = new();
            _currentFile = new();
        }

        #endregion Constructors

        #region Methods

        public void StartNewFile()
        {
            _savedFile = new WorkspaceFile();
            _currentFile = new WorkspaceFile();
            CurrentFileChanged?.Invoke();
        }

        public void LoadFile(string filepath)
        {
            _savedFile = (WorkspaceFile)_persistenceService.Load(filepath);
            _currentFile = new WorkspaceFile(_savedFile);
            CurrentFileChanged?.Invoke();
        }

        public void SaveCurrentFile(string filepath)
        {
            _persistenceService.Save(_currentFile, filepath);
            _savedFile = new WorkspaceFile(_currentFile);
        }

        public bool IsCurrentFileDirty()
        {
            return !WorkspaceFile.Comparer.Equals(_savedFile, _currentFile);
        }

        #endregion Methods
    }
}