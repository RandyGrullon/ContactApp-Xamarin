using AppContactsXamarin.Models;
using AppContactsXamarin.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using SQLitePCL;


namespace AppContactsXamarin
{
    public partial class App : Application
    {
        static ContactDB dataBaseContacts;
        public static ContactDB DataBaseContact
        {
            get
            {
                if (dataBaseContacts == null)
                {
                    dataBaseContacts = new ContactDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataBase.db"));
                }
                return dataBaseContacts;
            }
        }


        public App()
        {
            InitializeComponent();
            
            MainPage = new NavigationPage(new ContactPage());
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
