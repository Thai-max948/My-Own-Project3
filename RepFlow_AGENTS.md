# AGENTS.md --- RepFlow Project Instructions

```{=html}
<!--
Project: RepFlow — Your 30-Day Workout Journey

This file provides durable instructions for Codex when working on this repository.
Keep stable project rules here. Put temporary task requirements in the prompt.
-->
```
# Project Overview

RepFlow is a workout application that turns training into a 30-day
progression journey.

Core philosophy:

Workout → Progress → Adaptation

The app should help users answer: - What should I train today? - How
much should I do? - Am I actually getting stronger?

Main target users: - Beginners who do not know what to train -
Intermediate gym users - Calisthenics enthusiasts - Home workout users -
People following short challenges

------------------------------------------------------------------------

# Architecture Rules

## Technology Stack

Frontend: - React - TypeScript - Tailwind CSS

Backend: - C# - ASP.NET Core Web API

Database: - SQL Server - Entity Framework Core

Authentication: - ASP.NET Core Identity - JWT

Testing: - xUnit for backend testing

------------------------------------------------------------------------

# General Development Rules

```{=html}
<!-- ESSENTIAL: These rules should apply to almost every Codex task. -->
```
-   Inspect existing code patterns before making changes.
-   Prefer extending existing modules instead of creating duplicates.
-   Keep business logic out of the frontend.
-   Keep API contracts stable unless a change is explicitly requested.
-   Do not introduce unnecessary dependencies.
-   Make changes small and focused.

------------------------------------------------------------------------

# Domain Architecture

```{=html}
<!-- ESSENTIAL: Prevents Codex from placing logic in the wrong layer. -->
```
The application is organized around these core modules:

-   User
-   Exercise
-   Workout
-   WorkoutSession
-   Progress
-   Challenge
-   Achievement
-   Recommendation

Follow these boundaries:

Frontend: - Handles UI, user interaction, and visualization. - Does not
contain workout progression rules.

Backend: - Owns business logic. - Calculates progression decisions. -
Handles workout adaptation rules.

Database: - Stores persistent user and training data.

------------------------------------------------------------------------

# Workout Adaptation Rules

```{=html}
<!-- ESSENTIAL: This is RepFlow's main differentiator. -->
```
The adaptive workout system must remain rule-based initially.

Do not introduce AI/ML recommendations unless explicitly requested.

Current logic:

Performance ↓ Evaluate ↓ Difficulty decision

Rules:

-   High completion rate → increase difficulty
-   Appropriate completion → maintain difficulty
-   Low completion → reduce difficulty

Example:

Target: Squat 3 × 10

Completed: 10 / 10 / 10

Result: Increase next target.

Completed: 10 / 8 / 6

Result: Maintain difficulty.

Completed: 7 / 6 / 5

Result: Reduce difficulty.

------------------------------------------------------------------------

# Workout Data Rules

When modifying workout features, preserve these concepts:

-   Exercises contain:
    -   name
    -   muscle groups
    -   difficulty
    -   equipment
    -   instructions
    -   common mistakes
-   Workout sessions record:
    -   exercises completed
    -   sets
    -   reps
    -   weight
    -   duration
-   Progress tracks:
    -   strength changes
    -   personal records
    -   training volume
    -   streaks

------------------------------------------------------------------------

# Frontend Rules

```{=html}
<!-- ESSENTIAL for UI consistency. -->
```
Use React + TypeScript patterns.

Before creating a new component: - Search for an existing reusable
component. - Follow current styling conventions.

Maintain the dark athletic UI direction.

Important screens:

-   Dashboard
-   Workout screen
-   Exercise details
-   Progress charts
-   Profile
-   Challenges
-   Authentication

------------------------------------------------------------------------

# Backend Rules

```{=html}
<!-- ESSENTIAL for maintaining clean architecture. -->
```
Use:

Controllers ↓ Services ↓ Database layer

Controllers should: - Receive requests. - Validate basic input. - Call
services.

Services should: - Contain business logic. - Handle workout
progression. - Calculate achievements and recommendations.

Do not put progression rules inside controllers.

------------------------------------------------------------------------

# Database Rules

Use Entity Framework Core migrations.

Important entities:

-   Users
-   Exercises
-   MuscleGroups
-   WorkoutPlans
-   WorkoutExercises
-   WorkoutSessions
-   ExerciseResults
-   UserProgress
-   PersonalRecords
-   Challenges
-   UserChallenges
-   Achievements
-   UserAchievements

Never: - Modify production data directly. - Remove migrations without
understanding impact.

------------------------------------------------------------------------

# Testing Requirements

```{=html}
<!-- ESSENTIAL: Codex should verify changes. -->
```
After backend changes:

Run relevant xUnit tests.

Important services to test:

-   WorkoutService
-   ProgressService
-   ChallengeService
-   AchievementService
-   RecommendationService

Example test:

Given: Push-up target = 3 × 10

Actual: 10 / 10 / 10

Expected: Next target increases.

------------------------------------------------------------------------

# Development Priority

Follow this order unless explicitly changed:

1.  Project Architecture
2.  Database Design
3.  ASP.NET Core API
4.  Authentication
5.  Exercise Management
6.  Workout System
7.  Workout Tracking
8.  Progress & Statistics
9.  30-Day Challenges
10. Adaptive Recommendation
11. UI Polish
12. Testing & Deployment

Do not start with the adaptive/AI system before the workout and progress
data pipeline exists.

------------------------------------------------------------------------

# Task Completion Format

When finishing a task, report:

1.  Summary of changes
2.  Files modified
3.  Tests executed
4.  Remaining concerns or future improvements
# Documentation rules

After completing a major feature:
- Update docs/progress.md
- Record important architecture decisions
- Keep progress.md concise