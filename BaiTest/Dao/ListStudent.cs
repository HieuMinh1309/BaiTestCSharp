using BaiTest.Entity;
using BaiTest.Validate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTest.Dao;
public class ListStudent
{
    public List<Student> List { get; set; } = [];

    public void AddStudent()
    {
        int amount = Valid<int>.CheckCR("Amount of student you need to input: ");
        for (var i = 0; i < amount; i++)
        {
            int id = Valid<int>.CheckCR("Id: ");
            bool idExists = List.Any(s => s.Id == id);
            while (idExists)
            {
                Console.WriteLine("Id already exists. Please enter a different Id.");
                id = Valid<int>.CheckCR("Id: ");
                idExists = List.Any(s => s.Id == id);
            }
            Student stu = new()
            {
                Id = id,
                Name = Valid<string>.CheckCR("Student Name: "),
                Dob = Valid<DateTime>.CheckCR("Dob: "),
                Gender = Valid<string>.CheckCR("Gender(Male/Female): "),
                Avg = Valid<double>.CheckCR("Avg: "),
                ConductPoint = Valid<double>.CheckCR("Conduct Point(0-100): "),
                PhoneNumber = Valid<int>.CheckCR("PhoneNumber: ")
            };
            switch (stu.Gender)
            {
                case "Male": stu.Gender = "Male"; break;
                case "Female": stu.Gender = "Female"; break;
                default: Console.WriteLine("Incorrect Form"); break;
            }
            switch (stu.ConductPoint)
            {
                case var conductPoint when conductPoint > 80 && conductPoint<100:
                    stu.CC = "Excellent"; break;
                case var conductPoint when conductPoint > 70:
                    stu.CC = "Good"; break;
                case var conductPoint when conductPoint > 50 && conductPoint < 70:
                    stu.CC = "Average"; break;
                case var conductPoint when conductPoint < 50:
                    stu.CC = "Bad"; break;
                default:
                    Console.WriteLine("Incorrect Form"); break;
            }
            Console.WriteLine("===========================");
            List.Add(stu);
        }
    }

    public void ShowStudent()
    {
        if (List.Count > 0)
        {
            List.ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("There's nothing to show\n");
        }
    }

    public void UpdateStudent()
    {
        if (List.Count > 0)
        {
            var id = Valid<int>.CheckCR("Id to Update: ");
            if ((List.FirstOrDefault(s => s.Id == id)) is null)
            {
                Console.WriteLine("Id doesn't exists");
            }
            else
            {
                List.Where(s => s.Id == id).ToList().ForEach(stu =>
                {
                    stu.Name = Valid<string>.CheckCR("Student Name: ");
                    stu.Dob = Valid<DateTime>.CheckCR("Dob: ");
                    stu.Gender = Valid<string>.CheckCR("Gender(Male/Female): ");                    
                    stu.Avg = Valid<double>.CheckCR("Avg: ");
                    stu.ConductPoint = Valid<double>.CheckCR("Conduct Point: ");
                    stu.PhoneNumber = Valid<int>.CheckCR("PhoneNumber: ");

                    switch (stu.Gender)
                    {
                        case "Male": stu.Gender = "Male"; break;
                        case "Female": stu.Gender = "Female"; break;
                        default: throw new Exception("Gender doesn't exists");
                    }

                    switch (stu.ConductPoint)
                    {
                        case var conductPoint when conductPoint > 80:
                            stu.CC = "Excellent"; break;
                        case var conductPoint when conductPoint > 70:
                            stu.CC = "Good"; break;
                        case var conductPoint when conductPoint > 50 && conductPoint < 70:
                            stu.CC = "Average"; break;
                        case var conductPoint when conductPoint < 50:
                            stu.CC = "Bad"; break;
                    }
                });
            }
        }
        else
        {
            Console.WriteLine("There's nothing to update");
        }
    }


    public void DeleteStudent()
    {
        if (List.Count > 0)
        {
            int id = Valid<int>.CheckCR("Id to delete: ");
            if ((List.FirstOrDefault(s => s.Id == id)) is not null)
            {
                List.RemoveAll(s => s.Id == id);
            }
            else
            {
                Console.WriteLine("Id doesn't exists");
            }
           
        }
        else
        {
            Console.WriteLine("List has nothing to delete");
        }
    }

    public void ShowOldStudentWithHighPoint()
    {
        DateTime currentDate = DateTime.Now;
        Student stu = new();
        int age = CalculateAge(currentDate, stu.Dob);
        List.Where(stu => age > 20 && stu.Avg > 8).ToList().ForEach(Console.WriteLine);
    }

    static int CalculateAge(DateTime currentDate, DateTime dateOfBirth)
    {
        int age = currentDate.Year - dateOfBirth.Year;

        if (currentDate.Month < dateOfBirth.Month || (currentDate.Month == dateOfBirth.Month && currentDate.Day < dateOfBirth.Day))
        {
            age--;
        }

        return age;
    }

    public void HighestAVGStudent()
    {
        if (List.Count > 0)
        {
            double maxAVG = List.Max(s => s.Avg);
            List.Where(s => s.Avg == maxAVG).ToList().ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("There's nothing in the list");
        }
    }

    public void SortByAVG()
    {
        if (List.Count > 0)
        {
            List.Sort((s1, s2) => s1.Avg.CompareTo(s2.Avg));
        }
        else
        {
            Console.WriteLine("There's nothing to sort");
        }
    }

    public void CheckStudentId()
    {
        if (List.Count > 0)
        {
            var id = Valid<int>.CheckCR("Id: ");
            if (List.Any(s => s.Id == id))
            {
                Console.WriteLine("Student Id exists");
            }
            else
            {
                Console.WriteLine("Student Id doesn't exists");
            }
        }
    }
}
