## CsvImporter
A simple console application that reads vehicle data from a CSV file and inserts it into an Azure SQL database.

### 🧰 Prerequisites
.NET SDK (version 6.0 or later recommended)

Access to an Azure SQL Database or a local SQL Server instance

A CSV file named vehicles.csv in a convenient location (e.g., C:\vehicles.csv)

## 📄 CSV Format
The CSV file should contain the following columns:

css
Copy
Edit
MAKE,MODEL,REG,COLOR
Example
csv
Copy
Edit
Toyota,Corolla,AB12CDE,Red
Ford,Focus,CD34EFG,Blue
Volkswagen,Golf,EF56HIJ,Black
🚀 How to Use
Clone the repository:

bash
Copy
Edit
git clone https://github.com/glyn1981/CsvImporter.git
cd CsvImporter
Build the application:

bash
Copy
Edit
dotnet build
Run the application:

bash
Copy
Edit
dotnet run
When prompted, enter the full path to your vehicles.csv file. For example:

vbnet
Copy
Edit
Please enter the full path to your CSV file:
C:\vehicles.csv
The application will then read the data from the file and attempt to save it to the database.

🛠️ Database Configuration
By default, the app uses the connection string in appsettings.json:

json
Copy
Edit
{
  "ConnectionStrings": {
    "DefaultConnection": "Your Azure or local SQL connection string"
  }
}
If you cannot connect to the provided Azure SQL database:

You may need to contact the owner (e.g., send your IP address to glyn_1981@hotmail.com) to have it whitelisted.

Alternatively, configure your own local SQL Server instance:

🧪 Create a Local Database
Create a database named vehicledb.

Execute the following SQL to create the required table:

sql
Copy
Edit
CREATE TABLE [dbo].[VEHICLES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	  NULL,
	  NULL,
	  NULL,
	  NULL,
PRIMARY KEY CLUSTERED (
	[ID] ASC
)
)
Update the appsettings.json file with the connection string to your local database.
