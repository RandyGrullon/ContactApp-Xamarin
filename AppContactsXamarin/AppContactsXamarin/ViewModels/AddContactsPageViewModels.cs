using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

using AppContactsXamarin.Models;
using System.Collections.ObjectModel;
using AppContactsXamarin.Views;

namespace AppContactsXamarin.ViewModels
{
    public class AddContactsPageViewModels : INotifyPropertyChanged
    {
        public Contact Contact { get; set; }
        public ICommand SaveButtonCommand { get; set; }
        public ICommand EditElementCommand { get; set; }
        public ICommand DeleteElementCommand { get; set; }
        public AddContactsPageViewModels(Contact contact)
        {
            Contact = Contact == null ? new Contact():contact;

          

            SaveButtonCommand = new Command(async() =>
            {

                var A = App.DataBaseContact.SaveContact(Contact);
                await App.Current.MainPage.Navigation.PopToRootAsync();
            });

        }
       
       
        async void ShowContacts()
        {
            
        }
        public event PropertyChangedEventHandler PropertyChanged;


    }
}

