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

            var query = names.Where(name => name.Length > 4).OrderBy(name => name.Length).ThenBy(name => name);

            foreach (string item in query)
            {
                Console.WriteLine(item);
            }
        }

        static void LinqWithArrayOfExceptions()
        {
            var errors = new Exception[]
            {
                new ArgumentException(),
                new SystemException(),
                new InvalidOperationException(),
                new NullReferenceException(),
                new InvalidCastException(),
                new OverflowException(),
                new DivideByZeroException(),
                new ApplicationException()
            };

            var numberErrors = errors.OfType<ArithmeticException>();

            foreach (var error in numberErrors)
            {
                Console.WriteLine(error);
            }
        }

        static bool NameLongerThanFour(string name)
        {
            return name.Length > 4;
        }

        static void Main(string[] args)
        {
            //LinqWithArrayOfStrings();
            LinqWithArrayOfExceptions();
        }
    }
}
