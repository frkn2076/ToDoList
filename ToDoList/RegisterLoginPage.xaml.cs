using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoList.Response;

namespace ToDoList {
    public partial class RegisterLoginPage : Page {

        public RegisterLoginPage() {
            InitializeComponent();
        }

        private void LoginClicked(object sender, RoutedEventArgs e) {

            try {
                var email = Email.Text;
                var password = PasswordBox.Password;
                var userInfoToPost = new UserInfo { Email = email, Password = password };
                var response = ClientConfig<UserInfo>.Post("login", userInfoToPost);
                if (response.StatusCode == HttpStatusCode.OK) {
                    var userInfo = JsonConvert.DeserializeObject<UserInfo>(response.Content);
                    ToDoLists toDoListsPage = new ToDoLists(userInfo);
                    NavigationService.Navigate(toDoListsPage);
                }
                else {
                    MessageBox.Show(response.Content);
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void RegisterClicked(object sender, RoutedEventArgs e) {
            try {
                var email = Email.Text;
                var password = PasswordBox.Password;
                var userInfoToPost = new UserInfo { Email = email, Password = password };
                var response = ClientConfig<UserInfo>.Post("registration", userInfoToPost);
                if (response.StatusCode == HttpStatusCode.OK) {
                    MessageBox.Show(response.Content);
                }
                else {
                    MessageBox.Show(response.Content);
                }
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e) {

        }
    }
}
