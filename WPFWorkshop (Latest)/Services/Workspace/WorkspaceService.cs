using WPFWorkshop.Data;
using WPFWorkshop.Services.Serialization;
using WPFWorkshop.Services.File;

namespace WPFWorkshop.Services.Workspace
{
    class WorkspaceService : IWorkspaceService
    {
        #region Events

        public event Action<IReadOnlyList<Employee>> OnFileChanged = null;

        #endregion Events

        #region Properties

        private IPersistenceService _persistenceService;
        private List<Employee> employees = new List<Employee>();

        #endregion Propertiesa

        #region Constructors

        public WorkspaceService(IPersistenceService persistenceService)
        {
            _persistenceService = persistenceService;
        }

        #endregion Constructors

        #region Methods

        public void RequestCreateNewFile()
        {
            employees = new List<Employee>();

            OnFileChanged?.Invoke(employees);
        }

        public void RequestLoadFile(string filepath)
        {
            if (FilePersistenceService.Instance.TryLoad(filepath, out string buffer))
            {
                if (NewtonsoftJsonSerializationService.Instance.TryDeserialize(buffer, out object employees))
                {
                    this.employees = (List<Employee>)employees;

                    OnFileChanged?.Invoke(this.employees);
                }
            }
        }

        public void RequestSaveFile(string filepath)
        {
            _persistenceService.TrySave(filepath, string buffer);


            if (NewtonsoftJsonSerializationService.Instance.TrySerialize(employees, out string buffer))
            {
                FilePersistenceService.Instance.TrySave(filepath, buffer);
            }
        }

        public void AddNewEmployee(Employee employee)
        {
            employees.Add(employee);

            OnFileChanged?.Invoke(employees);
        }

        #endregion Methods
    }
}