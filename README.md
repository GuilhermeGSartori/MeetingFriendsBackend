# MeetingFriendsBackend
ASP.NET Core Web API for the backend of the project made for Software Engeneering course of Universidade Federal do Rio Grande do Sul 

**The scope of this API is:**  
1) Create an InMemory code first database and server;
2) Seed the database with Users using the "usersSeed.json" file as reference;
3) Log-in of one of the Users (hardcoded, select the one to be logged by it's Id);
4) Create/Update events and store them in the database; 
5) Email the system members about new Events;
6) Enable for the frontend developer to use the APIs URL to get the necessary information from the backend (such as the data itself or feedbacks (using the TAR class));
7) Process information on the server not on the client side and minimize the number of necessary requests;

# To use it, it's necessary to:    
**Get the packages:**   
MailKit, EntityFramework, EntityFramework.InMemory, JsonNet.PrivateSettersContractResolvers, NewtonSoft.Json, and others...    
		
**Set** your email account in the appsettings.json file    

**Run it** using the IIS Express from Visual Studio 2017 and acess the localhost:50208/api URL using your favorite browser.

# For more Information:
Feel free to clone the repository and read the code, since it has commentary and it's easy to read, it can be easy to understand how to classes, methods, interfaces, services and controllers works.

This software was developed using ASP.NET Core SDK 1.1.2 (Microsoft does not support it anymore, it's an outdated SDK)
