This project represents a web application which shows an address book of people for which we can perform certain operations on. <br>
The MVC pattern is used in this project, where the model, the view and the controller are respectfully separated in the project.

**Technologies and tools:**
* ASP.NET 4.7 MVC 
* Entity Framework
* Newtonsoft Framework
* SQLite Database
* Identity API
* Visual Studio 2019
* .NET Core 3.0

**Functionality:**
* Two static pages, Home and Privacy and the data view Address Book
* View of the content as a list or individual view of a person
* Edit the info of a person
* Delete a person entry
* Create a new person entry
* Content filtering for each attribute of a person
* Export the data into JSON format to the home directory of your machine
* Basic registration forms with base functionality, such as account creation, confirmation, modifying info and deleting account
* Authorization with two already existing accounts manifesting as roles, which are user and admin
* For user account please use login credentials:
* [ ]  email: user@user.com ; password: User123!
*  For admin account please use login credentials:
* [ ]  email: admin@admin.com ; password: Admin123!
*  The user can only access the home folder and the basic index view of all the people, but cannot perform operations on the data. (edit,create,delete), while the admin can do everything. Also any login is required to do anything besides view the index.
*  Validation for person attributes on create/edit (for example, a person’s name cannot contain numbers), as well as for account email and password
*  Password validation when creating a new user account

**Details:** <br>
URL link to see the web application: https://www.youtube.com/watch?v=u6byd9ZmMUo&feature=youtu.be <br>
The web application is usually located at https://localhost:5001/ after building the server, can also be port 5000
