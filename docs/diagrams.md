

---

## Entity-Relationship Diagram (ERD)

```mermaid
erDiagram
    Users {
        int UserId PK
        string UserName
        string Email
        string HashedPassword
    }
    BookClubs {
        int BookClubId PK
        string Name
        string Description
        string Visibility
    }
    Books {
        int BookId PK
        string Title
        string Author
        string Genre
        int BookClubId FK
    }
    Discussions {
        int DiscussionId PK
        string Title
        string Content
        int BookClubId FK
    }
    Events {
        int EventId PK
        string Name
        datetime Date
        int MaxParticipants
        int BookClubId FK
    }
    Notifications {
        int NotificationId PK
        string Message
        int UserId FK
    }
    UserBookClubRelations {
        int UserId FK
        int BookClubId FK
        string Role
    }
    EventUserRelations {
        int UserId FK
        int EventId FK
        string Role
    }

    %% Relationships
    Users ||--o{ UserBookClubRelations : "has"
    BookClubs ||--o{ UserBookClubRelations : "includes"
    BookClubs ||--o{ Books : "contains"
    BookClubs ||--o{ Discussions : "has"
    BookClubs ||--o{ Events : "organizes"
    Users ||--o{ Notifications : "receives"
    Users ||--o{ EventUserRelations : "participates"
    Events ||--o{ EventUserRelations : "manages"
```

---

## Default Route - Static File Service

```mermaid
sequenceDiagram
    participant httpRequest
    participant ApiDefaultRoute
    participant StaticFolder

    httpRequest ->>+ ApiDefaultRoute: GET /
    ApiDefaultRoute ->>+ StaticFolder: Find index.html
    StaticFolder -->>- ApiDefaultRoute: Return index.html
    ApiDefaultRoute -->>- httpRequest: Serve index.html
```

**Description:**
- **GET Request:** The user sends a `GET` request to the `/` route.
- **Static File:** The API retrieves the `index.html` file from the static folder and serves it to the browser.

---

## Register User

```mermaid
sequenceDiagram
    actor AnonymousUser
    participant RegistrationController
    participant RegistrationService
    participant UserDatabase

    AnonymousUser ->>+ RegistrationController: POST /Register (formData)
    RegistrationController ->>+ RegistrationService: Validate input fields and hash password
    alt Validation succeeds
        RegistrationService ->> UserDatabase: Insert new hashed user data
        UserDatabase -->> RegistrationService: OK (User created)
        RegistrationService -->> RegistrationController: Success response
        RegistrationController -->> AnonymousUser: HTTP 201 Created
    else Validation fails
        RegistrationService -->>- RegistrationController: Validation error
        RegistrationController -->>- AnonymousUser: HTTP 400 Bad Request
    end
```

**Description:**
- **User Input:** The user fills in the registration form and submits it.
- **Validation:** The `RegistrationController` checks for completeness and validity of data, including password hashing.
- **Success:** If valid, user data is stored in the database, and an HTTP 201 response is returned.
- **Failure:** If invalid, an HTTP 400 response is returned with an error message.

---

## Homepage with Token Validation

```mermaid
sequenceDiagram
    actor User
    participant View(Index)
    participant AuthService
    participant TokenValidator
    participant UserDatabase

    User ->>+ View(Index): Open Index Page
    View(Index) ->>+ AuthService: Check token in cookies
    AuthService ->>+ TokenValidator: Validate token
    TokenValidator ->>+ UserDatabase: Retrieve user details
    UserDatabase -->>- TokenValidator: User details (valid/invalid)
    TokenValidator -->>- AuthService: Validation result
    alt Token is valid
        AuthService -->> View(Index): User authenticated
        View(Index) -->> User: Show personalized content
    else Token is invalid or missing
        AuthService -->> View(Index): User not authenticated
        View(Index) ->>+ User: Display login/register options
    end
```

**Description:**
- **Page Load:** The user opens the homepage, and the system checks for an authentication token.
- **Token Validation:** If a valid token exists, personalized content is displayed.
- **Fallback:** If the token is invalid or missing, login/registration options are shown.

---

## User Login

```mermaid
sequenceDiagram
    actor User
    participant Frontend
    participant LoginController
    participant LoginService
    participant UserDatabase

    User ->>+ Frontend: Fill Login Form (email, password)
    Frontend ->>+ LoginController: POST /User/Login
    LoginController ->>+ LoginService: Validate credentials
    LoginService ->>+ UserDatabase: Find user by email
    UserDatabase -->>- LoginService: User found (hashed password)
    LoginService -->> LoginController: Compare password (valid/invalid)
    alt Credentials are valid
        LoginController ->> Frontend: Return JWT Token
        Frontend -->> User: Login successful
    else Credentials are invalid
        LoginController ->> Frontend: Return error message
        Frontend -->> User: Display invalid credentials
    end
```

**Description:**
- **Login Request:** The user submits their email and password through the login form.
- **Validation:** The `LoginController` validates the credentials against the database.
- **Success:** If valid, a JWT token is generated, granting access.
- **Failure:** An error message is returned if the credentials are invalid.

---


## Create Book Club

```mermaid
sequenceDiagram
    actor User
    participant Frontend
    participant BookClubController
    participant BookClubService
    participant Database

    User ->>+ Frontend: Fill Book Club Form (name, description, visibility)
    Frontend ->>+ BookClubController: POST /BookClub
    BookClubController ->>+ BookClubService: Validate Input Data
    alt Validation Succeeds
        BookClubService ->>+ Database: Save Book Club
        Database -->>- BookClubService: Club Created
        BookClubService -->> BookClubController: Success Response
        BookClubController -->> Frontend: HTTP 201 Created (Book Club Created)
        Frontend -->> User: Show Success Message
    else Validation Fails
        BookClubService -->> BookClubController: Validation Error
        BookClubController -->> Frontend: HTTP 400 Bad Request (Error Message)
        Frontend -->> User: Show Validation Errors
    end
```

**Description**
- **Form Submission:**
  - The user fills out a form with the book club's name, description, and visibility (public or private).
- **Validation:**
  - The `BookClubController` receives the form data and forwards it to the `BookClubService` for validation.
  - All required fields are checked for presence and correctness.
- **Successful Scenario:**
  - If validation succeeds:
    - The book club information is saved to the database.
    - The user receives a success message (HTTP 201 Created) confirming the club creation.
- **Failed Scenario:**
  - If validation fails:
    - An error message is returned (HTTP 400 Bad Request) indicating the issues.
    - The user is prompted to correct the errors.

---

## Start Discussion

```mermaid
sequenceDiagram
    actor User
    participant Frontend
    participant DiscussionController
    participant DiscussionService
    participant Database

    User ->>+ Frontend: Fill Discussion Form (title, content, bookClubId)
    Frontend ->>+ DiscussionController: POST /Discussion
    DiscussionController ->>+ DiscussionService: Validate Input Data
    alt Validation Succeeds
        DiscussionService ->>+ Database: Save Discussion
        Database -->>- DiscussionService: Discussion Created
        DiscussionService -->> DiscussionController: Success Response
        DiscussionController -->> Frontend: HTTP 201 Created (Discussion Started)
        Frontend -->> User: Show Success Message
    else Validation Fails
        DiscussionService -->> DiscussionController: Validation Error
        DiscussionController -->> Frontend: HTTP 400 Bad Request (Error Message)
        Frontend -->> User: Show Validation Errors
    end
```

**Description**
- **Form Submission:**
  - The user submits a form with the discussion title, content, and the associated book club ID.
- **Validation:**
  - The `DiscussionController` forwards the form data to the `DiscussionService` for validation.
  - Checks include ensuring all required fields (title, content, bookClubId) are complete.
- **Successful Scenario:**
  - If validation succeeds:
    - The discussion is saved to the database.
    - A success message is returned (HTTP 201 Created) confirming the discussion has been started.
- **Failed Scenario:**
  - If validation fails:
    - An error message is returned (HTTP 400 Bad Request) indicating missing or incorrect information.
    - The user is shown validation errors and asked to make corrections.

---

## RSVP to Event

```mermaid
sequenceDiagram
    actor User
    participant Frontend
    participant EventController
    participant EventService
    participant Database

    User ->>+ Frontend: Click RSVP Button
    Frontend ->>+ EventController: POST /Event/{id}/RSVP
    EventController ->>+ EventService: Validate RSVP Request
    alt Validation Succeeds
        EventService ->>+ Database: Save RSVP Record
        Database -->>- EventService: RSVP Saved Successfully
        EventService -->> EventController: Success Response
        EventController -->> Frontend: HTTP 201 Created (RSVP Confirmed)
        Frontend -->> User: Show RSVP Confirmation Message
    else Validation Fails
        EventService -->> EventController: Validation Error
        EventController -->> Frontend: HTTP 400 Bad Request (Error Message)
        Frontend -->> User: Show Validation Errors
    end
```

**Description**
- **User Action:**
  - The user clicks the RSVP button for an event.
- **Request Handling:**
  - The `EventController` processes the RSVP request and forwards it to the `EventService` for validation.
- **Successful Scenario:**
  - If validation succeeds:
    - The RSVP record is saved to the database.
    - A success message (HTTP 201 Created) confirms the RSVP.
    - The user sees a confirmation message on the frontend.
- **Failed Scenario:**
  - If validation fails:
    - An error message (HTTP 400 Bad Request) is returned, detailing the issues.
    - The user is prompted to correct the errors and try again.

---


## Send Notification

```mermaid
sequenceDiagram
    participant System
    participant NotificationController
    participant NotificationService
    participant UserDatabase
    participant NotificationQueue
    participant User

    System ->>+ NotificationController: Trigger Notification Creation
    NotificationController ->>+ NotificationService: Create Notification
    NotificationService ->>+ UserDatabase: Retrieve Relevant Users
    UserDatabase -->>- NotificationService: List of Users
    NotificationService ->>+ NotificationQueue: Add Notifications to Queue
    NotificationQueue -->>- NotificationService: Notifications Queued
    alt Notification Sent
        NotificationQueue ->>+ User: Send Notification (Email/Push)
        User -->>- NotificationQueue: Acknowledge Notification
    else Notification Failed
        NotificationQueue -->> NotificationService: Error Sending Notification
    end
    NotificationService -->> NotificationController: Success/Failure Response
    NotificationController -->> System: Notification Process Completed
```

**Description**  
- **Notification Creation:**
  - The system initiates a notification for a specific event (e.g., a new event creation or a discussion start).
- **Identifying Recipients:**
  - The `NotificationService` queries the database to identify the users who should receive the notification.
- **Queuing Notifications:**
  - Notifications are added to a background queue for processing.
- **Sending Notifications:**
  - **Successful Scenario:** Notifications are sent to users via email or push notifications.
  - **Failed Scenario:** If an error occurs during delivery, it is logged, and error-handling is triggered.
- **Outcome:**
  - The system records whether notifications were successfully delivered or failed, supporting auditing and retry mechanisms.

---

## Adding a Book

```mermaid
sequenceDiagram
    actor User
    participant Frontend
    participant BookController
    participant BookService
    participant Database

    User ->>+ Frontend: Fill Book Form (title, author, genre)
    Frontend ->>+ BookController: POST /Book
    BookController ->>+ BookService: Validate Input Data
    alt Validation Succeeds
        BookService ->>+ Database: Save Book Record
        Database -->>- BookService: Book Added Successfully
        BookService -->> BookController: Success Response
        BookController -->> Frontend: HTTP 201 Created (Book Added)
        Frontend -->> User: Show Success Message
    else Validation Fails
        BookService -->> BookController: Validation Error
        BookController -->> Frontend: HTTP 400 Bad Request (Error Message)
        Frontend -->> User: Show Validation Errors
    end
```

**Description**
- **Adding a Book:**
  - The user fills out a form with book details (e.g., title, author, genre) and submits it.
- **Validation:**
  - The `BookController` forwards the data to `BookService` for validation.
- **Successful Scenario:**
  - Valid data is saved in the database.
  - The user receives a success message (HTTP 201 Created).
- **Failed Scenario:**
  - If there are errors (e.g., missing fields), an error message (HTTP 400 Bad Request) is returned.
  - The user is prompted to correct their input.

---

## Delete Book

```mermaid
sequenceDiagram
    actor User
    participant Frontend
    participant BookController
    participant BookService
    participant Database

    User ->>+ Frontend: Click Delete Button
    Frontend ->>+ BookController: DELETE /Book/{id}
    BookController ->>+ BookService: Validate Book ID
    alt Validation Succeeds
        BookService ->>+ Database: Delete Book Record
        Database -->>- BookService: Book Deleted
        BookService -->> BookController: Success Response
        BookController -->> Frontend: HTTP 200 OK (Book Deleted)
        Frontend -->> User: Show Success Message
    else Validation Fails
        BookService -->> BookController: Validation Error
        BookController -->> Frontend: HTTP 400 Bad Request (Error Message)
        Frontend -->> User: Show Validation Errors
    end
```

**Description**
- **User Action:**
  - The user clicks the delete button for a specific book.
- **Process:**
  - The `BookController` handles the `DELETE` request and forwards it to the `BookService`.
  - The `BookService` validates the book ID and processes the deletion.
- **Successful Scenario:**
  - The book is deleted from the database.
  - The user receives a success message (HTTP 200 OK).
- **Failed Scenario:**
  - If the book does not exist or an error occurs, an error message (e.g., HTTP 404 Not Found or HTTP 400 Bad Request) is returned.

---

## Edit Book

```mermaid
sequenceDiagram
    actor User
    participant Frontend
    participant BookController
    participant BookService
    participant Database

    User ->>+ Frontend: Edit Book Details (title, author, genre)
    Frontend ->>+ BookController: PATCH /Book/{id}
    BookController ->>+ BookService: Validate Input Data
    alt Validation Succeeds
        BookService ->>+ Database: Update Book Record
        Database -->>- BookService: Book Updated Successfully
        BookService -->> BookController: Success Response
        BookController -->> Frontend: HTTP 200 OK (Book Updated)
        Frontend -->> User: Show Success Message
    else Validation Fails
        BookService -->> BookController: Validation Error
        BookController -->> Frontend: HTTP 400 Bad Request (Error Message)
        Frontend -->> User: Show Validation Errors
    end
```

**Description**
- **User Action:**
  - The user edits book details (e.g., title, author, genre) via a form and submits it.
- **Process:**
  - The `BookController` processes the `PATCH` request and sends it to `BookService`.
  - The `BookService` validates the input data and updates the record in the database.
- **Successful Scenario:**
  - The book record is updated, and the user receives a success message (HTTP 200 OK).
- **Failed Scenario:**
  - If validation fails or the book does not exist, an error message (HTTP 400 Bad Request) is returned.
  - The user is prompted to correct their input.

---

## Search & Filter

```mermaid
sequenceDiagram
    actor User
    participant Frontend
    participant SearchController
    participant SearchService
    participant Database

    User ->>+ Frontend: Enter Search Query or Filter Options
    Frontend ->>+ SearchController: GET /Search?query={query}&filter={filter}
    SearchController ->>+ SearchService: Process Search and Filter
    SearchService ->>+ Database: Fetch Results Matching Query and Filter
    Database -->>- SearchService: Matching Results
    SearchService -->> SearchController: Return Filtered Results
    SearchController -->> Frontend: HTTP 200 OK (Filtered Results)
    Frontend -->> User: Display Search Results
```

**Description**  
- **Search and Filtering:**
  - The user enters a query (e.g., book title, author) or selects filtering options (e.g., genre, date) in the search bar.
- **API Request:**
  - The frontend sends a `GET` request to the API with the query and filter parameters.
- **Processing Results:**
  - The API processes the request by querying the database for matching results.
  - The results are filtered based on the query and returned to the frontend.
- **Displaying Results:**
  - The frontend displays the search results to the user.

---

## BookSphere System Architecture Diagram

```mermaid
graph TD
    subgraph Frontend
        F1[User Interface]
        F2[API Requests]
    end
    subgraph Backend
        B1[Controllers]
        B2[Services]
        B3[Authentication]
        subgraph DataAccessLayer
            Q1[Database Queries]
            subgraph Database
                D1[Users Table]
                D2[BookClubs Table]
                D3[Books Table]
                D4[Discussions Table]
                D5[Events Table]
                D6[Notifications Table]
            end
        end
    end

    F1 --> F2
    F2 --> B1
    B1 --> B2
    B2 --> B3
    B2 --> Q1
    Q1 --> D1
    Q1 --> D2
    Q1 --> D3
    Q1 --> D4
    Q1 --> D5
    Q1 --> D6
    D1 --> Q1
    D2 --> Q1
    D3 --> Q1
    D4 --> Q1
    D5 --> Q1
    D6 --> Q1
    B2 --> B1
    B1 --> F2
    F2 --> F1
```

**Description**  
1. **Frontend:**
   - **HTML/CSS/JavaScript:** Responsible for rendering the user interface.
   - **API Requests:** Handles communication with the backend for data retrieval and updates.
   - **Responsive Design:** Ensures the application is accessible on desktop and mobile devices.
2. **Backend:**
   - **ASP.NET Core Web API:** Manages the business logic and serves as the main API layer.
   - **Controllers:** Processes incoming requests and routes them to appropriate services.
   - **Services:** Contains the core business logic, including validations and computations.
   - **Authentication:** Manages secure user sessions using JWT (JSON Web Tokens).
3. **Database:**
   - **SQLite:** Serves as the primary data store.
   - **Tables:** Includes Users, BookClubs, Books, Events, Discussions, and Notifications for structured data storage and retrieval.

---

## User Roles and Authorization Diagram

```mermaid
graph TD
    User[User] -->|Belongs to| Role[Role]
    Role -->|Has permission for| Actions[Actions]

    Admin[Admin Role]
    Member[Member Role]
    Guest[Guest Role]

    Role --> Admin
    Role --> Member
    Role --> Guest

    Admin -->|Can create/edit/delete| BookClubs
    Admin -->|Can create/edit/delete| Events
    Admin -->|Can manage| Users
    Member -->|Can join| BookClubs
    Member -->|Can RSVP to| Events
    Member -->|Can start| Discussions
    Guest -->|Can view public| BookClubs
    Guest -->|Cannot join private| BookClubs
```

**Description**  
- **Roles and Permissions:**
  - **Admin:** Has full access, including creating, editing, deleting book clubs and events, and managing users.
  - **Member:** Can join book clubs, RSVP to events, and start discussions.
  - **Guest:** Can view public book clubs but cannot join private ones.

---

## Notification Workflow

```mermaid
sequenceDiagram
    participant System
    participant NotificationService
    participant NotificationQueue
    participant UserDevice

    System ->>+ NotificationService: Create Notification
    NotificationService ->>+ NotificationQueue: Add to Queue
    NotificationQueue ->>+ UserDevice: Send Notification (Email/Push)
    UserDevice -->>- NotificationQueue: Acknowledge Delivery
    alt Notification Sent
        NotificationQueue ->> NotificationService: Success
    else Notification Failed
        NotificationQueue ->> NotificationService: Error
    end
```

**Description**  
- **Notification Creation:**  
  - Notifications are triggered by specific events like new discussions or event updates.
- **Queuing and Delivery:**  
  - Notifications are queued and sent to users via email or push notifications.
- **Status Logging:**  
  - Success or failure is logged for auditing and retry purposes.

---

## Performance and Logging Diagram

```mermaid
sequenceDiagram
    participant API
    participant LoggingService
    participant MonitoringTool
    participant Database

    API ->>+ LoggingService: Log Request Details
    LoggingService ->> MonitoringTool: Send Logs to Monitoring
    API ->>+ Database: Query Execution
    Database -->> API: Query Results
    API ->> LoggingService: Log Response Time
    MonitoringTool -->> Admin: Display Performance Metrics
```

**Description**  
- **Request Logging:**  
  - Each API request and its details are logged.
- **Performance Monitoring:**  
  - Logs are sent to monitoring tools for performance analysis and debugging.

---

## Admin Panel Workflow

```mermaid
sequenceDiagram
    actor Admin
    participant AdminFrontend
    participant AdminController
    participant AdminService
    participant Database

    Admin ->>+ AdminFrontend: Login to Admin Panel
    AdminFrontend ->>+ AdminController: GET /Admin/Dashboard
    AdminController ->>+ AdminService: Fetch Admin Data
    AdminService ->>+ Database: Query Admin Stats
    Database -->> AdminService: Return Data
    AdminService -->> AdminController: Return Admin Dashboard Data
    AdminController -->> AdminFrontend: Render Dashboard
    AdminFrontend -->> Admin: Show Admin Dashboard
```

**Description**  
- **Admin Actions:**  
  - The admin accesses the dashboard to view statistics and manage the platform.
- **Data Retrieval:**  
  - Relevant data is fetched from the database and displayed on the admin dashboard.

---

## API Call Flow

```mermaid
sequenceDiagram
    actor User
    participant Frontend
    participant APIController
    participant ServiceLayer
    participant Database

    User ->>+ Frontend: Initiate API Call
    Frontend ->>+ APIController: API Request
    APIController ->>+ ServiceLayer: Process Request
    ServiceLayer ->>+ Database: Execute Query
    Database -->>- ServiceLayer: Query Results
    ServiceLayer -->>- APIController: Processed Data
    APIController -->> Frontend: API Response
    Frontend -->> User: Show Results
```

**Description**  
- **Request Handling:**  
  - The frontend sends API requests to the backend, which processes them in the service layer.
- **Database Interaction:**  
  - The service layer interacts with the database for data retrieval or updates.
- **Response Delivery:**  
  - Processed results are returned to the frontend, which displays them to the user.

---

   
