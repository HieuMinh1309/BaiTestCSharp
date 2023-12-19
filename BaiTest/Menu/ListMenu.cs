using BaiTest.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTest.Menu;
public class ListMenu
{
    public static void ShowMenu()
    {
        var loop = true;
        ListStudent list = new();
        while (loop)
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1.Add Student");
            Console.WriteLine("2.Show List of Student");
            Console.WriteLine("3.Update Student By Id");
            Console.WriteLine("4.Delete Student By Id");
            Console.WriteLine("5.Show student Older than 20 and have AVG higher than 8");
            Console.WriteLine("6.Show students with highest AVG");
            Console.WriteLine("7.Sort By Student Score");
            Console.WriteLine("8.Check Student Id");
            Console.WriteLine("Type Other key to exit");
            Console.Write("Choose: ");
            var key = Console.ReadLine();
            switch (key)
            {
                case "1": list.AddStudent(); break;
                case "2": list.ShowStudent(); break;
                case "3": list.UpdateStudent(); break;
                case "4": list.DeleteStudent(); break;
                case "5": list.ShowOldStudentWithHighPoint(); break;
                case "6": list.HighestAVGStudent(); break;
                case "7": list.SortByAVG(); break;
                case "8": list.CheckStudentId(); break;
                default: loop = false; break;
            }
        }
    }

}
