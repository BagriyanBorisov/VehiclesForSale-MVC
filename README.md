
# VehiclesForSale: A Platform for Buying and Selling Vehicles
VehiclesForSale is a web application built using ASP.NET Core that provides a convenient and user-friendly platform for buyers and sellers to interact in the process of buying and selling vehicles. Whether you're looking to purchase a new car or wanting to sell your old one, VehiclesForSale has you covered.


## Database Diagram
## Built With
* ASP.NET Core 6 MVC
* Entity Framework Core
* MSSQL Server
* Bootstrap
* Javascript
* AJAX
* jQuery



## Tested With
* NUnit
* Moq
* In-Memory Database
## Functionality
### For Guests

Guests are able to:
- Search for vehicles
- View vehicle listings

### For Users

Registered users have the following abilities:
- Add vehicles for sale
- Edit their listed vehicles
- Delete their listed vehicles
- Manage their user profile
- Create and manage a watchlist of favorite listings
- Access a view to see their listed vehicles

### For Administrators

Administrators possess the authority to:
- Perform administrative tasks
  - Create, Read, Update, and Delete (CRUD) operations for entities such as 
    - Makes 
    - Models
    - Extras
    - Types
- View registered users in the database
- Manage users and listings## Views
### Index
* Search for a specific vehicle

![IndexPage(Guest)](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/59d235e4-7734-436a-a1a6-4611e23081cf)

### Latest Vehicles
* View all currently listed vehicles
![LatestVehicles](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/644ad270-70b8-4b6d-830a-d249fb86663e)



### Pagination
* Pagination is added to each view with entities
![PaginationForEachPage](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/d59807b6-f06d-4ac7-8f76-698318aa1086)

### Register
![Register](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/3b5fbdba-8128-4bd4-957f-b719a2503d93)


### Login
![Login](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/ece7c0ab-0478-4077-8590-9ff271aa909f)

### Navbar after Logging in as User
![NavBarAfterLoggin](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/b7d9931b-fead-4041-86a1-dd2f02d0eda0)


### Details as not Owner
  - Ability to add the vehicle to their watchlist
  - Ability to see other vehicles listed by the same owner
![DetailsNotOwner](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/c43819dd-3679-4d18-860d-4389cb2b46c0)


### Details as Owner
  - Ability to Edit/Delete the enitity
  - Not able to add his vehicle to watchlist
![DetailsOwner](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/32421521-395e-46d3-abbc-a46fede1e8f8)


### Add Vehicle 
![AddVehicle](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/fd77d0e5-1b25-4983-bef8-4063a09eed15)

### Add Image
![AddImagesBeforeAddedImage](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/6c439180-52f7-431e-86ef-40baebb1b30c)

### Add Image after adding an image
![AddImagesAfterAddedImage](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/22ae33c6-e277-4e86-9dfa-eeaeb26d698b)

### Add Extra
![AddExtra](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/97e05d64-c547-4553-b5cf-28793aaeb542)

### Edit
 - Edit views are the same but with populated already data

### User Profile
![UserProfile](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/9db82571-fd2b-4299-9012-d71f27f16f2a)

### User Update Information
![UpdateUser](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/5a923d63-75d6-40cd-9852-9dfe1a26cbd4)

### User Update Password
![UpdatePassword](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/98b721aa-aec5-4852-80f6-f07ea1c62271)

### Logging as Admin
![AdminLogin](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/4310fed7-3ffb-440d-b512-fb95264036d3)

### Crud Tables
 #### Makes & Models
![MakesCrud](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/e5a4b4c6-f27b-4a0a-b6b8-9baf08e6a71d)

 #### Types 
![TypesCrud](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/dad6a496-ca38-4d1b-94d1-190ff20a6a18)

 #### Extras
![ExtrasCrud](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/5ab67751-f9d2-4836-9c5e-6eecd5d253de)

### Registered users
![UsersTableAdmin](https://github.com/BagriyanBorisov/VehiclesForSale-MVC/assets/108102199/29e4a708-2d36-479b-8b56-99ab084f136a)
