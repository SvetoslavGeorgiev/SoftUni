# School Meal Ordering System - ASP.NET Core Application  


## :pencil: Project Description
School Meal Ordering System is Bulgarian School-Parent relation system for ordering school lunch for the children.


## :floppy_disk: Database Diagram

![databaseDiagram0](https://user-images.githubusercontent.com/54979873/212569224-b6b2ecea-f099-4be5-8627-4d31fcfa2d3c.png)






## :hammer: Used technologies
* [ASP.NET Core 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [ASP.NET Core Areas](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/areas?view=aspnetcore-6.0)
* [Entity Framework Core 6.0](https://learn.microsoft.com/en-us/ef/core/)
* [Bootstrap](https://github.com/twbs/bootstrap)
* [Limonte-sweetalert2](https://sweetalert2.github.io/)
* JavaScript
* [NUnit](https://github.com/nunit/nunit)
* [In-Memory Database](https://learn.microsoft.com/en-us/sql/relational-databases/in-memory-database?view=sql-server-ver16)
* [Moq](https://github.com/moq/moq4)
* HTML & CSS
* SOLID  PRINCIPLES AND MVC DESIGN PATTERN

## Images

### • Images used as a background are just for presentation purposes

#### • Home page for all users
![home page](https://user-images.githubusercontent.com/54979873/212572043-f803b4e5-1f4c-4846-8336-d33d1c26e19e.png)

#### • Login home page to choose to login as parent or school representative
![choose login page](https://user-images.githubusercontent.com/54979873/212572181-81ded331-c180-49dd-8822-4616ee7cdd41.png)

#### • Register home page to choose to register as parent or school representative
![choose register page](https://user-images.githubusercontent.com/54979873/212572189-215940a7-1234-45b1-9194-12dba73da092.png)

### School Area

#### • SignUp/SignIn Pages

<!--
![school register page](https://user-images.githubusercontent.com/54979873/212572260-a06ebaab-92af-441f-8c3a-f2d8c54b6f0d.png)
![login for schools](https://user-images.githubusercontent.com/54979873/212572243-9dda8807-2887-4702-ba48-7737caaa80f4.png)
-->

<p align="left">
<img height="350em" src="https://user-images.githubusercontent.com/54979873/212572260-a06ebaab-92af-441f-8c3a-f2d8c54b6f0d.png" align = "center"/>
<img height="350em" src="https://user-images.githubusercontent.com/54979873/212572243-9dda8807-2887-4702-ba48-7737caaa80f4.png" align = "center"/>
</p>

#### • School Area "ALL CHILDREN(ДЕЦАТА В УЧИЛИЩЕ)" page
In "ALL CHILDREN" page can be find the list of all children in that school for all parents users.

<p align="left">
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213566974-6c71ce79-55cc-481a-9719-2c8f542d7aa2.png" align = "center"/>
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213567025-9cb488a8-beda-4bb0-b093-e1124a4e1a7a.png" align = "center"/>
</p>

#### • School Area "MENU(МЕНЮ)" page
In "MENU(МЕНЮ)" page can be found the week lunch menu for the current child what it's parent have chosen, but can be only seen not deleted.

<p align="left">
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213568632-cf99c081-b9a5-446e-a74e-cc5242c65cbe.jpeg" align = "center"/>
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213569197-0c7cceea-a264-4391-84dd-ca33aed419b6.png" align = "center"/>
</p>


### Parent Area

#### • SignUp/SignIn Pages
<!--
![Parent register page](https://user-images.githubusercontent.com/54979873/212572265-ef644f0c-20b9-4183-af05-19c2f7a779d4.png)
![login for parents](https://user-images.githubusercontent.com/54979873/212572279-406b14d8-404a-45c5-b583-cfe650aac68b.png)
-->

<p align="left">
<img height="350em" src="https://user-images.githubusercontent.com/54979873/212572265-ef644f0c-20b9-4183-af05-19c2f7a779d4.png" align = "center"/>
<img height="350em" src="https://user-images.githubusercontent.com/54979873/212572279-406b14d8-404a-45c5-b583-cfe650aac68b.png" align = "center"/>
</p>

#### • Parent area home page
When is hovered "MY PROFILE(МОЯТ ПРОФИЛ)" is getting solid blue

<p align="left">
<img height="350em" width="500em" margin-bottom: 7px src="https://user-images.githubusercontent.com/54979873/213030720-248fb3e1-510b-4ff6-938f-f64f7658b92f.png" align = "center"/>
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213030958-c13a1e93-8e47-4960-a70b-1231ea233f38.jpeg" align = "center"/>
</p>

#### • Parent area "ADD CHILD(ДОБАВИ ДЕТЕ)" page
In the addChildViewModel all school names are loaded to the dropdown menu for the parent to choose in which of them is his child
<p align="left">
<img height="350em" width="400em" src="https://user-images.githubusercontent.com/54979873/213022476-442ef023-929f-4f98-802c-e5e1b5bdd417.png" align = "center"/>
<img height="350em" width="300em" src="https://user-images.githubusercontent.com/54979873/213019998-cd715fd8-2d14-4250-8223-f295d5173498.png" align = "center"/>
<img height="350em" width="300em" src="https://user-images.githubusercontent.com/54979873/213024230-95a77252-c0a2-4e2a-91e1-0497bc6bbb79.jpeg" align = "center"/>
</p>

#### • Parent area "MY CHILDREN(МОИТЕ ДЕЦА)" page
In "MY CHILDREN(МОИТЕ ДЕЦА)" page it can be found all childer added by current user. Each child view card contains: name, years and months old, school and grade of the child. Also there are 3 buttons for: editing, select menu and see choosen menus.

<p align="left">
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213031053-a79b2ca6-58c1-40b0-bb5e-7ffc049dcafc.png" align = "center"/>
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213032072-57ff4446-46b4-42cd-81d1-9f949992b6b9.png" align = "center"/>
</p>

#### • Parent area "EDIT CHILD(РЕДАКЦИЯ НА ДЕТЕ)" page
In "EDIT CHILD(РЕДАКЦИЯ НА ДЕТЕ)" page is edit form of the child and two buttons blue one for confirm and red for deleting. Also in the dropdown menu all school names a loaded if child is swiching schools.
<p align="left">
<img height="350em" width="400em" src="https://user-images.githubusercontent.com/54979873/213033770-75384aae-2ba3-4c25-bf16-de10abe4b4a3.jpeg" align = "center"/>
<img height="350em" width="300em" src="https://user-images.githubusercontent.com/54979873/213033884-0855094f-2000-4816-bf7d-62824731a947.png" align = "center"/>
<img height="350em" width="300em" src="https://user-images.githubusercontent.com/54979873/213033912-adb008dc-8475-4c39-bb18-eec73f9b059a.jpeg" align = "center"/>
</p>

 • For Deleting the child is popping up a window for confirmation or cancel
<p align="left">
<img height="350em" src="https://user-images.githubusercontent.com/54979873/213033925-9d14e77d-59a0-46b7-b3f5-f48a43f8b976.png" align = "center"/>
</p>

#### • Parent area "SELECT MENU(ИЗБЕРИ МЕНЮ)" page
In "SELECT MENU(ИЗБЕРИ МЕНЮ)" page is form for coosing a menu of soup, main dish and dessert for selected day of the week. Menu for each day of the week can be selected just once. If the parent decide someting else for already choosen day that menu can be deleted and re-selected again if the day is not come yet. Also in the form the parent can select from only 3 options for each dish which is been pre selected from the child's school.

<p align="left">
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213038199-1a62fc85-795d-4f61-895e-752b82867425.jpeg" align = "center"/>
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213038248-38ae5be6-7ff6-45b9-8549-2ba88219cbb2.png" align = "center"/>
</p>
<p align="left">
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213039408-621a6680-bccf-4444-83e8-4ea1dd388ab0.jpeg" align = "center"/>
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213039416-6a2f1f6a-e8d6-4c88-9f20-6bdfcf80e551.jpeg" align = "center"/>
</p>
<p align="left">
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213039430-2e71ffea-bedd-4fdb-9aeb-ce30720bdd39.jpeg" align = "center"/>
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213039437-885f02d3-64e8-409a-a7cb-305bdc231ab3.jpeg" align = "center"/>
</p>

#### • Parent area "SEE CHOSEN MENU(ВИЖ ИЗБРАНО МЕНЮ)" page
In "SEE CHOSEN MENU(ВИЖ ИЗБРАНО МЕНЮ)" page you can see for which day and what the parent is choosen for his child and can deleted if want.

<p align="left">
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213559811-59d897ce-eee0-4f85-9076-21a7fbbbc000.jpeg" align = "center"/>
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213559870-27a1f0e0-6710-4846-985e-81584de95125.png" align = "center"/>
</p>
<p align="left">
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213559910-8cb98447-7058-41f4-8144-cf6143e933e7.png" align = "center"/>
<img height="350em" width="500em" src="https://user-images.githubusercontent.com/54979873/213559963-998b8ec8-0d81-4c5e-a168-199dd0f5dddb.png" align = "center"/>
</p>

## Author
Svetoslav Georgiev
<br />
[LinkedIn](https://www.linkedin.com/in/svetoslav-georgiev-168932184/)


## :v: Show your opinion
Give a :star: if you like this project!
