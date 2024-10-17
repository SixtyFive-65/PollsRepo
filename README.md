# Polling Website

## Installation

Use Visual Studio to clone the below repo.

1. Clone the repository:

   git clone https://github.com/SixtyFive-65/PollsRepo.git
   
## Usage

Allows users to create Polls and view existing polls


## Configuration

1.SQL Express

-Install SQL Express using below link if not already installed.

https://download.microsoft.com/download/5/1/4/5145fe04-4d30-4b85-b0d1-39533663a2f1/SQL2022-SSEI-Expr.exe

-Follow the instructions to complete the installation. NB : Keep your server name and credentials.

2.Visual Studio

-Open The API solution in Visual studio and open the Appsettings.json file. NB change the SQL server connection string to your own credentials
   or remove the (user and password) creds if you are using windows auth.
-Click Tools->Nuget package Manager -> Package Manager Console.
-Ensure the API is set to the start up project
-Run the below EF migration commands one after the other to create the databases required for the application.
 *-update-database -context "AuthDbContext"
 *-update-database -context "PollingDbContext"


## Testing 

 Testing hasn't been fully implemented due to time constrait
 
 ## Support

For any questions or issues, please [open an issue](https://github.com/SixtyFive-65/PollsRepo) on GitHub.
Or Email 45sabelo@gmail.com 


