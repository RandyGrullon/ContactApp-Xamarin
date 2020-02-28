using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace AppContactsXamarin.Models
{
    public class ContactDB
    {
        readonly SQLiteAsyncConnection DataBaseContacts;
        public ContactDB(string path)
        {
            this.DataBaseContacts = new SQLiteAsyncConnection(path);
            this.DataBaseContacts.CreateTableAsync<Contact>().Wait();

        }
        public Task<int> DeleteContact(Contact Contacts)
        {
            return DataBaseContacts.DeleteAsync(Contacts);
        }

        public Task<Contact> GetContact(string name)
        {
            return DataBaseContacts.Table<Contact>().Where(i => i.Name == name).FirstOrDefaultAsync();
        }

        public Task<List<Contact>> ShowAllContacts()
        {
            return DataBaseContacts.Table<Contact>().ToListAsync();
        }
        public Task<int> SaveContact(Contact Contacts)
        {
            try
            {
                if (Contacts.Id != 0)
                {
                    return DataBaseContacts.UpdateAsync(Contacts);
                }
                else
                {
                    return DataBaseContacts.InsertAsync(Contacts);
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
            public Task<int> EditContact(Contact Contacts)
            {
                try
                {
                    if (Contacts.Id != 0)
                    {
                        return DataBaseContacts.UpdateAsync(Contacts);
                    }
                    else
                    {
                        return DataBaseContacts.InsertAsync(Contacts);
                    }
                }
                catch (Exception)
                {

                    return null;
                }

            }
        }
    }


