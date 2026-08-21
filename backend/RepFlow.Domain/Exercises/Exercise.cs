using RepFlow.Domain.Workouts;

namespace RepFlow.Domain.Exercises;

public sealed class Exercise
{
    private Exercise()
    {
    }

    public Exercise(
        string name,
        ExerciseDifficulty difficulty,
        string equipment,
        string instructions,
        string commonMistakes,
        int recommendedSets,
        int recommendedReps,
        string? demonstrationUrl = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(equipment);
        ArgumentException.ThrowIfNullOrWhiteSpace(instructions);
        ArgumentException.ThrowIfNullOrWhiteSpace(commonMistakes);

        if (recommendedSets <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(recommendedSets));
        }

        if (recommendedReps <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(recommendedReps));
        }

        Id = Guid.NewGuid();
        Name = name.Trim();
        Difficulty = difficulty;
        Equipment = equipment.Trim();
        Instructions = instructions.Trim();
        CommonMistakes = commonMistakes.Trim();
        RecommendedSets = recommendedSets;
        RecommendedReps = recommendedReps;
        DemonstrationUrl = string.IsNullOrWhiteSpace(demonstrationUrl)
            ? null
            : demonstrationUrl.Trim();
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public ExerciseDifficulty Difficulty { get; private set; }

    public string Equipment { get; private set; } = string.Empty;

    public string Instructions { get; private set; } = string.Empty;

    public string CommonMistakes { get; private set; } = string.Empty;

    public int RecommendedSets { get; private set; }

    public int RecommendedReps { get; private set; }

    public string? DemonstrationUrl { get; private set; }

    public ICollection<MuscleGroup> MuscleGroups { get; } = new List<MuscleGroup>();

    public ICollection<WorkoutExercise> WorkoutExercises { get; } = new List<WorkoutExercise>();

    public ICollection<ExerciseResult> Results { get; } = new List<ExerciseResult>();
}
