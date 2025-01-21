# User Scenarios for BookSphere

## **1. User Registration and Login**
### Scenario 1: Registering as a New User
- **Actor:** New user
- **Goal:** Create a new account on the platform.
- **Steps:**
  1. User navigates to the registration page.
  2. User fills out the registration form with required details (username, email, password).
  3. User submits the form.
  4. Backend validates the input and hashes the password.
  5. Backend stores the user data in the database.
  6. System displays a success message and redirects the user to the login page.

### Scenario 2: Logging In
- **Actor:** Registered user
- **Goal:** Log in to the platform.
- **Steps:**
  1. User navigates to the login page.
  2. User enters their email and password.
  3. Backend verifies the credentials (hashed password).
  4. Backend generates a JWT token and returns it to the frontend.
  5. User is redirected to the homepage with authenticated access.

---

## **2. Creating and Managing Book Clubs**
### Scenario 3: Creating a Book Club
- **Actor:** Registered user
- **Goal:** Start a new book club.
- **Steps:**
  1. User navigates to the "Create Book Club" page.
  2. User fills out the form with book club details (name, description, visibility: public/private).
  3. User submits the form.
  4. Backend saves the new book club and assigns the user as the owner.
  5. System displays the newly created book club on the user’s dashboard.

### Scenario 4: Editing Book Club Details
- **Actor:** Book club owner
- **Goal:** Update book club information.
- **Steps:**
  1. Owner navigates to the book club management page.
  2. Owner updates the club’s details (name, description, visibility).
  3. Backend validates the changes and updates the database.
  4. System confirms the update and refreshes the book club page.

---

## **3. Adding and Managing Books**
### Scenario 5: Adding a Book to a Club
- **Actor:** Club member with appropriate permissions
- **Goal:** Add a new book to the club’s library.
- **Steps:**
  1. User navigates to the book club’s library page.
  2. User clicks on the "Add Book" button.
  3. User fills out the book details (title, author, genre, description).
  4. Backend saves the book and associates it with the book club.
  5. System updates the library page with the new book.

### Scenario 6: Rating and Reviewing a Book
- **Actor:** Club member
- **Goal:** Provide feedback on a book.
- **Steps:**
  1. User navigates to the book’s detail page.
  2. User submits a rating (1-5 stars) and a review comment.
  3. Backend saves the rating and review.
  4. System updates the book’s rating and review section.

---

## **4. Starting and Participating in Discussions**
### Scenario 7: Starting a New Discussion
- **Actor:** Club member
- **Goal:** Initiate a discussion about a book.
- **Steps:**
  1. User navigates to the club’s discussion page.
  2. User clicks on "Start Discussion."
  3. User enters a title and description for the discussion.
  4. Backend saves the discussion and associates it with the club.
  5. System displays the new discussion in the discussion list.

### Scenario 8: Replying to a Discussion
- **Actor:** Club member
- **Goal:** Participate in an ongoing discussion.
- **Steps:**
  1. User navigates to the specific discussion page.
  2. User enters a reply in the comment box.
  3. Backend saves the reply and updates the discussion thread.
  4. System updates the thread with the new reply in real time.

---

## **5. Organizing and Managing Events**
### Scenario 9: Creating an Event
- **Actor:** Book club owner/admin
- **Goal:** Schedule a new event for the club.
- **Steps:**
  1. Admin navigates to the club’s event page.
  2. Admin clicks on "Create Event."
  3. Admin enters event details (name, date, location, max participants).
  4. Backend saves the event and associates it with the club.
  5. System displays the event in the club’s event calendar.

### Scenario 10: RSVP to an Event
- **Actor:** Club member
- **Goal:** Sign up for an event.
- **Steps:**
  1. User navigates to the event page.
  2. User clicks on "RSVP."
  3. Backend saves the user’s RSVP status in the database.
  4. System confirms the RSVP and updates the participant list.

---

## **6. Notifications**
### Scenario 11: Receiving Notifications
- **Actor:** Registered user
- **Goal:** Stay updated about club activities.
- **Steps:**
  1. Backend generates notifications for events such as new books, discussions, or events.
  2. System displays notifications in the user’s notification center.
  3. User clicks on a notification to view details.
  4. Backend marks the notification as read.

---

## **7. Managing User Profile**
### Scenario 12: Editing Profile Information
- **Actor:** Registered user
- **Goal:** Update personal details.
- **Steps:**
  1. User navigates to the profile settings page.
  2. User updates their details (e.g., username, email, profile picture).
  3. Backend validates and saves the changes.
  4. System confirms the update and refreshes the profile page.

