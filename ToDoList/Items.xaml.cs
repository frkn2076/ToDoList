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
    public partial class Items : Page {

        private UserInfo UserInfo { get; set; }
        private ToDo ToDoList { get; set; }
        public Items(UserInfo userInfo, ToDo toDolist) {
            UserInfo = userInfo;
            ToDoList = toDolist;
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid() {
            var content = ClientConfig<int>.Get("items/{toDoListId}", ToDoList.Id).Content;
            var dataGridData = JsonConvert.DeserializeObject<List<Item>>(content);
            var tempDataTable = CreateDataTable();
            if (dataGridData != null) {
                foreach (var item in dataGridData) {
                    var row = tempDataTable.NewRow();
                    row["Name"] = item.Name;
                    row["Description"] = item.Description;
                    row["DeadLine"] = item.DeadLine;
                    row["Complete"] = item.Status;
                    row["CreateDate"] = item.CreateDate;
                    tempDataTable.Rows.Add(row);
                }
            }
                ItemsGrid.ItemsSource = tempDataTable.DefaultView;
                (ItemsGrid.ItemsSource as DataView).Sort = "CreateDate";
        }

        private void DataGrid_SelectionChanged(object sender, DataGridCellEditEndingEventArgs e) {

            CheckBox changedCompleted = e.EditingElement as CheckBox;
            var isChecked = changedCompleted.IsChecked.Value;

            var itemDataRowView = (DataRowView)(ItemsGrid.SelectedItem);
            var itemRow = itemDataRowView.Row.ItemArray;

            var name = itemRow[0].ToString();
            var description = itemRow[1].ToString();
            var deadLine = Convert.ToDateTime(itemRow[2]);
            var isCompleted = Convert.ToBoolean(itemRow[3]);
            var createDate = Convert.ToDateTime(itemRow[4]);


            var itemsNotChanged = ToDoList.Items.Where(x => !(x.Name == name && x.Description == description && x.Status == isCompleted)).ToList();

            var item = new Item() {
                Name = name,
                Description = description,
                DeadLine = deadLine,
                CreateDate = createDate,
                Status = isChecked
            };

            if (ToDoList.Items == null) {
                ToDoList.Items = new List<Item>();
            }

            itemsNotChanged.Add(item);
            ToDoList.Items = itemsNotChanged;

            var itemsToInsert = new List<Item>();
            foreach (var temp in ToDoList.Items) {
                var tmp = new Item {
                    Name = temp.Name,
                    Description = temp.Description,
                    DeadLine = temp.DeadLine,
                    CreateDate = temp.CreateDate,
                    Status = temp.Status
                };
                itemsToInsert.Add(tmp);
            }

            var toDo = new ToDo() {
                Id = ToDoList.Id,
                Name = ToDoList.Name,
                CreateDate = ToDoList.CreateDate,
                Items = itemsToInsert
            };

            var response = ClientConfig<ToDo>.Post("updateToDoList", toDo);

            if (response.StatusCode == HttpStatusCode.OK) {
                FillDataGrid();
            }
            else {
                MessageBox.Show(response.Content);
            }

        }

        private void BackClicked(object sender, RoutedEventArgs e) {
            try {
                ToDoLists toDoListPage = new ToDoLists(UserInfo);
                NavigationService.Navigate(toDoListPage);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddItemClicked(object sender, RoutedEventArgs e) {
            try {
                var itemsToInsert = new List<Item>();
                var name = NameToInsert.Text;
                var description = DescriptionToInsert.Text;
                var createDate = DateTime.UtcNow;
                if (string.IsNullOrEmpty(name)) {
                    MessageBox.Show("Name of item cannot be null");
                    return;
                }
                if (string.IsNullOrEmpty(description)) {
                    MessageBox.Show("Description of item cannot be null");
                    return;
                }
                if (!DeadLineToInsert.SelectedDate.HasValue) {
                    MessageBox.Show("Please choose a deadline");
                    return;
                }
                var deadLine = DeadLineToInsert.SelectedDate.Value.ToUniversalTime();
                if (deadLine < createDate) {
                    MessageBox.Show("DeadLine must be after the moment");
                    return;
                }
                var item = new Item() {
                    Name = name,
                    Description = description,
                    DeadLine = deadLine,
                    CreateDate = createDate,
                    Status = false
                };
                if (ToDoList.Items == null) {
                    ToDoList.Items = itemsToInsert;
                    ToDoList.Items.Add(item);
                }
                else {
                    ToDoList.Items.Add(item);
                    foreach (var temp in ToDoList.Items.ToList()) {
                        var tmp = new Item {
                            Name = temp.Name,
                            Description = temp.Description,
                            DeadLine = temp.DeadLine.AddHours(3),
                            CreateDate = temp.CreateDate.AddHours(3),
                            Status = temp.Status
                        };
                        itemsToInsert.Add(tmp);
                    }
                }
                var toDo = new ToDo() {
                    Id = ToDoList.Id,
                    Name = ToDoList.Name,
                    CreateDate = ToDoList.CreateDate,
                    Items = itemsToInsert
                };
                var response = ClientConfig<ToDo>.Post("updateToDoList", toDo);
                if (response.StatusCode == HttpStatusCode.OK) {
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

        private void DeleteClicked(object sender, RoutedEventArgs e) {
            try {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                var myRow = dataRowView.Row.ItemArray;
                var itemToDelete = ToDoList.Items.FirstOrDefault(x => x.Name.Equals(myRow[0].ToString()) && x.Description.Equals(myRow[1].ToString()));
                var items = ToDoList.Items.Except(new List<Item>() { itemToDelete }).ToList();
                ToDoList.Items = items;
                var itemsToInsert = new List<Item>();
                foreach (var temp in ToDoList.Items) {
                    var tmp = new Item {
                        Name = temp.Name,
                        Description = temp.Description,
                        DeadLine = temp.DeadLine,
                        CreateDate = temp.CreateDate,
                        Status = temp.Status
                    };
                    itemsToInsert.Add(tmp);
                }
                var toDo = new ToDo() {
                    Id = ToDoList.Id,
                    Name = ToDoList.Name,
                    CreateDate = ToDoList.CreateDate,
                    Items = itemsToInsert
                };
                ClientConfig<ToDo>.Post("updateToDoList", toDo);
                FillDataGrid();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void FilterClicked(object sender, RoutedEventArgs e) {
            try {
                var isExpired = IsExpiredCheckBox.IsChecked.HasValue ? IsExpiredCheckBox.IsChecked.Value : false;
                var isCompleted = IsCompletedCheckBox.IsChecked.HasValue ? IsCompletedCheckBox.IsChecked.Value : false;
                var fromDate = FromDatePicker.SelectedDate.HasValue ? FromDatePicker.SelectedDate.Value : DateTime.MinValue;
                var toDate = ToDatePicker.SelectedDate.HasValue ? ToDatePicker.SelectedDate.Value : DateTime.MaxValue;
                var tempDataTable = CreateDataTable();
                var filteredItems = ToDoList.Items.Where(x => (isExpired ? x.DeadLine < DateTime.Now : x.DeadLine >= DateTime.Now) && (isCompleted ? x.Status : !x.Status) && fromDate.Date <= x.CreateDate.Date && toDate.Date >= x.CreateDate.Date);
                if (filteredItems.Count() != 0) {
                    foreach (var item in filteredItems) {
                        var row = tempDataTable.NewRow();
                        row["Name"] = item.Name;
                        row["Description"] = item.Description;
                        row["DeadLine"] = item.DeadLine;
                        row["Complete"] = item.Status;
                        row["CreateDate"] = item.CreateDate;
                        tempDataTable.Rows.Add(row);
                    }
                }
                ItemsGrid.ItemsSource = tempDataTable.DefaultView;
                (ItemsGrid.ItemsSource as DataView).Sort = "CreateDate";
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveFilterClicked(object sender, RoutedEventArgs e) {
            try {
                var tempDataTable = CreateDataTable();
                var items = ToDoList.Items;
                if (items.Count() != 0) {
                    foreach (var item in items) {
                        var row = tempDataTable.NewRow();
                        row["Name"] = item.Name;
                        row["Description"] = item.Description;
                        row["DeadLine"] = item.DeadLine;
                        row["Complete"] = item.Status;
                        row["CreateDate"] = item.CreateDate;
                        tempDataTable.Rows.Add(row);
                    }

                }
                ItemsGrid.ItemsSource = tempDataTable.DefaultView;
                (ItemsGrid.ItemsSource as DataView).Sort = "CreateDate";
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnChecked(object sender, RoutedEventArgs e) {
            throw new NotImplementedException();
        }

        private DataTable CreateDataTable(List<string> columns = null) {
            DataTable result = new DataTable();
            if (columns == null) {
                result.Columns.Add("Name");
                result.Columns.Add("Description");
                result.Columns.Add("DeadLine");
                result.Columns.Add("Complete");
                result.Columns.Add("CreateDate");
            }
            else {
                foreach(var item in columns) {
                    result.Columns.Add(item);
                }
            }
            return result;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            Handle();
        }

        private bool handle = true;
        private void ComboBox_DropDownClosed(object sender, EventArgs e) {
            if (handle) Handle();
            handle = true;
        }

        private void Handle() {
            var tempDataTable = CreateDataTable();
            var items = ToDoList.Items;
            if (items.Count() != 0) {
                foreach (var item in items) {
                    var row = tempDataTable.NewRow();
                    row["Name"] = item.Name;
                    row["Description"] = item.Description;
                    row["DeadLine"] = item.DeadLine;
                    row["Complete"] = item.Status;
                    row["CreateDate"] = item.CreateDate;
                    tempDataTable.Rows.Add(row);
                }

            }
            ItemsGrid.ItemsSource = tempDataTable.DefaultView;
            switch (Order.SelectedItem.ToString().Split(new string[] { ": " }, StringSplitOptions.None).Last()) {
                case "CreateDate":
                    (ItemsGrid.ItemsSource as DataView).Sort = "CreateDate";
                    break;
                case "DeadLine":
                    (ItemsGrid.ItemsSource as DataView).Sort = "DeadLine";
                    break;
                case "Name":
                    (ItemsGrid.ItemsSource as DataView).Sort = "Name";
                    break;
                case "Complete":
                    (ItemsGrid.ItemsSource as DataView).Sort = "Complete";
                    break;
                default:
                    break;
            }
        }
    }
}
