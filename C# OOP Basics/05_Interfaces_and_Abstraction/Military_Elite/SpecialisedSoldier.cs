using System;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    protected SpecialisedSoldier(int id, string firstName, string lastName, double salary, string corps) : base(id, firstName, lastName, salary)
    {
        ParseCorps(corps);
    }

    private void ParseCorps(string corps)
    {
        bool isValid = Enum.TryParse(typeof(Corps), corps, out object validCorps);
        if (!isValid)
        {
            throw new ArgumentException("Invalid corps!");
        }
        this.Corps = (Corps)validCorps;
    }

    public Corps Corps { get; private set; }
}
