using System;
using System.Linq;

namespace LinqWithObjects
{
    class Program
    {
        static void LinqWithArrayOfStrings()
        {
            var names = new string[] {"Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };
            var query = names.Where(new Func<string, bool>(NameLongerThanFour));

            foreach (string item in query)
            {
                Console.WriteLine(item);
            }
        }

        static bool NameLongerThanFour(string name)
        {
            return name.Length > 4;
        }

        static void Main(string[] args)
        {
            LinqWithArrayOfStrings();
        }
    }
}
