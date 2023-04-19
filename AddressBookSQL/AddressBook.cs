using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSQL
{
    public class AddressBook
    {
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial catalog = AddressBookService";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAddressBookRecords()
        {
            try
            {
                Contacts contacts = new Contacts();
                using (this.connection)
                {
                    string query = @"Select * from Address_Book";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    command.CommandType = CommandType.Text;
                    this.connection.Open();
                    SqlDataReader read = command.ExecuteReader();
                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            contacts.Id = read.GetInt32(0);
                            contacts.FirstName = read.GetString(1);
                            contacts.LastName = read.GetString(2);
                            contacts.Address = read.GetString(3);
                            contacts.City = read.GetString(4);
                            contacts.State = read.GetString(5);
                            contacts.Zip = read.GetInt64(6);
                            contacts.PhoneNumber = read.GetInt64(7);
                            contacts.Email = read.GetString(8);
                            contacts.Name = read.GetString(9);
                            contacts.Type = read.GetString(10);
                        }
                        Console.WriteLine(contacts.Id + "\n" + contacts.FirstName + "\n" + contacts.LastName + "\n" + contacts.Address + "\n" + contacts.City + "\n" + contacts.State + "\n" + contacts.Zip + "\n" + contacts.PhoneNumber + "\n" + contacts.Email + "\n" + contacts.Name + "\n" + contacts.Type);
                    }
                    else
                    {
                        Console.WriteLine("No Records Found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AddContacts(Contacts contacts)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("AddContacts", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", contacts.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", contacts.LastName);
                    cmd.Parameters.AddWithValue("@Address", contacts.Address);
                    cmd.Parameters.AddWithValue("@City", contacts.City);
                    cmd.Parameters.AddWithValue("@State", contacts.State);
                    cmd.Parameters.AddWithValue("@Zip", contacts.Zip);
                    cmd.Parameters.AddWithValue("@PhoneNumber", contacts.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", contacts.Email);
                    cmd.Parameters.AddWithValue("@Name", contacts.Name);
                    cmd.Parameters.AddWithValue("@Type", contacts.Type);
                    this.connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (rowsAffected > 0)
                        Console.WriteLine("Contacts Added Successfully");
                    else
                        Console.WriteLine("Contacts Added UnSuccessfully");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteContacts(int id)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("DeleteContacts", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id",id);
                    this.connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (rowsAffected > 0)
                        Console.WriteLine("Contacts Deleted Successfully");
                    else
                        Console.WriteLine("Contacts Deleted UnSuccessfully");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateContacts(int id, string First, string Last, string name, string Type)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("UpdateContacts", this.connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@FirstName", First);
                    cmd.Parameters.AddWithValue("@LastName", Last);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Type", Type);                
                    this.connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    this.connection.Close();
                    if (rowsAffected > 0)
                        Console.WriteLine("Contacts Updated Successfully");
                    else
                        Console.WriteLine("Contacts Updated UnSuccessfully");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
