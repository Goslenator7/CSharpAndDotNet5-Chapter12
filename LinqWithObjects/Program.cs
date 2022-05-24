using System;
using System.Linq;

namespace LinqWithObjects
{
    class Program
    {
        static void LinqWithArrayOfStrings()
        {
            var names = new string[] {"Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };
            //Long way to call method
            //var query = names.Where(new Func<string, bool>(NameLongerThanFour));

            //succint way to call method
            //var query = names.Where(NameLongerThanFour);

            /*Lambda - "nameless function"
              lambda needs only: 
                    - The names of input parameters
                    - A return value expression*/

            var query = names.Where(name => name.Length > 4).OrderBy(name => name.Length);

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
