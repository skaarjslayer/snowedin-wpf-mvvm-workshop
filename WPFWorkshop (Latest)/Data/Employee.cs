namespace WPFWorkshop.Data
{
    class Employee
    {
        #region Properties

        public string Name { get; init; }
        public string Role { get; init; }
        public string Department { get; init; }

        #endregion Properties

        #region Constructors

        public Employee(string name, string role, string department)
        {
            Name = name;
            Role = role;
            Department = department;
        }

        #endregion Constructors
    }
}