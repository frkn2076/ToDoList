using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using ToDoList.Response;

namespace ToDoList {
    public partial class ToDoLists : Page {

        private UserInfo UserInfo { get; set; }
        public ToDoLists(UserInfo userInfo) {
            UserInfo = userInfo;
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid() {
            try {
                var response = ClientConfig<string>.Get("toDoLists/{email}", UserInfo.Email);
                var content = response.Content;
                var dataGridData = JsonConvert.DeserializeObject<List<ToDo>>(content);
                DataTable dt = new DataTable("ToDoList");
                dt.Columns.Add("Id");
                dt.Columns.Add("Name");
                foreach (var item in dataGridData) {
                    var row = dt.NewRow();
                    row["Id"] = item.Id.ToString();
                    row["Name"] = item.Name;
                    dt.Rows.Add(row);
                }
                if (response.StatusCode == HttpStatusCode.OK) {
                    ToDoListGrid.ItemsSource = dt.DefaultView;
                }
                else {
                    MessageBox.Show(response.Content);
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void ViewClicked(object sender, RoutedEventArgs e) {
            try {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                var myRow = dataRowView.Row.ItemArray;
                var toDoListId = Convert.ToInt32(myRow[0]);
                var toDoList = UserInfo.ToDoLists.FirstOrDefault(x => x.Id == toDoListId);
                Items toDoListPage = new Items(UserInfo, toDoList);
                NavigationService.Navigate(toDoListPage);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackClicked(object sender, RoutedEventArgs e) {
            try {
                RegisterLoginPage registerLoginPage = new RegisterLoginPage();
                NavigationService.Navigate(registerLoginPage);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteClicked(object sender, RoutedEventArgs e) {
            try {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                var myRow = dataRowView.Row.ItemArray;
                var toDoListId = Convert.ToInt32(myRow[0]);
                var response = ClientConfig<int>.Get("deleteToDoList/{toDoListId}", toDoListId);
                if (response.StatusCode == HttpStatusCode.OK) {
                    FillDataGrid();
                }
                else {
                    MessageBox.Show(response.Content);
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddToDoListClicked(object sender, RoutedEventArgs e) {
            try {
                var toDoListToInsert = NameToInsert.Text;
                if (string.IsNullOrEmpty(toDoListToInsert)) {
                    MessageBox.Show("Name of to-do list cannot be null");
                    return;
                }
                var response = ClientConfig<string>.Post("insertToDoList/{toDoListName}", UserInfo.Email, toDoListToInsert);
                var userInfo = JsonConvert.DeserializeObject<UserInfo>(response.Content);
                if (response.StatusCode == HttpStatusCode.OK) {
                    UserInfo = userInfo;
                    FillDataGrid();
                }
                else {
                    MessageBox.Show(response.Content);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
