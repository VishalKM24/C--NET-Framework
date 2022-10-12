using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace ContactsManagementsApp
{
    public class ContactdbRepo : IContactsRepo
    {
        private SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            return conn;
        }
        public void Delete(int id)
        {
            using(SqlConnection conn = GetConnection())
            {
                string sqlDelete = "delete from contacts where contactid = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sqlDelete;
                // can even pass in constructor parameter
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void Edit(int id, Contact ModifiedContact)
        {
            using(SqlConnection conn = GetConnection())
            {
                string sqlUpdate = "update contact set name=@name, mobile=@mobile, email=@email, location=@location, where contactid=@id";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sqlUpdate;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", ModifiedContact.Name);
                cmd.Parameters.AddWithValue("@mobile", ModifiedContact.Mobile);
                cmd.Parameters.AddWithValue("@location", ModifiedContact.location);
                cmd.Parameters.AddWithValue("@email", ModifiedContact.Email);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Contact getContactById(int id)
        {
            Contact c = new Contact();
            using (SqlConnection conn = GetConnection())
            {
                string sqlGet = "select * from contact where contactid=@id";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sqlGet;
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                c.ContactID = (int)reader[0];
                c.Name = reader[1].ToString();
                c.location = reader["location"].ToString();
                c.Email = (string)reader[3];
                c.Mobile = reader.GetString(2);
                
            }
            return c;
        }

        public List<Contact> GetContacts()
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public void Save(Contact contact)
        {
            // Step 1: Connect to Database
            using (SqlConnection conn = new SqlConnection())
            {

                //conn.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Integrated Security=True;Initial Catalog=master"; //Database server name, database and password
                // Initial Catalog
                //Data Source = (localdb)\mssqllocaldb; Integrated Security = True
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

                // Step 2 - Prepare Sql insert Commands
                //string sqlinsert = $"insert into Contact values ('{contact.Name}', '{contact.Mobile}', '{contact.Email}', '{contact.location}')";
                // can lead to SQL Injection

                string sqlinsert = "Insert into Contact Values ( @name, @mobile, @email, @location)";              
                SqlCommand cmd = new SqlCommand(sqlinsert, conn);
                cmd.Parameters.AddWithValue("@name", contact.Name);

                SqlParameter p2 = new SqlParameter();
                p2.ParameterName = "@mobile";
                p2.Value = contact.Mobile;
                cmd.Parameters.Add(p2);

                cmd.Parameters.AddWithValue("@email", contact.Email);
                cmd.Parameters.AddWithValue("@location", contact.location);
                
                conn.Open();
                cmd.ExecuteNonQuery();

                // Step 3: Close
                //conn.Close();
            
            }

        }
    }
}
