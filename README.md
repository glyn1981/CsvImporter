##CSVReader Application

###Overview
The CSVReader application is a simple tool that reads vehicle data from a CSV file and uploads it to an Azure SQL Database. It is designed to be quick to run, with minimal configuration needed from the user.

###Prerequisites
A correctly formatted vehicles.csv file (see structure below)

###Getting Started
1. Prepare Your CSV File
Save your vehicles.csv file somewhere with an easy-to-type path, such as:

makefile
Copy
Edit
C:\vehicles.csv
Ensure the file is formatted with the following columns:

css
Copy
Edit
MAKE,MODEL,REG,COLOR
Example:

csv
Copy
Edit
Toyota,Corolla,AB12CDE,Red
Ford,Focus,CD34EFG,Blue
2. Run the Application
Navigate to the directory where the application is located and run:

bash
Copy
Edit
dotnet run
You’ll be prompted to enter the full path to the CSV file:

vbnet
Copy
Edit
Please enter the full path to your CSV file:
C:\vehicles.csv
Once entered, the application will read the file and attempt to upload the records to the database.

Database Setup
Using Azure SQL

The application is set to connect to a DB I created in Azure.
I have enabled public access, so I dont anticipate there being a problem, however

If the connection fails:

You can share your IP address with  (glyn_1981@hotmail.com) or Liam to whitelist it

OR use a local SQL Server instance as described below

Using a Local Database
If you prefer to run against a local database:

Create a new SQL Server database named vehicledb

Update the ConnectionStrings:DefaultConnection in appsettings.json to point to your local SQL Server

Run the following SQL to create the required table:


CREATE TABLE [dbo].[VEHICLES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MAKE] [nvarchar](50) NULL,
	[MODEL] [nvarchar](50) NULL,
	[REG] [nvarchar](10) NULL,
	[COLOR] [nvarchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

