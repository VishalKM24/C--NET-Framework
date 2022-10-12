using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagementsApp
{
    public class ContactsFileRepo : IContactsRepo
    {
        private readonly string file = "C:\\Users\\Admin\\Desktop\\Framework-Projects\\Sum\\ContactsManagementsApp\\ContactData.txt";
        public void Delete(int id)
        {
            List<Contact> contacts = new List<Contact>();
            StreamReader sr = new StreamReader(file);
            try
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Contact c = new Contact();
                    string[] data = line.Split(',');
                    if(id != int.Parse(data[0]))
                    {
                        c.ContactID = int.Parse(data[0]);
                        c.Name = data[1];
                        c.Mobile = data[2];
                        c.Email = data[3];
                        c.location = data[4];
                        contacts.Add(c);
                    }
                }
            }
            finally
            {
                sr.Close();
            }


            foreach (var contact in contacts)
            {
                string ContactCSV = $"{contact.ContactID}, {contact.Name}, {contact.Mobile}, {contact.Email}, {contact.location}";
                StreamWriter sw = new StreamWriter(file);
                try
                {
                    sw.WriteLine(ContactCSV);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    sw.Close();
                }
            }
        }

        public void Edit(int id, Contact ModifiedContact)
        {
            List<Contact> contacts = new List<Contact>();
            StreamReader sr = new StreamReader(file);
            try
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Contact c = new Contact();
                    string[] data = line.Split(',');
                    if (id != int.Parse(data[0]))
                    {
                        c.ContactID = int.Parse(data[0]);
                        c.Name = data[1];
                        c.Mobile = data[2];
                        c.Email = data[3];
                        c.location = data[4];
                        contacts.Add(c);
                    }
                    else
                        contacts.Add(ModifiedContact);
                }
            }
            finally
            {
                sr.Close();
            }


            foreach (var contact in contacts)
            {
                string ContactCSV = $"{contact.ContactID}, {contact.Name}, {contact.Mobile}, {contact.Email}, {contact.location}";
                StreamWriter sw = new StreamWriter(file);
                try
                {
                    sw.WriteLine(ContactCSV);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    sw.Close();
                }
            }
        }

        public Contact getContactById(int id)
        {
            Contact c = new Contact();

            StreamReader sr = new StreamReader(file);
            try
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] data = line.Split(',');

                    if (int.Parse(data[0]) == id)
                    {
                        c.ContactID = int.Parse(data[0]);
                        c.Name = data[1];
                        c.Mobile = data[2];
                        c.Email = data[3];
                        c.location = data[4];
                        break;
                    }
                }
            }
            finally
            {
                sr.Close();
            }

            return c;
        }

        public List<Contact> GetContacts()
        {
            List<Contact> contacts = new List<Contact>();
            
            StreamReader sr = new StreamReader(file);
            try
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Contact c = new Contact();
                    string[] data = line.Split(',');
                    c.ContactID = int.Parse(data[0]);
                    c.Name = data[1];
                    c.Mobile = data[2];
                    c.Email = data[3];
                    c.location = data[4];

                    contacts.Add(c);
                }
            }
            finally
            {
                sr.Close();
            }

            return contacts;
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            List<Contact> contacts = new List<Contact>();

            StreamReader sr = new StreamReader(file);
            try
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    Contact c = new Contact();
                    string[] data = line.Split(',');
                    
                    
                    if(data[4] == location)
                    {
                        c.ContactID = int.Parse(data[0]);
                        c.Name = data[1];
                        c.Mobile = data[2];
                        c.Email = data[3];
                        c.location = data[4];
                        contacts.Add(c);
                    }     
                }
            }
            finally
            {
                sr.Close();
            }

            return contacts;
        }

        public void Save(Contact contact)
        {
            string ContactCSV = $"{contact.ContactID}, {contact.Name}, {contact.Mobile}, {contact.Email}, {contact.location}";
            StreamWriter sw = new StreamWriter(file, true);

            try
            {
                sw.WriteLine(ContactCSV);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                sw.Close();
            }

        }
    }
}
