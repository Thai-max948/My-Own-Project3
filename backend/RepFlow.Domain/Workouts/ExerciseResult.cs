using RepFlow.Domain.Exercises;

namespace RepFlow.Domain.Workouts;

public sealed class ExerciseResult
{
    private ExerciseResult() { }

    public ExerciseResult(
        Guid workoutSessionId,
        Guid exerciseId,
        int setNumber,
        int? repetitions = null,
        decimal? weightKg = null,
        int? durationSeconds = null)
    {
        if (workoutSessionId == Guid.Empty)
            throw new ArgumentException("An exercise result must belong to a session.", nameof(workoutSessionId));
        if (exerciseId == Guid.Empty)
            throw new ArgumentException("An exercise result must reference an exercise.", nameof(exerciseId));
        if (setNumber <= 0)
            throw new ArgumentOutOfRangeException(nameof(setNumber));
        if (repetitions is <= 0)
            throw new ArgumentOutOfRangeException(nameof(repetitions));
        if (weightKg is < 0)
            throw new ArgumentOutOfRangeException(nameof(weightKg));
        if (durationSeconds is <= 0)
            throw new ArgumentOutOfRangeException(nameof(durationSeconds));
        if (repetitions is null && weightKg is null && durationSeconds is null)
            throw new ArgumentException("An exercise result requires at least one performance value.");

        Id = Guid.NewGuid();
        WorkoutSessionId = workoutSessionId;
        ExerciseId = exerciseId;
        SetNumber = setNumber;
        Repetitions = repetitions;
        WeightKg = weightKg;
        DurationSeconds = durationSeconds;
    }

    public Guid Id { get; private set; }
    public Guid WorkoutSessionId { get; private set; }
    public Guid ExerciseId { get; private set; }
    public int SetNumber { get; private set; }
    public int? Repetitions { get; private set; }
    public decimal? WeightKg { get; private set; }
    public int? DurationSeconds { get; private set; }
    public WorkoutSession WorkoutSession { get; private set; } = null!;
    public Exercise Exercise { get; private set; } = null!;
}
