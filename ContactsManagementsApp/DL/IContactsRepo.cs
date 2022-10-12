using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagementsApp
{
    public interface IContactsRepo
    {
        void Save(Contact contact);
        List<Contact> GetContacts();
        Contact getContactById(int id);
        List<Contact> GetContactsByLocation(string location);
        void Delete(int id);
        void Edit(int id, Contact ModifiedContact);


    }
}
