using Part1A.Models;
using Part1A.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Part1A.Views
{
    /// <summary>
    /// Interaction logic for EmployeeListView.xaml
    /// </summary>
    public partial class EmployeeListView : UserControl
    {
        public EmployeeListView()
        {
            InitializeComponent();

            this.DataContext = new EmployeeViewModel(
                new EmployeeModel("Jean-Sylvain Sormany", "Studio Head", "Management"),
                new EmployeeModel("Tim Vito", "Studio Operations Director", "Management"),
                new EmployeeModel("Nigel Franks", "Studio Production Director", "Management"),
                new EmployeeModel("Ian Anderson", "Art Director", "Art"),
                new EmployeeModel("Mike Keogh", "Producer", "Production"),
                new EmployeeModel("Natalia Nowinska", "Producer", "Production"),
                new EmployeeModel("Samrat Bharatkumar", "IT Technician", "Information Technology"),
                new EmployeeModel("Natasha Dobson", "Office Manager", "Administration"),
                new EmployeeModel("Lianne Caissie", "HR Representative", "Human Resources"),
                new EmployeeModel("Murilo Trigo", "Software Engineer Level 1", "Engineering"),
                new EmployeeModel("Chris Chellew", "Software Engineer Level 1", "Engineering"),
                new EmployeeModel("Thomas Hill", "Software Engineer Level 2", "Engineering"),
                new EmployeeModel("Allissia Le Henaff", "Software Engineer Level 2", "Engineering"),
                new EmployeeModel("Eric Dalrymple", "Software Engineer Level 3", "Engineering"),
                new EmployeeModel("Cameron Gazey", "Software Engineer Level 3", "Engineering"));
        }
    }
}
