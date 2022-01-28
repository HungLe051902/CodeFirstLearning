using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotations
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            var query = from c in context.Courses
                        where c.Name.Contains("C#")
                        orderby c.Name
                        select c;

            foreach (var item in query)
            {
                Console.WriteLine(item.Name);
            }

            var c12 = context.Courses.
                Where(c => c.Name.Contains("C#")).
                OrderBy(c => c.Name);

        }
    }
}
