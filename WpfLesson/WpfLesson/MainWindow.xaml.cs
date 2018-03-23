using System.Collections.Generic;
using System.Windows;
using WpfLesson.ViewModel;

namespace WpfLesson
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Dictionary<string, Window> windows = new Dictionary<string, Window>();
            windows.Add("EmployersView", new EmployersView());
            windows.Add("DepartmentsView", new DepartmentsView());
            windows.Add("AddDepartmentView", new AddDepartmentView());
            windows.Add("AddEmployeeView", new AddEmployeeView());
            this.DataContext = new MainWindowViewModel(windows, this);
            InitializeComponent();
        }
    }
}
