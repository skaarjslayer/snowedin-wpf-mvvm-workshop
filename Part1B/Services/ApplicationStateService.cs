using Part1B.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Part1B.Services
{
    class ApplicationStateService : SingletonBase<ApplicationStateService>
    {
        public static readonly List<EmployeeModel> EmptyFile = new List<EmployeeModel> { };

        public event Action<IReadOnlyCollection<EmployeeModel>> OnFileChanged = null;

        private List<EmployeeModel> currentFile = EmptyFile;
        public IReadOnlyCollection<EmployeeModel> CurrentFile { get { return currentFile.AsReadOnly(); } }

        public void RequestCreateNewFile()
        {
            currentFile = EmptyFile;

            OnFileChanged?.Invoke(currentFile);
        }

        public void RequestLoadFile(string filepath)
        {
            if (FileService.Instance.TryLoad(filepath, out string buffer))
            {
                if(SerializationService.Instance.TryDeserialize(buffer, out object employees))
                {
                    currentFile = (List<EmployeeModel>)employees;

                    OnFileChanged?.Invoke(currentFile);
                }
            }
        }

        public void RequestSaveFile(string filepath)
        {
            if (SerializationService.Instance.TrySerialize(currentFile, out string buffer))
            {
                FileService.Instance.TrySave(filepath, buffer);
            }
        }

        public void AddNewEmployee(EmployeeModel model)
        {
            currentFile.Add(model);

            OnFileChanged?.Invoke(currentFile);
        }
    }
}