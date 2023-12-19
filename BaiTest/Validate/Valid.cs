using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTest.Validate;
public class Valid<T>
{
    public static T CheckCR(string message)
    {
        Console.Write(message);
        var type = Type.GetTypeCode(typeof(T));
        var i = default(T);
        bool flag = true;

        while (flag)
        {
            try
            {
                var str = Console.ReadLine() ?? throw new Exception("Can't be null or empty, Please enter: ");
                i = type switch
                {
                    TypeCode.String => ((string)str).Length > 2 ? (T)(object)str : throw new Exception("Error, string must be greater than 2"),
                    TypeCode.Int32 => (int.TryParse(str, out int value) && value >= 0) ? (T)(object)value : throw new Exception("Error, number must greater than/equal to 0 or incorrect form"),
                    TypeCode.Double => (double.TryParse(str, out double value1) && value1 >= 0) ? (T)(object)value1 : throw new Exception("Error, number must greater than/equal to 0 or incorrect form"),
                    TypeCode.DateTime => DateTime.TryParseExact(str, new[] { "dd/MM/yyyy", "dd-MM-yyyy" }, new CultureInfo("vi-VN"), DateTimeStyles.None, out DateTime t)
                             ? (T)(object)t.Add(DateTime.Now.TimeOfDay)
                             : throw new Exception("Error, Incorrect form (must be dd/MM/yyyy or dd-MM-yyyy)"),
                    _ => throw new Exception("Unknown TypeCode")
                };
                flag = false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}, Please Enter Again!");
            }
        }
        return i;
    }
}
