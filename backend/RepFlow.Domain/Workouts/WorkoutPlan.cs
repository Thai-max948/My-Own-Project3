using RepFlow.Domain.Users;

namespace RepFlow.Domain.Workouts;

public sealed class WorkoutPlan
{
    private WorkoutPlan() { }

    public WorkoutPlan(Guid userId, string name)
    {
        if (userId == Guid.Empty)
            throw new ArgumentException("A workout plan must belong to a user.", nameof(userId));

        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Id = Guid.NewGuid();
        UserId = userId;
        Name = name.Trim();
    }

    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public User User { get; private set; } = null!;
    public ICollection<WorkoutExercise> Exercises { get; } = new List<WorkoutExercise>();
    public ICollection<WorkoutSession> Sessions { get; } = new List<WorkoutSession>();

    public void AddExercise(WorkoutExercise workoutExercise)
    {
        ArgumentNullException.ThrowIfNull(workoutExercise);
        if (workoutExercise.WorkoutPlanId != Id)
            throw new ArgumentException("The exercise belongs to a different workout plan.", nameof(workoutExercise));

        Exercises.Add(workoutExercise);
    }
}
