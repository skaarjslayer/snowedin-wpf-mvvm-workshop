using WPFWorkshop.Data;
using System;
using System.Collections.Generic;

namespace WPFWorkshop.Services
{
    class ApplicationStateService : SingletonBase<ApplicationStateService>
    {
        #region Events

        public event Action<IReadOnlyCollection<Employee>> OnFileChanged = null;

        #endregion Events

        #region Properties

        private List<Employee> currentFile = new List<Employee>();
        public IReadOnlyCollection<Employee> CurrentFile { get { return currentFile.AsReadOnly(); } }

        #endregion Properties

        #region Methods

        public void RequestCreateNewFile()
        {
            currentFile = new List<Employee>();

            OnFileChanged?.Invoke(currentFile);
        }

        public void RequestLoadFile(string filepath)
        {
            if (SystemFileService.Instance.TryLoad(filepath, out string buffer))
            {
                if(NewtonsoftJsonSerializationService.Instance.TryDeserialize(buffer, out object employees))
                {
                    currentFile = (List<Employee>)employees;

                    OnFileChanged?.Invoke(currentFile);
                }
            }
        }

        public void RequestSaveFile(string filepath)
        {
            if (NewtonsoftJsonSerializationService.Instance.TrySerialize(currentFile, out string buffer))
            {
                SystemFileService.Instance.TrySave(filepath, buffer);
            }
        }

        public void AddNewEmployee(Employee model)
        {
            currentFile.Add(model);

            OnFileChanged?.Invoke(currentFile);
        }

        #endregion Methods
    }
}