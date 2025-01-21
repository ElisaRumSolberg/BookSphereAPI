# Project Planning Document: BookSphere

## 1. Project Objective
- **Goal:** Create a platform where book enthusiasts can come together, form book clubs, and discuss books.
- **Target Audience:** Book lovers, reading groups, and literary communities.

---

## 2. Features and Requirements
### User Management
- Users can sign up, log in, and edit their profiles.
- Users can join or leave book clubs.

### Book Club Management
- Users can create new book clubs.
- Club owners can edit club information and assign admin privileges to other users.

### Book Management
- Books can be added, edited, or removed from book clubs.

### Discussions and Interaction
- Club members can start discussions about books and reply to others.

### Access Control
- Book clubs can be set as private or public.

---

## 3. Technical Requirements
### Backend
- **Language:** C#
- **Framework:** ASP.NET Core Web API
- **ORM:** Entity Framework Core (with SQLite)
- **Authentication:** JWT-based authentication

### Frontend
- **Technologies:** HTML, CSS, JavaScript 
- **Responsive Design:** Compatible with mobile and desktop devices.

### Database
- **Type:** SQLite
- **Tables:**
  - Users
  - BookClubs
  - Books
  - UserBookClubRelation
  - Discussions
  - Replies

---

## 4. User Scenarios
1. **User Registration**
   - Users fill out a form to register on the platform.
2. **Creating a Book Club**
   - Users create a book club and enter its details.
3. **Adding Books**
   - Users add books to a book club.
4. **Starting a Discussion**
   - Users start discussions in book clubs and post replies.

---

## 5. System Architecture
### Layered Architecture
1. **Presentation Layer:** Frontend (HTML, CSS, JavaScript)
2. **Business Logic Layer:** Backend API
3. **Data Access Layer:** Database operations

---

## 6. Diagrams
1. **Flow Diagram**
   - User registration and login flows.
2. **System Diagram**
   - Communication between frontend and backend.
3. **ERD (Entity-Relationship Diagram)**
   - Tables and their relationships.
4. **Sequence Diagrams**
   - Actions triggered when a user creates a book club.

---

## 7. Project Structure
```
BookSphereAPI/
├── backend/
│   ├── Controllers/
│   ├── Models/
│   ├── Migrations/
│   └── BookSphereAPI.csproj
├── frontend/
│   ├── index.html
│   ├── style.css
│   ├── app.js
│   └── assets/
├── docs/
│   ├── planning.md
│   └── diagrams/
├── appsettings.json
├── Program.cs
└── BookSphereAPI.sln
```

---

## 8. Roadmap
1. **Backend Development**
   - Create database models.
   - Develop CRUD endpoints.
2. **Frontend Design**
   - Responsive design with HTML and CSS.
   - Backend integration (API requests).
3. **Authentication**
   - User registration, login, and JWT-based session management.
4. **Testing and Deployment**
   - API testing (Postman).
   - Frontend-backend integration.
   - Deployment on platforms like GitHub and Azure.

