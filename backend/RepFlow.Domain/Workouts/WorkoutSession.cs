using RepFlow.Domain.Users;

namespace RepFlow.Domain.Workouts;

public sealed class WorkoutSession
{
    private WorkoutSession() { }

    public WorkoutSession(Guid userId, Guid workoutPlanId, DateTimeOffset startedAt)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("A workout session must belong to a user.", nameof(userId));
        if (workoutPlanId == Guid.Empty)
            throw new ArgumentException("A workout session must reference a plan.", nameof(workoutPlanId));

        Id = Guid.NewGuid();
        UserId = userId;
        WorkoutPlanId = workoutPlanId;
        StartedAt = startedAt;
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid WorkoutPlanId { get; private set; }
    public DateTimeOffset StartedAt { get; private set; }
    public DateTimeOffset? CompletedAt { get; private set; }
    public TimeSpan? Duration => CompletedAt - StartedAt;
    public User User { get; private set; } = null!;
    public WorkoutPlan WorkoutPlan { get; private set; } = null!;
    public ICollection<ExerciseResult> Results { get; } = new List<ExerciseResult>();

    public void AddResult(ExerciseResult result)
    {
        ArgumentNullException.ThrowIfNull(result);
        if (result.WorkoutSessionId != Id)
            throw new ArgumentException("The result belongs to a different workout session.", nameof(result));

        Results.Add(result);
    }

    public void Complete(DateTimeOffset completedAt)
    {
        if (CompletedAt.HasValue)
            throw new InvalidOperationException("The workout session is already complete.");
        if (completedAt < StartedAt)
            throw new ArgumentOutOfRangeException(nameof(completedAt));

        CompletedAt = completedAt;
    }
}
