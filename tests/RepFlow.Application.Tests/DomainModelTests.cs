using RepFlow.Domain.Exercises;
using RepFlow.Domain.Users;
using RepFlow.Domain.Workouts;
using Xunit;

namespace RepFlow.Application.Tests;

public sealed class DomainModelTests
{
    [Fact]
    public void WorkoutDataFlowCapturesPlanAndPerformance()
    {
        var user = new User("athlete@example.com");
        var exercise = new Exercise(
            "Push-up",
            ExerciseDifficulty.Beginner,
            "Bodyweight",
            "Keep a straight body line.",
            "Do not flare the elbows.",
            recommendedSets: 3,
            recommendedReps: 10);
        exercise.MuscleGroups.Add(new MuscleGroup("Chest"));

        var plan = new WorkoutPlan(user.Id, "Beginner upper body");
        var plannedExercise = new WorkoutExercise(
            plan.Id,
            exercise.Id,
            order: 1,
            targetSets: 3,
            targetReps: 10);
        plan.AddExercise(plannedExercise);

        var startedAt = new DateTimeOffset(2026, 8, 19, 8, 0, 0, TimeSpan.Zero);
        var session = new WorkoutSession(user.Id, plan.Id, startedAt);
        var result = new ExerciseResult(
            session.Id,
            exercise.Id,
            setNumber: 1,
            repetitions: 10,
            weightKg: 0);
        session.AddResult(result);
        session.Complete(startedAt.AddMinutes(30));

        Assert.Single(plan.Exercises);
        Assert.Single(session.Results);
        Assert.Single(exercise.MuscleGroups);
        Assert.Equal(10, session.Results.Single().Repetitions);
        Assert.Equal(TimeSpan.FromMinutes(30), session.Duration.GetValueOrDefault());
    }

    [Fact]
    public void ExerciseResultRequiresAtLeastOnePerformanceValue()
    {
        Assert.Throws<ArgumentException>(() => new ExerciseResult(
            Guid.NewGuid(),
            Guid.NewGuid(),
            setNumber: 1));
    }

    [Fact]
    public void WorkoutSessionCannotCompleteBeforeItStarts()
    {
        var startedAt = new DateTimeOffset(2026, 8, 19, 8, 0, 0, TimeSpan.Zero);
        var session = new WorkoutSession(Guid.NewGuid(), Guid.NewGuid(), startedAt);

        Assert.Throws<ArgumentOutOfRangeException>(() => session.Complete(startedAt.AddSeconds(-1)));
    }
}
