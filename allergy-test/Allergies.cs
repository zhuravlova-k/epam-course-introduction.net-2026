namespace AllergyTest;

public class Allergies
{
    private readonly int score;

    public Allergies(int score)
    {
        if (score < 0)
        {
            throw new ArgumentException("cant be less than null", nameof(score));
        }

        this.score = score;
    }

    public bool IsAllergicTo(Allergens allergens)
    {
        return (this.score & (int)allergens) != 0;
    }

    public Allergens[] AllergensList()
    {
        var detectedAllergies = new List<Allergens>();

        foreach (Allergens allergen in Enum.GetValues(typeof(Allergens)))
        {
            if (this.IsAllergicTo(allergen))
            {
                detectedAllergies.Add(allergen);
            }
        }

        return detectedAllergies.ToArray();
    }
}
