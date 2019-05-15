using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> lstEmployee = new ObservableCollection<Employee>();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            lstEmployee.Add(new Employee() { EmpNo = 1001, EmpName = "Mahesh" });
            lstEmployee.Add(new Employee() { EmpNo = 1002, EmpName = "Amit" });
            lstEmployee.Add(new Employee() { EmpNo = 1003, EmpName = "Vaibhav" });
            lstEmployee.Add(new Employee() { EmpNo = 1004, EmpName = "Ashwin" });
            lstEmployee.Add(new Employee() { EmpNo = 1005, EmpName = "Prashant" });
            lstEmployee.Add(new Employee() { EmpNo = 1006, EmpName = "Vinit" });
            lstEmployee.Add(new Employee() { EmpNo = 1007, EmpName = "Abhijit" });
            lstEmployee.Add(new Employee() { EmpNo = 1008, EmpName = "Pankaj" });
            lstEmployee.Add(new Employee() { EmpNo = 1009, EmpName = "Kaustubh" });
            lstEmployee.Add(new Employee() { EmpNo = 1010, EmpName = "Mohan" });
            lstEmployee.Add(new Employee() { EmpNo = 1011, EmpName = "ahan" });

            lstEmpData.ItemsSource = lstEmployee;
        }
        private void txtNameToSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string txtOrig = txtNameToSearch.Text;
            string upper = txtOrig.ToUpper();
            string lower = txtOrig.ToLower();

            var empFiltered = from Emp in lstEmployee
                              let ename = Emp.EmpName
                              where
                               ename.StartsWith(lower)
                               || ename.StartsWith(upper)
                               || ename.Contains(txtOrig)
                              select Emp;

            lstEmpData.ItemsSource = empFiltered;
            lstEmpData.SelectedIndex = 0;
        }
    }
}
