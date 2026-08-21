# RepFlow Architecture

# 1. Architecture Goal

Build a scalable fitness application with:

- Frontend UI
- Backend business logic
- Database storage

The architecture should allow future expansion:

- Adaptive workout system
- AI recommendations
- Social features

---

# 2. Technology Stack

## Frontend

Technology:

- React
- TypeScript
- Tailwind CSS


Responsibilities:

- User interface
- Workout screens
- Progress visualization
- User interaction


---

## Backend

Technology:

- C#
- ASP.NET Core Web API


Responsibilities:

- Business logic
- Authentication
- Workout calculation
- Progress analysis
- API endpoints


---

## Database

Technology:

- SQL Server
- Entity Framework Core


Responsibilities:

Store:

- Users
- Exercises
- Workouts
- Workout sessions
- Progress
- Achievements
- Challenges


---

# 3. System Architecture


Frontend
(React + TypeScript)

        |
        |
        REST API

        |

Backend
(ASP.NET Core Web API)

        |

Entity Framework Core

        |

Database
(SQL Server)


---

# 4. Main Modules


## User Module

Responsibilities:

- Registration
- Login
- Profile management
- User goals


---

## Exercise Module

Responsibilities:

- Exercise library
- Muscle groups
- Difficulty
- Instructions


---

## Workout Module

Responsibilities:

- Generate workout plans
- Start workout
- Track exercises


---

## Progress Module

Responsibilities:

- Analyze performance
- Track improvement
- Store personal records


---

## Challenge Module

Responsibilities:

- 30-day challenges
- Challenge progress
- Completion tracking


---

## Achievement Module

Responsibilities:

- XP system
- Badges
- Milestones


---

# 5. Database Entities


Main entities:

- User
- Exercise
- MuscleGroup
- WorkoutPlan
- WorkoutExercise
- WorkoutSession
- ExerciseResult
- UserProgress
- PersonalRecord
- Challenge
- UserChallenge
- Achievement
- UserAchievement


---

# 6. Authentication

Use:

ASP.NET Core Identity + JWT


Flow:

User
 |
Login
 |
ASP.NET Core API
 |
Validate
 |
Generate JWT Token
 |
Frontend stores token
 |
Access protected APIs


---

# 7. Development Order


1. Project setup

2. Database design

3. Backend API

4. Authentication

5. Exercise management

6. Workout system

7. Workout tracking

8. Progress statistics

9. 30-day challenges

10. Adaptive recommendation

11. UI improvements

12. Testing and deployment


---

# 8. Important Architecture Decision


Do not start with AI.

Reason:

Adaptive recommendation requires historical workout data.

First build:

User
↓
Exercise
↓
Workout
↓
Workout Session
↓
Progress

Then create recommendation logic.

---

# 9. Initial Workout Data Model Decisions

- Domain entities remain independent of Entity Framework Core; persistence mapping belongs in Infrastructure.
- `WorkoutExercise` is the explicit relationship between a workout plan and an exercise and stores order plus repetition, weight, or duration targets.
- `ExerciseResult` represents one completed set and can store repetitions, weight, duration, or a supported combination.
- `WorkoutSession` belongs to both a user and a workout plan and owns its exercise results.
- Exercises and muscle groups use a many-to-many relationship.
- Authentication credentials are not stored in the domain `User`; ASP.NET Core Identity will own credential data when authentication is implemented.
