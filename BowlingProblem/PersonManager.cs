using System;
using System.Collections.Generic;
using System.Text;

namespace PaulSheriff
{
    public class PersonManager
    {
        public Person CreatePerson(string first, string last, bool isSupervisor)
        {
            Person returnedPerson = null;
            if (!string.IsNullOrEmpty(first))
            {
                if (isSupervisor)
                {
                    returnedPerson = new Supervisor();
                }
                else
                {
                    returnedPerson = new Employee();
                }
                returnedPerson.FirstName = first;
                returnedPerson.LastName = last;
            }
            return returnedPerson;
        }
        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person() { FirstName = "Paul", LastName = "Sheriff" });
            people.Add(new Person() { FirstName = "Jared", LastName = "Kushner" });
            people.Add(new Person() { FirstName = "Marco", LastName = "Rubio" });
            return people;
        }
    }
}
