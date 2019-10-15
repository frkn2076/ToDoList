using System.Windows;

namespace ToDoList {
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
            RegisterLoginPage p1 = new RegisterLoginPage();
            frame1.Navigate(p1);
        }
    }
}
