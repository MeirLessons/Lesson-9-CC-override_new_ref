using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_9_Method_Adv
{
    class Program
    {
        static void Main(string[] args)
        {
            int howmanyRecycled = 0;
            int maxRecycle = 10;
            Bottle b = new Bottle();
            while (howmanyRecycled <= maxRecycle)
            {
                b.Recycle(ref howmanyRecycled, maxRecycle);
            }

            #region ref

            //Value Type:
            int xx = 10;
            IncreaseNumber(ref xx);
            Console.WriteLine(xx);

            //Reference Type
            Person p = new Person();
            Console.WriteLine(p.age);
            Person p1 = p;
            ChangeAge(p);
            Console.WriteLine(p.age);

            string errorMessage = "";
            p1.name = "Meir";
            if(!TryChangeName("dd", p1, ref errorMessage))
            {
                Console.WriteLine(errorMessage);
            }
            #endregion

            #region Override And Virtual
            Student fullStduent = new Student();//הצבה וזיכרון של הבן
            Person ps = new Student();//הצבה של האבא וזיכרון של הבן

            //Virtual And Override
            fullStduent.VirtualAndOverride(); //Studnet
            ps.VirtualAndOverride(); //Student

            //Only Override = Error

            //Only Virtual:
            fullStduent.Virtualonly(); //מימוש של הבן עם הערה
            ps.Virtualonly();//מימוש של האבא

            #endregion

            #region this and base
            Person person = new Person();
            Student s = new Student();
            Employee e = new Employee();
            Console.WriteLine(person);
            Console.WriteLine(s.ToString());
            Console.WriteLine(e.ToString());
            #endregion
        }


        static void IncreaseNumber(ref int x)
        {
            x++;
            Console.WriteLine(x);
        }

        static void ChangeAge(Person p)
        {
            p.age = 120;
        }
    
        static bool TryChangeName(string newName, Person p, ref string errorMessage)
        {
            if(newName == "")
            {
                errorMessage = "empty name";
                return false;
            }
            else if(newName.Length < 3)
            {
                errorMessage = "too short name";
                return false;
            }
            else
            {
                p.name = newName;
                return true;
            }
        }
    }
   



    class Bottle
    {
        public void Recycle(ref int howMany,int max)
        {
            howMany++;
        }
    }


    class Person
    {
        public string name = "dan";
        public int age = 20;

        public virtual void VirtualAndOverride()
        {
            Console.WriteLine(name);
        }

        public void OverrideOnly()
        {

        }

        public virtual void Virtualonly()
        {

        }

        public override string ToString()
        {
            return base.ToString() + $"name: {name}. age: {age}";
        }
    }

    class Student : Person
    {
        public int grade;
        public override void VirtualAndOverride()
        {
            Console.WriteLine(name + " " + age);
        }

        //public override void OverrideOnly()
        //{

        //}

        public void Virtualonly()
        {

        }

        public override string ToString()
        {
            return $" grade: {grade}." + base.ToString();
        }
    }

    class Employee : Person
    {
        public double salary; 
    }
}
