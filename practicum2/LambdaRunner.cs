using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace practicum2
{
    class LambdaRunner
    {
        public static String RunAllMethods(int num1, int num2, int num3)
        {
            StringBuilder output = new StringBuilder();

            // methode TimesThree herschreven als lambda-expressie
            Func<int, int> timesThree = x => 3 * x;
            output.AppendFormat("timesThree({0}) = {1}\n", num1, timesThree(num1));

            // methode AddNumbers herschreven als lambda-expressie
            Func<int, int, int, int> addNumbers = (x, y, z) => x + y + z;
            output.AppendFormat("addNumbers({0}, {1}, {2}) = {3}\n", num1, num2, num3, addNumbers(num1, num2, num3));

            // methode IsEven herschreven als lambda-expressie
            // Predicate<int> isEven = Methods.IsEven;

            Predicate<int> isEven = x => x % 2 == 0;
            output.AppendFormat("isEven({0}) = {1}\n", num1, isEven(num1));

            // methode Num2String herschreven als lambda-expressie
            // Func<int, String> num2String = x => Methods.Num2String(x);
            
            Func<int, string> num2String = x => (x < 10 && x >= 0) ? new string[] 
            { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }[x] : "undefined";
            output.AppendFormat("Num2String({0}) = {1}\n", num1, num2String(num1));

            // methode InBetween herschreven als lambda-expressie 
            // Func<int, int, int, bool> inBetween = (x, y, z) => Methods.InBetween(x, y, z);

            Func<int, int, int, bool> inBetween = (x, y, z) => (x < y && y < z) || (z < y && y < x);
            output.AppendFormat("inBetween({0}, {1}, {2}) = {3}\n", num1, num2, num3, inBetween(num1, num2, num3));
            // (Ik wou hier eigenlijk een predicate, aangezien er een bool wordt gereturned, maar 't lukte me niet om meerdere parameters mee te geven aan een predicate)

            // methode ResetName herschreven als lambda-expressie
            Action<Person> resetName = Methods.ResetName;
            Person p = new Person { Name = "Jan" };
            resetName(p);
            output.AppendFormat("resetName, daarna (Name == null) = {0}\n", p.Name == null);

            return output.ToString();
        }

    }
}
