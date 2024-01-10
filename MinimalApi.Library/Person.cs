using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApi.Library
{
    public class Person
    {
        public Guid Id { get; set; }
        public Week DayofWeek { get; set; }

        public Person()
        {
            Id = Guid.NewGuid();
            DayofWeek = Week.Monday;
            if(DayofWeek == Week.Monday) { }
            Random r = new Random();
            DayofWeek = (Week)r.Next(1,7);
        }
    }

    public enum Week
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}
