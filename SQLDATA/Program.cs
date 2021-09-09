using System;
using System.Collections.Generic;

namespace SQLDATA
{
    class Program
    {
        static void Main(string[] args)
        {
            SQL sql = new SQL();
            //int antal = InsertInto(sql);

            //Search(sql);
            MellemDato(sql);

        }

        private static void MellemDato(SQL sql)
        {
            Console.WriteLine("Skriv start dato");
            Console.WriteLine("skriv year of Birth");
            int dob = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("skriv month of Birth");
            int dob1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("skriv day of Birth");
            int dob2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Skriv slut dato");
            Console.WriteLine("skriv year of Birth");
            int dob3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("skriv month of Birth");
            int dob4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("skriv day of Birth");
            int dob5 = Convert.ToInt32(Console.ReadLine());
            //List<Person> persons = sql.select(search);
            List<Personer> persons/*FromDatetimeList*/ = sql.select2(new DateTime(dob, dob1, dob2), new DateTime(dob3, dob4, dob5));

            if (persons != null && persons.Count > 0)
            {
                foreach (var person in persons)
                {
                    Console.WriteLine(person.Navn);
                }
            }
            else Console.WriteLine("Nothing found.");
        }

        private static void Search(SQL sql)
        {
            Console.WriteLine("skriv year of Birth");
            int dob = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("skriv month of Birth");
            int dob1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("skriv day of Birth");
            int dob2 = Convert.ToInt32(Console.ReadLine());
            //List<Person> persons = sql.select(search);
            List<Personer> persons/*FromDatetimeList*/ = sql.select(new DateTime(dob, dob1, dob2));

            if (persons != null && persons.Count > 0)
            {
                foreach (var person in persons)
                {
                    Console.WriteLine(person.Navn);
                }
            }
            else Console.WriteLine("Nothing found.");
        }

        private static int InsertInto(SQL sql)
        {
            int antal;
            Personer person = new Personer();
            int? id = null;

            Console.WriteLine("Skriv hvor mange du ville have");
            antal = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < antal; i++)
            {
                string Navn;
                int dob, dob1, dob2;
                ADD(out Navn, out dob, out dob1, out dob2);


                person.Navn = Navn;
                person.Dob = new DateTime(dob, dob1, dob2);
                id = sql.insert(person);

            }
            if (id != null)
                Console.WriteLine($"{person.Navn}, Born {person.Dob} have gotten id : {id}");

            else Console.WriteLine("Something went horribly wrong!");
            return antal;
        }

        private static void ADD(out string Navn, out int dob, out int dob1, out int dob2)
        {
            Console.Clear();
            Console.WriteLine("Skriv navn");
            Navn = Console.ReadLine();
            Console.WriteLine("skriv year of Birth");
            dob = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("skriv month of Birth");
            dob1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("skriv day of Birth");
            dob2 = Convert.ToInt32(Console.ReadLine());
        }
    }
}
