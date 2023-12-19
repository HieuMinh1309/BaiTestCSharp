using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTest.Entity;
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Dob { get; set; }
    public string Gender { get; set; }
    public double Avg { get; set; }
    public double ConductPoint { get; set; }
    public string CC { get; set; }
    public int PhoneNumber { get; set; }

    public override string ToString()
    {
        return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Dob)}={Dob.ToString()}, {nameof(Gender)}={Gender}, {nameof(Avg)}={Avg.ToString()}, {nameof(ConductPoint)}={ConductPoint.ToString()}, {nameof(CC)}={CC}, {nameof(PhoneNumber)}={PhoneNumber.ToString()}}}";
    }
}
