using RepFlow.Domain.Exercises;

namespace RepFlow.Domain.Workouts;

public sealed class WorkoutExercise
{
    private WorkoutExercise() { }

    public WorkoutExercise(
        Guid workoutPlanId,
        Guid exerciseId,
        int order,
        int targetSets,
        int? targetReps = null,
        decimal? targetWeightKg = null,
        int? targetDurationSeconds = null)
    {
        if (workoutPlanId == Guid.Empty)
            throw new ArgumentException("A workout exercise must belong to a plan.", nameof(workoutPlanId));
        if (exerciseId == Guid.Empty)
            throw new ArgumentException("A workout exercise must reference an exercise.", nameof(exerciseId));
        if (order <= 0)
            throw new ArgumentOutOfRangeException(nameof(order));
        if (targetSets <= 0)
            throw new ArgumentOutOfRangeException(nameof(targetSets));
        if (targetReps is <= 0)
            throw new ArgumentOutOfRangeException(nameof(targetReps));
        if (targetWeightKg is < 0)
            throw new ArgumentOutOfRangeException(nameof(targetWeightKg));
        if (targetDurationSeconds is <= 0)
            throw new ArgumentOutOfRangeException(nameof(targetDurationSeconds));
        if (targetReps is null && targetDurationSeconds is null)
            throw new ArgumentException("A workout exercise requires a repetition or duration target.");

        Id = Guid.NewGuid();
        WorkoutPlanId = workoutPlanId;
        ExerciseId = exerciseId;
        Order = order;
        TargetSets = targetSets;
        TargetReps = targetReps;
        TargetWeightKg = targetWeightKg;
        TargetDurationSeconds = targetDurationSeconds;
    }

    public Guid Id { get; private set; }
    public Guid WorkoutPlanId { get; private set; }
    public Guid ExerciseId { get; private set; }
    public int Order { get; private set; }
    public int TargetSets { get; private set; }
    public int? TargetReps { get; private set; }
    public decimal? TargetWeightKg { get; private set; }
    public int? TargetDurationSeconds { get; private set; }
    public WorkoutPlan WorkoutPlan { get; private set; } = null!;
    public Exercise Exercise { get; private set; } = null!;
}
