using System;
namespace AddressBookSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            // addressBook.GetAddressBookRecords();
            Contacts contacts = new Contacts()
            //{
            //    FirstName = "Soma",
            //    LastName = "Shekar",
            //    Address = "Banglore",
            //    City ="Banglore",
            //    State="Karnataka",
            //    Zip=564362,
            //    PhoneNumber=9876554321,
            //    Email="Soma@gmail.com",
            //    Name="Somashekar",
            //    Type="Single",
            //};
            //addressBook.AddContacts(contacts);
            //{
            //    Id = 9,
            //};
            //addressBook.DeleteContacts(contacts.Id);
            {
                Id = 2,
                FirstName= "Ajith",
                LastName="Janya",
                Name = "AjithJanya",
                Type="Family",
            };
            addressBook.UpdateContacts(contacts.Id,contacts.FirstName,contacts.LastName,contacts.Name,contacts.Type);
        }
    }
}