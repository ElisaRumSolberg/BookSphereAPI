## Project Planning Document: BookSphere


## 1. Project Objective
- **Goal:** Create a platform where book enthusiasts can come together, form book clubs, and discuss books.
- **Target Audience:** Book lovers, reading groups, and literary communities.

---

## 2. Features and Requirements
### User Management
- Users can sign up, log in, and edit their profiles.
- Users can join or leave book clubs.
- Passwords are securely hashed, and tokens are used for authentication.

### Book Club Management
- Users can create new book clubs.
- Club owners can edit club information and assign admin privileges to other users.
- Book clubs can be set as public or private.
- Relationships between users and book clubs are maintained (Owner, Admin, Member).

### Book Management
- Books can be added, edited, or removed from book clubs.
- Users can rate and review books.
- Books are categorized by genre or tags.

### Discussions and Interaction
- Club members can start discussions about books and reply to others.
- Notifications for new discussions or replies.
- Real-time updates for new discussions using SignalR.

### Events and Calendar
- Book clubs can organize events with a calendar view.
- Members can RSVP to events.
- Event roles: Owner, Admin, Participant.
- Events automatically archive after their scheduled time.

### Access Control
- Private book clubs require invitations to join.
- Role-based permissions for creating, editing, and deleting content.

### Notifications
- Users receive real-time notifications for updates in their book clubs, including new books, discussions, or events.

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
- **Dynamic UI:** Content adapts to user roles and states.

### Database
- **Type:** SQLite
- **Tables:**
  - Users
  - BookClubs
  - Books
  - UserBookClubRelations (Owner, Admin, Member)
  - Discussions
  - Replies
  - Events
  - Notifications
  - EventUserRelations (Owner, Admin, Participant)

---

## 4. User Scenarios
1. **User Registration**
   - Users fill out a form to register on the platform, providing a hashed password.
2. **Creating a Book Club**
   - Users create a book club and enter its details.
3. **Adding Books**
   - Users add books to a book club, categorized by genre or tags.
4. **Starting a Discussion**
   - Users start discussions in book clubs and post replies, with real-time updates.
5. **Organizing Events**
   - Users schedule events for their book clubs, set roles, and invite members.

---

## 5. System Architecture
### Layered Architecture
1. **Presentation Layer:** Frontend (HTML, CSS, JavaScript)
2. **Business Logic Layer:** Backend API
3. **Data Access Layer:** Database operations

---

## 6. Diagrams
1. **Flow Diagram:**
   - User registration and login flows.
2. **System Diagram:**
   - Communication between frontend and backend.
3. **ERD (Entity-Relationship Diagram):**
   - Tables and their relationships (e.g., UserBookClubRelations, EventUserRelations).
4. **Sequence Diagrams:**
   - Actions triggered when a user creates a book club or RSVPs to an event.

---

## 7. Project Structure
```
BookSphereAPI/
├── backend/
│   ├── Controllers/
│   ├── Models/
│   ├── DTOs/
│   ├── Services/
│   ├── Migrations/
│   └── BookSphereAPI.csproj
├── frontend/
│   ├── index.html
│   ├── style.css
│   ├── app.js
│   └── assets/
├── docs/
│   ├── planning.md
│   ├── diagrams/
│   └── user_scenarios.md
├── appsettings.json
├── Program.cs
└── BookSphereAPI.sln
```

---

## 8. Roadmap
### 1. **Backend Development**
- Create database models and DTOs for users, book clubs, books, events, and notifications.
- Develop CRUD endpoints for all entities.
- Implement JWT-based authentication.
- Add real-time notifications with SignalR.

### 2. **Frontend Design**
- Design a responsive UI for user roles (guest, member, admin).
- Integrate with backend APIs for dynamic content.
- Implement a calendar view for events.

### 3. **Security Enhancements**
- Hash passwords and validate input data.
- Use HTTPS for secure data transfer.

### 4. **Testing and Deployment**
- API testing with Postman.
- Frontend-backend integration testing.
- Deploy on platforms like GitHub and Azure.

### 5. **Enhancements**
- Export event calendars to platforms like Google Calendar.
- Add an admin dashboard for managing users and content.
- Introduce advanced search and filtering options for books and events.

---

## 9. Routing
We follow the structured URL routing principle using the format:
- /Area/Controller/Action/Parameter

**Examples:**
- BookClubController: `api.com/BookClub/...`
- UserController: `api.com/User/...`
- EventController: `api.com/Event/...`

### Endpoints
1. **BookClubController:**
   - `GET /BookClub`: Fetch public book clubs (or private if authorized).
   - `POST /BookClub`: Create a new book club.
   - `PATCH /BookClub/{id}`: Update book club details.
   - `DELETE /BookClub/{id}`: Delete a book club.

2. **BookController:**
   - `GET /Book`: List books in a specific book club.
   - `POST /Book`: Add a book.
   - `PATCH /Book/{id}`: Update book details.
   - `DELETE /Book/{id}`: Remove a book.

3. **DiscussionController:**
   - `GET /Discussion`: List discussions in a book club.
   - `POST /Discussion`: Start a discussion.
   - `POST /Discussion/{id}/Reply`: Reply to a discussion.

4. **EventController:**
   - `GET /Event`: Fetch events (public or user-specific).
   - `POST /Event`: Create a new event.
   - `PATCH /Event/{id}`: Update event details.
   - `DELETE /Event/{id}`: Delete an event.
   - `POST /Event/{id}/RSVP`: RSVP to an event.

5. **UserController:**
   - `POST /User/Login`: Log in a user.
   - `POST /User/Register`: Register a user.
   - `GET /User/Profile`: Fetch profile details.
   - `PATCH /User/Profile`: Update profile.

---

