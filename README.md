# WCAS (Web and Cloud Applications Security) Semester Assignment

## Requirements

Note: requirements are marked as complete/incomplete using the following md convention:
- [ ] means requirement not fulfilled
- [x] means requirement fulfilled

### Project Topic
- [x] Create an application using ASP.NET Core 3.X (or 2.X) on a topic of your choice, allowing users to perform CRUD operations on two related classed (ex: Product-Category). The application will be accessible only to authenticated users. The operations that the users will be able to perform will depend on their associated role(s).

### Authentication
- [ ] extend the default user class with at least one additional field;
- [x] change the minimum length of the password;
- [x] lock the user out for 30 minutes after 5 unsuccessful attempts;
- [x] the application will not allow unauthenticated users to register;

### Authorization
- [x] implement Role-base authorization;
- [x] use both imperative and declarative authorization;
- [x] note: your application should use at least two different roles;

### SSL
- [x] redirect HTTP requests to HTTPS;
- [x] send HTTP Strict Transport Security Protocol (HSTS) headers to clients;

### Other
- [x] your forms should be protected against Cross-Site Request Forgery (CSRF) attacks;

### Bonus
- [ ] deploy your application on Microsoft Azure (or on any other cloud computing platform). Note: please specify the address and provide a user account for accessing the application.

###  Project Submission
- file upload: upload an archive with your project
- inline text: specify the requirements that you have implemented and the degree of completion (you can copy & paste from above)

## Setup
1. Open ```BikeStore.sln``` in Visual Studio
2. In SQL Server Object Explorer create new Database ```BikeStore```. You might also need to update the connection string in ```appsettings.json```
3. Open Package Manager Console (Tools > NuGet Package Manager > Package Manager Console) and run ```Update-Database``` to run the default migration included
4. Hit ctrl-f5 to run

## Azure setup
1. TODO

## Basic use
A basic (unauthenticated) user can navigate through Products and Categories. From categories they can see all products in a category. They are unable to add users or enter the backend.

## Advanced use
There are 2 admin levels for authenticated users:
1. Product Read Only - can access the backend and see products but not add/edit/delete them. Can add new users.
2. Product Manager - can access the backend and add/edit/delete products. Can add new users.

Use the demo credentials provided to access the admin area (a link will automatically appear on navbar upon logging in):
1. Read-only access: ```viewerAdmin@admin.com``` ```$Testpassword1234```
2. Full access: ```editorAdmin@admin.com``` ```$Testpassword1234```