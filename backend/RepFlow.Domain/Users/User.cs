using RepFlow.Domain.Workouts;

namespace RepFlow.Domain.Users;

public sealed class User
{
    private User()
    {
    }

    public User(string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        Id = Guid.NewGuid();
        Email = email.Trim();
    }

    public Guid Id { get; private set; }

    public string Email { get; private set; } = string.Empty;

    public ICollection<WorkoutPlan> WorkoutPlans { get; } = new List<WorkoutPlan>();

    public ICollection<WorkoutSession> WorkoutSessions { get; } = new List<WorkoutSession>();
}
