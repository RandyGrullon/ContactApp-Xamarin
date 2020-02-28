using AppContactsXamarin.Models;
using AppContactsXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppContactsXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
            BindingContext = new ContactsPageViewModels();
        }

        private void AddContact(object sender, EventArgs e)
        {

        }

        private void PSelected(object sender, ItemTappedEventArgs e)
        {


        }
    }
}