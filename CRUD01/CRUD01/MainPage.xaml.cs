using CRUD01.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using SQLite;
using System.ComponentModel;
using System;
using CRUD01.Connections;

namespace CRUD01
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        SQLiteAsyncConnection conn = DependencyService.Get<ISqlConnection>().GetConnection(); 
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = this;

            conn.CreateTableAsync<Contacts>();
            ReadData();

        }

        private ObservableCollection<Contacts> cList;

        public ObservableCollection<Contacts> CList
        {
            get { return cList; }
            set { cList = value; }
        }

        private void Save(object sender, EventArgs e)
        {
            conn.InsertAsync(new Contacts() { Name = Name.Text, Address = Address.Text });

            ReadData();
        }

        public void ReadData()
        {

            var list = conn.Table<Contacts>().ToListAsync().Result;

            CList = new ObservableCollection<Contacts>(list);
            ContactList.ItemsSource = CList;
        }

        private void ListItem_Delete(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            var item = mi.CommandParameter as Contacts;
            conn.DeleteAsync(item);
            ReadData();
        }

        private void Update(object sender, EventArgs e)
        {
            var mi = sender as MenuItem;
            var item = mi.CommandParameter as Contacts;
            item.Name = "Martin";
            item.Address = "New York";
            conn.UpdateAsync(item);
            ReadData();
        }


    }
}
