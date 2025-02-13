namespace C43_G03_ADV04;
// - Board Member has no retiring Age (will not be Fired if AGE > 60)
// - Board Member is not a Full time Employee (Has no vacation Stock)
// - Board Member will be layoff from the Company in case He/She Resigned.
// - Board Member will forever be a Member of Company Clubs
public class BoardMember : Employee
{
    protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
    {
        if (e.Cause == LayOffCause.Resigned)
        {
            base.OnEmployeeLayOff(e);
        }
    }

    public void Resign()
    {
        OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.Resigned });
    }
}
