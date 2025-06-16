using WPFWorkshop.Data;
using WPFWorkshop.Services.File;

namespace WPFWorkshop.Services.Workspace
{
    class WorkspaceService : IWorkspaceService, IDisposable
    {
        #region Events

        public Action Changed;

        #endregion Events

        #region Properties

        public ref WorkspaceFile CurrentFile => ref _currentFile;

        #endregion Properties

        #region Fields

        private IPersistenceService _persistenceService;
        private WorkspaceFile _savedFile = new();
        private WorkspaceFile _currentFile = new();

        #endregion Fields

        #region Constructors

        public WorkspaceService(IPersistenceService persistenceService)
        {
            _persistenceService = persistenceService;
        }

        #endregion Constructors

        #region Methods

        public void Dispose()
        {
            _currentFile.Changed -= OnFileChanged;
        }

        public void StartNewFile()
        {
            _savedFile = new WorkspaceFile();

            SetCurrentFile(new WorkspaceFile(_savedFile));

            Changed?.Invoke();
        }

        public void LoadFile(string filepath)
        {
            _savedFile = (WorkspaceFile)_persistenceService.Load(filepath);

            SetCurrentFile(new WorkspaceFile(_savedFile));

            Changed?.Invoke();
        }

        public void SaveCurrentFile(string filepath)
        {
            _persistenceService.Save(_currentFile, filepath);
            _savedFile = new WorkspaceFile(_currentFile);

            Changed?.Invoke();
        }

        public bool IsCurrentFileDirty()
        {
            return !_savedFile.Equals(_currentFile);
        }

        private void SetCurrentFile(WorkspaceFile file)
        {
            _currentFile.Changed -= OnFileChanged;
            _currentFile = file;
            _currentFile.Changed += OnFileChanged;
        }

        private void OnFileChanged()
        {
            Changed?.Invoke();
        }

        #endregion Methods
    }
}