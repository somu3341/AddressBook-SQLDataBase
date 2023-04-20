using System;
namespace AddressBookSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Choose Option to Perform\n1.Get Address Book Contact Records\n2.Add Contacts\n3.Delete Contacts\n4.Update Contacts\n5.Exit");
                int Option=Convert.ToInt32(Console.ReadLine());
                switch(Option)
                {
                    case 1:
                        addressBook.GetAddressBookRecords();
                        break;
                        case 2:
                        Contacts contacts = new Contacts()
                        {
                            FirstName = "Soma",
                            LastName = "Shekar",
                            Address = "Banglore",
                            City = "Banglore",
                            State = "Karnataka",
                            Zip = 564362,
                            PhoneNumber = 9876554321,
                            Email = "Soma@gmail.com",
                            Name = "Somashekar",
                            Type = "Single",
                        };
                        addressBook.AddContacts(contacts);
                        break;                       
                        case 3:
                        Contacts contacts1 = new Contacts()
                        {
                            Id = 9,
                        };
                        addressBook.DeleteContacts(contacts1.Id);
                        break;  
                        case 4:
                        Contacts contacts2 = new Contacts()
                        {
                            Id = 2,
                            Type = "Family",
                        };
                        addressBook.UpdateContactDeatils(contacts2.Id,contacts2.Type);
                        break;
                        case 5:
                        flag = false;
                        break;
                }

            }
            
            
           
            
        }
    }
}