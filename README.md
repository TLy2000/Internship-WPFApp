# Intern-UserInfo
### Author
------------
# Thinh

#### Date: 11/12/2020

#### Objective
	Take user input information, add input to SQL database, read from database.

#### Product
	WPF App WPFApp

### WPF Application:

#### Functions
	MainWindow.LoadUsers(), MainWindow.Button_Click(object, RoutedEventArgs), MainWindow.GetID, Person.cs, Helper.CnnVal, DataAccess.DatabaseActions, DataAccess.GetPeople(string, string), DatabaseAccess.WriteToDatabase(Person, string, string)
- MainWindow.LoadUsers(): this loads the datasource for the datagrid
- MainWindow.Button_Click: this method adds a new user everytime the button is clicked and updates the datasource for the datagrid
- MainWIndow.GetID: this method is to get the primary from the database so the user input can be added to the database
- Person.cs: this class sets up the person object
- Helper.CnnVal: this method returns the connection string to the database
- DataAccess.DatabaseActions: simply allows methods from DataAccess class to be run from MainWindow
- DataAccess.GetPeople: gets list of all person objects from the database
- DatabaseAccess.WriteToDatabase: writes user input to database

### References
- https://stackoverflow.com/questions/19772320/updating-wpf-datagrid-on-button-click
- https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.datagrid?view=net-5.0

### My Experiences
	My first WPF app and i had initially a different method to display entries from the database. However, a colleague had informed me on datagrid, which I had then decided to use. Creating the form was relatively simple enough, with a slight hiccup on refreshing the datagrid to reflect on any user inputs. Once again, I had used SQL injection and am currently looking to write my own stored procedures to use.

### New American Business Association 
