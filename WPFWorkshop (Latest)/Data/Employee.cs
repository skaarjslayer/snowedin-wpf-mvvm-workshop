namespace WPFWorkshop.Data
{
    class Employee
    {
        #region Properties

        public string Name { get; private set; }
        public string Title { get; private set; }
        public string Department { get; private set; }

        #endregion Properties

        #region Constructors

        public Employee(string name, string title, string department)
        {
            Name = name;
            Title = title;
            Department = department;
        }

        #endregion Constructors
    }
}