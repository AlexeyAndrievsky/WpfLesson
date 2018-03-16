using System;
using System.Windows;
using WpfLesson.DataAccess;
using WpfLesson.Model;
using WpfLesson.ViewModel;

namespace WpfLesson
{
    public partial class MainWindow : Window
    {
        private EmployersModel EmployersModel;
        private EmployeeModel EmployeeModel;
        private DepartmentsModel DepartmentsModel;
        private DepartmentModel DepartmentModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowEmployersButton_Click(object sender, RoutedEventArgs e)
        {
            EmployersView view = new EmployersView();
            EmployersModel = new EmployersModel(new DataServiceStub());
            DepartmentsModel = new DepartmentsModel(new DataServiceStub());
            view.DataContext = new EmployersViewModel(EmployersModel, DepartmentsModel);
            view.Owner = this;
            view.Show();
        }

        private void ShowDepartmentsButton_Click(object sender, RoutedEventArgs e)
        {
            DepartmentsView view = new DepartmentsView();
            EmployersModel = new EmployersModel(new DataServiceStub());
            DepartmentsModel = new DepartmentsModel(new DataServiceStub());
            view.DataContext = new DepartmentsViewModel(EmployersModel, DepartmentsModel);
            view.Owner = this;
            view.Show();
        }

        private void AddDepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            AddDepartmentView view = new AddDepartmentView();
            DepartmentModel = new DepartmentModel(new DataServiceStub());
            AddDepartmentViewModel vm = new AddDepartmentViewModel(DepartmentModel);
            view.DataContext = vm;
            vm.CloseAction = new Action(view.Close);
            view.Owner = this;
            view.Show();
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeView view = new AddEmployeeView();
            EmployeeModel = new EmployeeModel(new DataServiceStub());
            DepartmentsModel = new DepartmentsModel(new DataServiceStub());
            AddEmployeeViewModel vm = new AddEmployeeViewModel(EmployeeModel, DepartmentsModel);
            view.DataContext = vm;
            vm.CloseAction = new Action(view.Close);
            view.Owner = this;
            view.Show();
        }
    }
}
