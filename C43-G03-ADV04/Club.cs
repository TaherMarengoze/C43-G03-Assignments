namespace C43_G03_ADV04;
// - Employee should be removed from Club Member List Only if Employee Vacation Stock < 0.
// - If Employee Age > 60 will still remain a Member of Company Club
public class Club
{
    public int ClubID { get; set; }

    public string? ClubName { get; set; }

    private List<Employee> members = new List<Employee>();

    public void AddMember(Employee emp)
    {
        ///Try Register for EmployeeLayOff Event Here
        
        if(emp.GetType() == typeof(Employee))
        {
            emp.EmployeeLayOff += RemoveMember;
        }

        members.Add(emp);

        Console.WriteLine(
            $"Employee (ID = {emp.EmployeeID}) added to '{ClubName}' club."
            );
    }

    public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
    {
        ///Employee Will not be removed from the Club if Age>60
        ///Employee will be removed from Club if Vacation Stock < 0
        
        Employee? emp = sender as Employee;

        if (emp is not null)
        {
            if (e.Cause == LayOffCause.VacationStockDepleated)
            {
                members.Remove(emp);

                Console.WriteLine(
                    $"Employee (ID = {emp.EmployeeID}) removed from '{ClubName}' club: Vacation Stock is depleted");
            }
        }
    }
}