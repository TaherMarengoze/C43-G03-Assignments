namespace C43_G03_ADV04;

/// Company will Lay off All Type of Employees in Two Cases
// - If Employee Vacation Stock < 0
// - If Employee Age > 60

public class Employee
{
    public event EventHandler<EmployeeLayOffEventArgs>? EmployeeLayOff;

    protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
    {
        EmployeeLayOff?.Invoke(this, e);

        string cause = e.Cause switch
        {
            LayOffCause.VacationStockDepleated => "Vacation Stock is depleted",
            LayOffCause.MaximumAgeReached => "Maximum age is reached",
            LayOffCause.TargetFailed => "Failed to acheive the designated target",
            LayOffCause.Resigned => "Submitted resignation",
            _ => "",
        };

        Console.WriteLine(
            $"Employee (ID = {EmployeeID}) was laid-off: {cause}"
            );
    }

    public int EmployeeID { get; set; }

    private DateTime birthDate;

    public DateTime BirthDate
    {
        get { return birthDate; }
        set { birthDate = value; }
    }

    private int vacationStock;

    public int VacationStock
    {
        get { return vacationStock; }
        set
        {
            vacationStock = value;

            if (vacationStock < 0)
            {
                EmployeeLayOffEventArgs eventArgs = new()
                {
                    Cause = LayOffCause.VacationStockDepleated
                };

                OnEmployeeLayOff(eventArgs);
            }
        }
    }

    public bool RequestVacation(DateTime from, DateTime to)
    {
        if (from >= to)
            return false;

        int vacationDays = (to - from).Days;
        VacationStock -= vacationDays;

        return true;
    }

    public void EndOfYearOperation()
    {
        double age = (DateTime.Now - birthDate).TotalDays / 365.25;

        if (age > 60.0)
        {
            EmployeeLayOffEventArgs eventArgs = new()
            {
                Cause = LayOffCause.MaximumAgeReached
            };

            OnEmployeeLayOff(eventArgs);
        }
    }
}
