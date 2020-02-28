using AppContactsXamarin.Models;
using AppContactsXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using AppContactsXamarin;
using SQLite;
using SQLitePCL;

namespace AppContactsXamarin.ViewModels
{
    public class ContactsPageViewModels : INotifyPropertyChanged
    {
        public ICommand DeleteElementCommand { get; set; }
        public ICommand AddContact { get; set; }
        public ICommand RefreshingCommand { get; set; }
        public bool IsRefreshing { get; set; }

        Contact _ContactSelected;

        void PlacePhoneCall(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException anEx)
            {

            }
            catch (FeatureNotSupportedException ex)
            {

            }
            catch (Exception ex)
            {

            }
        }
        public Contact ContactSelected
        {
            get
            {
                return _ContactSelected;
            }
            set
            {
                _ContactSelected = value;


                if (_ContactSelected != null)
                    DisplayElementSelected();
            }
        }



        public ObservableCollection<Contact> LoadContacts { get; set; }  
        public ContactsPageViewModels()
        {
            LoadContacts = new ObservableCollection<Contact>();
            ShowContacts();
            IsRefreshing = false;
            RefreshingCommand = new Command(()=> 
            {
                IsRefreshing = true;
                ShowContacts();
                IsRefreshing = false; 
            });

            DeleteElementCommand = new Command<Contact>((param) =>
            {
                LoadContacts.Remove(param);
                var B = App.DataBaseContact.DeleteContact(param);

            });

            AddContact = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new AddContactPage(null));
            });

        }

        public event PropertyChangedEventHandler PropertyChanged;

        async void ShowContacts()
        {
            var list = await App.DataBaseContact.ShowAllContacts();
            LoadContacts = new ObservableCollection<Contact>(list);

        }
        async void DisplayElementSelected()
        {
            var PersonSelected = await App.Current.MainPage.DisplayActionSheet("Phone Dialer", "Cancel", null, "Call", "Edit");

            switch (PersonSelected)
            {
                case "Call":

                    PlacePhoneCall(ContactSelected.Number);
                    break;

                case "Edit":

                        await App.Current.MainPage.Navigation.PushAsync(new AddContactPage(ContactSelected));

                    
                    break;

                default:
                    break;
            }
        }
    }
}
