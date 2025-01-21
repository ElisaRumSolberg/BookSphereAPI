## Entitetsrelasjonsdiagram

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
