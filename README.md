# HospitalProject-Team4

# Riverside Health Care
## 1) Shubham Patel
  - Feature One : Volunteer Recruitment
  1. Register 
  2. Login
  3. Adding New Volunteer 
  4. Updating Details of Volunteer
  5. Deleteing Any Volunteer
  6. Uploading a document: pdf or docx
  
  | File | Description | Author |
  | ------- | ----------- | ----- |
  | Data/HospitalProjectContext.cs | It's file for connecting to database and adding models for migration | Shubham Patel |
  | Models/VolunteerRecruitment.cs | This file contains the class of volunteer recruitment which defines the columns of the database . | Shubham Patel | 
  | Controllers/VolunteerRecruitment.cs | This file contains the code to handle all the CRUD operations and will guide the views to display | Shubham Patel |
  | Content/VolunteerFiles | This folder will hold all the resumes or CV uploaded by the volunteer. | Shubham Patel |
  | Web.Config | Modified this file for database configuration. | Shubham Patel |
  | Views/VounteerRecruitment/Add.cshtml | This file is the user interface where a user will register for becoming a volunteer. | Shubham Patel |
  | Views/VounteerRecruitment/List.cshtml | This file will list all the Volunteers which has links to update and delete. | Shubham Patel |
  | Views/VounteerRecruitment/Update.cshtml | This file will allow the volunteer to edit his details and upload document such as resume or CV. | Shubham Patel |
  | Views/VounteerRecruitment/DeleteConfirm.cshtml | This file is a confirmation file before deleting any volunteer. | Shubham Patel |
  
  - Feature Two : 
  1. Donation (CRUD - Add, view, update and delete Public View)

 
  | File | Description | Author |
  | ------- | ----------- | ----- |
  | Models/Donation.cs | This file contains the class of Donation which defines the columns of the database . | Shubham Patel | 
  | Controllers/Donation.cs | This file contains the code to handle all the CRUD operations of donation and will guide the views to display | Shubham Patel |


## Team Member - Navjot Gill(n01359105)
  - Feature One : Feedback 
  1. Adding New Feedback 
  2. View Feedback
  3. Updating Feedback
  4. Deleting Feedback
  
  | File | Description | Author |
  | ------- | ----------- | ----- |
  | Data/HospitalProjectContext.cs | This file is used to create connection with the database and adding models. | Navjot Gill |
  | Models/Feedback.cs | In this file columns of database are defined for feedback class . | Navjot Gill |
  | Controllers/FeedbackController.cs | This file holds all the methods that are required to perform CRUD operations. | Navjot Gill | 
  | Web.Config | This file is modified for the database configuration. | Navjot Gill |
  | Views/Feedback/AddFeedback.cshtml | This file is used to create user interface for user and using that they can send their feedback. | Navjot Gill | 
  | Views/Feedback/ListOfFeedbacks.cshtml | This file will display a list of all feedbacks sent by the users to the admin in a table format and each item will have links to view, delete and update. | Navjot Gill |
  | Views/Feedback/UpdateFeedback.cshtml | This file will allow the admin to edit the comment and upload it on the website. | Navjot Gill |
  | Views/Feedback/DeleteFeedback.cshtml | This file will allow the admin to delete the feedback permanently from the database. | Navjot Gill |
  | Views/Feedback/ShowFeedback.cshtml | This file will allow the admin to view the feedback details in non-editable format and it will also have links to delete and update the feedback . | Navjot Gill |
  
  
   - Feature Two : Contact Us 
  1. Creating New Question using this feature 
  2. View Contact Us
  3. Replying to Contact Us
  4. Deleting Contact Us
  5. Creating new category under which user can ask their questions
  6. View Category
  7. Updating Category
  8. Deleting Category
  
  | File | Description | Author |
  | ------- | ----------- | ----- |
  | Data/HospitalProjectContext.cs | This file is used to create connection with the database and adding models. | Navjot Gill |
  | Models/ContactUs.cs | In this file columns of database are defined for ContactUs class . | Navjot Gill |
  | Models/MessageCategory.cs | In this file columns of database are defined for MessageCategory class . | Navjot Gill |
  | Controllers/ContactUsController.cs | This file holds all the methods that are required to perform CRUD operations. | Navjot Gill | 
  | Controllers/MessageCategoryController.cs | This file holds all the methods that are required to perform CRUD operations. | Navjot Gill | 
  | Web.Config | This file is modified for the database configuration. | Navjot Gill |
  | Views/ContactUs/AddContactUs.cshtml | This file is used to create user interface for user and using that they can ask their question. | Navjot Gill | 
  | Views/ContactUs/ListContactUs.cshtml | This file will display a list of all questions asked by the users to the admin in a table format and each item will have links to view, delete and update. | Navjot Gill |
  | Views/ContactUs/UpdateContactUs.cshtml | This file will allow the admin to reply the question and send it. | Navjot Gill |
  | Views/ContactUs/DeleteContactUs.cshtml | This file will allow the admin to delete the question permanently from the database. | Navjot Gill |
  | Views/ContactUs/ShowContactUs.cshtml | This file will allow the admin to view the details of selected ContactUs in non-editable format and it will also have links to delete and reply the question . | Navjot Gill |
 | Views/MessageCategory/AddMessageCategory.cshtml | This file is used to create user interface for admin to add new categories under which user can ask questions. | Navjot Gill | 
  | Views/MessageCategory/ListMessageCategory.cshtml | This file will display a list of all categories to the admin in a table format and each item will have links to view, delete and update. | Navjot Gill |
  | Views/MessageCategory/UpdateMessageCategory.cshtml | This file will allow the admin to update the title of category. | Navjot Gill |
  | Views/MessageCategory/DeleteMessageCategory.cshtml | This file will allow the admin to delete the category from the database. | Navjot Gill |
  | Views/MessageCategory/ShowMessageCategory.cshtml | This file will allow the admin to view the details of selected category in non-editable format and it will also have links to delete and update the category . | Navjot Gill |
  
  ## Team Member - Bhanudai Khairwal
  - Feature One : Log In
  1. Register 
  2. Login
  3. Adding a new user
  4. List of users 
  5. Update the existing user
  6. Delete a user
  
  | File | Description | Author |
  | ------- | ----------- | ----- |
  | Data/HospitalProjectContext.cs | It's file for connecting to database and adding models for migration | Bhanudai Khairwal |
  | Models/AspNetUser.cs | This file contains the class of user details which defines the columns of the database . | Bhanudai Khairwal | 
  | Controllers/AspNetUserController.cs | For performing CRUD operation | Bhanudai Khairwal |
  | Web.Config | Modified this file for database configuration. | Bhanudai Khairwal |
  | Views/AspNetUser/Add.cshtml | This file is the user interface where a user will register. | Bhanudai Khairwal |
  | Views/AspNetUser/List.cshtml | This file will list all the users which has links to update and delete. | Bhanudai Khairwal |
  | Views/AspNetUSer/Update.cshtml | This file will allow the user to edit any changes he wants before registering . | Bhanudai Khairwal |
  | Views/AspNetUser/DeleteConfirm.cshtml | This file is a confirmation file before deleting any user. | Bhanudai Khairwal |
  
  ##Team Member: Rose Zhan

  Feature One: MVP
  1. Add page
  2. Update page
  3. Delete page
  4. Read page

  | File | Description | Author |
  | ------- | ----------- | ----- |
  | Models/Page.cs | This file contains the page class to define the Page table| Rose Zhan | 
  | Models/Navigation.cs | This file contains the navigcation class to define the navigation table| Rose Zhan | 
  | Controllers/NavPageController.cs | For performing CRUD operations | Rose Zhan |
  | Views/NavPages/AddNew.cshtml | This file is the user interface where a new page will be added. |Rose Zhan |
  | Views/NavPages/NavList.cshtml | This file will list all the users with admin privileges to update and delete. | Rose Zhan|
  | Views/NavPages/Show.cshtml | This file is for viewing individual pages. | Rose Zhan
  | Views/NavPages/Update.cshtml | This file will allow admins to make changes to existing pages | Rose Zhan |
  | Views/NavePages/ConfirmDelete.cshtml | This file is a confirmation file before deleting page| Rose Zhan|

  Feature Two: Newsroom
  1. Add new Articles and Authors 
  2. View Article
  3. Delete Articles and Authors
  4. Update Articles and Authors
  (Articles update, delete, and all Author CRUD in-progress)

  | File | Description | Author |
  | ------- | ----------- | ----- |
  | Models/Article.cs | This file contains the article class to define the Articles table| Rose Zhan | 
  | Models/Authors.cs | This file contains the authors class to define the Authors table| Rose Zhan | 
  | Controllers/ArticleController.cs | For performing CRUD operations for Article | Rose Zhan |
  | Views/NavPages/Add.cshtml | This file is the user interface where a new article will be added. |Rose Zhan |

   ##Team Member: Faith McQueen (n01237816)

  Feature One: Job Portal
  1. Public view of all job posts
  2. Admin view of all job posts
  3. Public view of individual job posts
  4. Admin view of individual job posts
  5. Delete job posts
  6. Update job posts
  7. Add new job posts
  8. Apply for job (public application form)

  | File | Description | Author |
  | ------- | ----------- | ----- |
  | Models/JobPosting.cs | This file contains the class to define the JobPostings table| Faith McQueen | 
  | Models/Application.cs | This file contains the class to define the Applications table| Faith McQueen | 
  | Models/Departments.cs | This file contains the class to define the Departments table | Faith McQueen |
  | Models/ViewModels/ListPosting.cs | The class that allows us to access the JobPostings and Departments tables | Faith McQueen |
  | Models/ViewModels/UpdatePosting.cs | The class that allows us to access the JobPostings, Departments and Applications tables | Faith McQueen |
  | Controllers/JobsController.cs | CRUD operations for the job portal | Faith McQueen |
  | Views/Jobs/AdminList.cshtml | An admin view of all current job posts with links to CRUD functions. | Faith McQueen |
  | Views/Jobs/AdminShow.cshtml | The admin view of individual job posts, with links to CRUD functions. | Faith McQueen |
  | Views/Jobs/Show.cshtml | A public view of an individual job post | Faith McQueen |
  | Views/Jobs/List.cshtml | A public list of current job postings. | RFaith McQueen |
  | Views/Jobs/New.cshtml | This is for admin to add new job oists. | Faith McQueen |
  | Views/Jobs/Update.cshtml | This file will allow admins to make changes to existing job posts | Faith McQueen |
  | Views/Jobs/Delete.cshtml | This file is a confirmation file before deleting a job post | Faith McQueen |

  Feature Two: Parking Spot Booking
  1. View all parking spaces 
  2. Book a parking space
  3. Admin view of all parking space bookings
  4. Update parking space bookings
  5. Delete parking space bookings

  | File | Description | Author |
  | ------- | ----------- | ----- |
  | Models/ParkingSpot.cs | The class that defines the ParkingSpots table | Faith McQueen |
  | Models/SpotBooking.cs | The class that defines the SpotBooking table | Faith McQueen |
  | Models/ViewModels/BookParkingSpot.cs | The class that allows us to access the ParkingSpot and SpotBooking tables | Faith McQueen |
  | Controllers/ParkingController.cs | CRUD functions for the parking feature | Faith McQueen |
  | Views/Parking/AdminList.cshtml | The admin view of all parking spot bookings | Faith McQueen |
  | Views/Parking/Book.cshtml | The interface for booking a parking space | Faith McQueen |
  | Views/Parking/Delete.cshtml | Confirmation of deletion of a parking space booking | Faith McQueen |
  | Views/Parking/Show.cshtml | A view of individual bookings with links to CRUD functions | Faith McQueen |
  | View/Parking/Update.cshtml | Interface for updating a parking space booking. | Faith McQuee |