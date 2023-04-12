using System;
using System.Collections.Generic;

namespace LINQ_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
    }

    public class HospitalBase
    {
        private List<Diseased> _diseaseds;

        public HospitalBase(List<Diseased> diseaseds)
        {
            _diseaseds = diseaseds;
        }

        public void Work()
        {
            const ConsoleKey CommandSortPatientsByFullName = ConsoleKey.NumPad1;
            const ConsoleKey CommandSortAllPatientsByAge = ConsoleKey.NumPad2;
            const ConsoleKey CommandShowPatientsByDisease = ConsoleKey.NumPad3;

            bool isWork = true;

            while (isWork)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case CommandSortPatientsByFullName:

                        break;

                    case CommandSortAllPatientsByAge:

                        break;

                    case CommandShowPatientsByDisease:

                        break;
                }
            }
        }

        private void SortPatientsByFullName()
        {
            _diseaseds=_diseaseds.
        }
    }

    public class Diseased
    {
        public Diseased(string fullName, int age, string illness)
        {
            FullName = fullName;
            Age = age;
            Illness = illness;
        }

        public string FullName { get; }
        public int Age { get; }
        public string Illness { get; }
    }
}