namespace C43_G03_ADV04;
// - Sales Employee Doesn’t have Vacation Stock
// - Sales Employee Will not be Fired if his/her Vacation Stock <0
// - Sales Employee have a target to Achieve
// - Sales Employee will be Fired if Failed to Achieve Sales Target
public class SalesPerson : Employee
{
    protected override void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
    {
        if (e.Cause == LayOffCause.TargetFailed)
        {
            base.OnEmployeeLayOff(e);
        }
    }

    public int AchievedTarget { get; set; }

    public bool CheckTarget(int Quota)
    {
        if (Quota < AchievedTarget)
        {
            EmployeeLayOffEventArgs eventArgs = new()
            {
                Cause = LayOffCause.TargetFailed
            };

            OnEmployeeLayOff(eventArgs);

            return false;
        }

        return true;
    }
}
