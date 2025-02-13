namespace C43_G03_ADV04;
// Employee should be removed from Department Staff List in both Cases
// - If Employee Vacation Stock < 0
// - If Employee Age > 60
public class Department
{
    public int DeptID { get; set; }

    public string? DeptName { get; set; }

    private List<Employee> staff = new List<Employee>();

    public void AddStaff(Employee emp)
    {
        emp.EmployeeLayOff += RemoveStaff;
        staff.Add(emp);

        Console.WriteLine(
            $"Employee (ID = {emp.EmployeeID}) added to '{DeptName}' department."
            );
    }

    public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
    {
        Employee? emp = sender as Employee;

        if (emp is not null)
        {
            staff.Remove(emp);

            string cause = e.Cause switch
            {
                LayOffCause.VacationStockDepleated => "Vacation Stock is depleted",
                LayOffCause.MaximumAgeReached => "Maximum age is reached",
                _ => "",
            };
            Console.WriteLine(
                $"Employee (ID = {emp.EmployeeID}) removed from '{DeptName}' department: {cause}"
                );
        }

        
    }
}