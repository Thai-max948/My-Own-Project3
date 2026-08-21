namespace RepFlow.Domain.Exercises;

public sealed class MuscleGroup
{
    private MuscleGroup()
    {
    }

    public MuscleGroup(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Id = Guid.NewGuid();
        Name = name.Trim();
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public ICollection<Exercise> Exercises { get; } = new List<Exercise>();
}
