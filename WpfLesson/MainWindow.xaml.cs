using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Threading;

namespace WpfLesson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool PlayState = false;
        public ObservableCollection<Employee> Employeers;
        public ObservableCollection<Department> Departments;

        public MainWindow()
        {
            InitializeComponent();
            Departments = new ObservableCollection<Department>();
            Departments.Add(new Department(1, "Маркетинг", "Занимаются маркетингом"));
            Departments.Add(new Department(2, "Производство", "Занимаются производством"));
            Departments.Add(new Department(3, "Мэнеджмент", "Занимаются управлением"));
            deptComboBox.ItemsSource = Departments;
            
            Employeers = new ObservableCollection<Employee>();
            Employeers.Add(new Employee("По", "Некоторым", "Причиам", DateTime.Now, "123456", "Мойка 82", 1));
            Employeers.Add(new Employee("Не", "было", "возможности", DateTime.Now, "356783", "Садовая 822", 2));
            Employeers.Add(new Employee("работать", "над", "домашним заданием", DateTime.Now, "235645", "Невский 8к2", 3));
            Employeers.Add(new Employee("последние", "дни", "Обещаю", DateTime.Now, "567452", "Бейкер стрит 277b", 1));
            Employeers.Add(new Employee("выполнить", "в", "ближайшее время", DateTime.Now, "965543", "Бабушкина 21", 2));
            employeersList.ItemsSource = Employeers;
        }

        private void media_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            throw new FileLoadException();
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            if (!PlayState)
            {
                media.Play();
                playButton.Content = "Пауза";
                PlayState = true;
            }
            else
            {
                media.Pause();
                playButton.Content = "Пуск";
                PlayState = false;
            }
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
            PlayState = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Employeers.RemoveAt(employeersList.SelectedIndex);
        }
    }
}
