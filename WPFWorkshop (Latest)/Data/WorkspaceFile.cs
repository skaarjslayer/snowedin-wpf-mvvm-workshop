namespace WPFWorkshop.Data
{
    struct WorkspaceFile
    {
        #region Events

        public Action Changed;

        #endregion Events

        private List<Employee> _employees;

        #region Constructors

        public WorkspaceFile()
        {
            _employees = new();
        }

        public WorkspaceFile(WorkspaceFile otherFile)
        {
            _employees = new(otherFile._employees);
        }

        #endregion Constructors

        #region Methods

        public override bool Equals(object obj)
        {
            if (obj is WorkspaceFile other)
            {
                return _employees.SequenceEqual(other._employees);
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;

            foreach (Employee employee in _employees)
            {
                hash = hash * 31 + employee.GetHashCode();
            }

            return hash;
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);

            Changed?.Invoke();
        }

        #endregion Methods
    }
}