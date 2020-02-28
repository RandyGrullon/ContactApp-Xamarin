using AppContactsXamarin.Models;
using AppContactsXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace AppContactsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddContactPage : ContentPage
    {
        public AddContactPage(Contact contact)
        {
            InitializeComponent();
            BindingContext = new AddContactsPageViewModels(contact);
        }

        private void SaveButtonContact(object sender, EventArgs e)
        {


        }
    }
}