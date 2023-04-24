--UC1
Create Database AddressBookService;
use AddressBookService;

--UC2
Create table Address_Book(
Id int primary Key identity(1,1),
FirstName Varchar(30),
LastName Varchar(30),
Address Varchar(30),
City Varchar(30),
State Varchar(30),
Zip BigInt,
PhoneNumber BigInt,
Email Varchar(30),
)

--UC3
Insert into Address_Book(FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email) values('Soma','Shekar','Banglore','Banglore','Karnataka',563746,9808787656,'Soma@gmail.com');
Insert into Address_Book(FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email) values('Raja','Shekar','Chennai','Chennai','TN',563746,9808787656,'Raja@gmail.com');
Insert into Address_Book(FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email) values('Anil','Kumar','Delhi','Delhi','Delhi',563746,9808787656,'Anil@gmail.com');
Insert into Address_Book(FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email) values('Manju','Natha','Manglore','Manglore','Karnataka',563746,9808787656,'Manju@gmail.com');
Insert into Address_Book(FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email) values('Indra','Kumar','Banglore','Banglore','Karnataka',563746,9808787656,'Indra@gmail.com');

Select*from Address_Book;

--UC4
Update Address_Book Set FirstName='Krishna',LastName='Kumara' Where Id=5; 

--UC5
Delete Address_Book Where Id=6;

--UC6
Select*from Address_Book Where City='Banglore' or State='Karnataka';

--UC7
Select COUNT(City) from Address_Book Where City='Banglore';
Select COUNT(State) from Address_Book Where State='Karnataka';

--UC8
Select * from Address_Book Where City='Banglore' ORDER BY FirstName;

--UC9
Alter Table Address_Book Add Name Varchar(30), Type Varchar(30);
update Address_Book set Name='Somashekar',Type='Family' Where Id=1;
update Address_Book set Name='Rajashekar',Type='Friends' Where Id=2;
update Address_Book set Name='Anilkumar',Type='Profession' Where Id=3;
update Address_Book set Name='Manjunatha',Type='Family' Where Id=4;
update Address_Book set Name='Indrakumar',Type='Friend' Where Id=5;

--UC10
Select COUNT(Type) from Address_Book Where Type='Family';

--UC11
Insert into Address_Book(FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email,Name,Type) values('Sanjay','Kumar','Kolar','Kolar','Karnataka',553746,9874687656,'Sanjay@gmail.com','Sanjaykumar','Friend'); 
Insert into Address_Book(FirstName,LastName,Address,City,State,Zip,PhoneNumber,Email,Name,Type) values('Prathap','Singh','Rajasthan','Rajasthan','Rajasthan',343746,6787468765,'Prathap@gmail.com','Prathapsingh','Family'); 

--UC12
Create Table Type
(
ID int primary Key identity(1,1),
TypeName Varchar(30),
PersonID int Foreign Key REFERENCES Address_Book(ID)
);
Insert into Type(TypeName,PersonID) Values('Friends','1');
Insert into Type(TypeName,PersonID) Values('Family','1');
select * from Type;

--UC13
Select*from Address_Book;

--UC14
Create Procedure AddContacts
(
@FirstName varchar(30),
@LastName varchar(30),
@Address varchar(30),
@City varchar(30),
@State varchar(30),
@Zip BigInt,
@PhoneNumber BigInt,
@Email varchar(30),
@Name varchar(30),
@Type varchar(30)
)
As
Begin
Insert into Address_Book values(@FirstName,@LastName,@Address,@City,@State,@Zip,@PhoneNumber,@Email,@Name,@Type);
End 

--UC15
Create Procedure DeleteContacts
(
@Id int
)
As
Begin
Delete from Address_Book Where Id=@Id;
End

--UC16
Create Procedure UpdateContactDeatils
(
@Id int,
@Type varchar(30)
)
As
Begin
Update Address_Book set Type=@Type Where Id=@Id;
End