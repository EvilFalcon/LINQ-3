using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Diseased> diseaseds = new List<Diseased>()
            {
                new Diseased("Педро Алонсо Лопес", 33, "Изжога"),
                new Diseased("Усама бен Ладан", 45, "Ангина"),
                new Diseased("Бежин В.В", 23, "Ангина"),
                new Diseased("Матео Мессина Денаро", 61, "Болезнь Паркинсона"),
                new Diseased("Джозеф Кони", 41, "Аллергия"),
                new Diseased("Бакин В.В", 31, "Изжога"),
                new Diseased("Бабушкин А.В", 52, "Аллергия"),
                new Diseased("Воронин К.Д", 21, "Заикание"),
                new Diseased("Воронин К.Д", 69, "Болезнь Паркинсона"),
                new Diseased("Барышников Б.К", 18, "Заикание"),
                new Diseased("Барышников К.К", 47, "Изжога"),
            };

            HospitalBase hospitalBase = new HospitalBase(diseaseds);

            hospitalBase.Work();
        }
    }

    public class HospitalBase
    {
        private List<Diseased> _diseases;
        private List<Diseased> _sorted = new List<Diseased>();

        public HospitalBase(List<Diseased> diseases)
        {
            _diseases = diseases;
        }

        public void Work()
        {
            const ConsoleKey CommandSortPatientsByFullName = ConsoleKey.NumPad1;
            const ConsoleKey CommandSortAllPatientsByAge = ConsoleKey.NumPad2;
            const ConsoleKey CommandShowPatientsByDisease = ConsoleKey.NumPad3;
            const ConsoleKey CommandExitProgram = ConsoleKey.Escape;

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"{CommandSortPatientsByFullName} <---Отсортировать по ФИО");
                Console.WriteLine($"{CommandSortAllPatientsByAge} <---Отсортировать по возрасту ");
                Console.WriteLine($"{CommandShowPatientsByDisease} <---Вывести по болезни");
                Console.WriteLine($"{CommandExitProgram} <--- Выход из приложения");

                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case CommandSortPatientsByFullName:
                        SortPatientsByFullName();
                        break;

                    case CommandSortAllPatientsByAge:
                        SortAllPatientsByAge();
                        break;

                    case CommandShowPatientsByDisease:
                        ShowPatientsByDisease();
                        break;

                    case CommandExitProgram:
                        isWork = false;
                        break;
                }

                PrintRecord(_sorted);
            }
        }

        private void SortPatientsByFullName()
        {
            _sorted = _diseases.OrderBy(record => record.FullName).ToList();
        }

        private void SortAllPatientsByAge()
        {
            _sorted = _diseases.OrderBy(record => record.Age).ToList();
        }

        private void ShowPatientsByDisease()
        {
            var disease =
                _diseases.Select(record => record.Illness)
                    .Distinct()
                    .OrderBy(record => record)
                    .ToList();

            Console.WriteLine("Введите заболивание из следуюшего списка :");
            disease.ForEach(illness => Console.WriteLine(illness));
            string input = Console.ReadLine();
            _sorted =
                _diseases.Where(diseased => diseased.Illness.Equals(input, StringComparison.OrdinalIgnoreCase))
                    .ToList();
        }

        private void PrintRecord(List<Diseased> diseaseds)
        {
            string line = new string('─', 56);
            
            if (diseaseds.Count <= 0)
            {
                Console.WriteLine("Список по вашему запросу оказался пуст");
                return;
            }

            Console.WriteLine(line);
            Console.WriteLine($"| ФИО \t\t\t| Возраст | Заболивание \t|");

            foreach (var iDiseased in diseaseds)
            {
                Console.WriteLine(line);
                iDiseased.ShowInfo();
            }

            Console.WriteLine(line);
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
       
        public void ShowInfo()
        {
            Console.WriteLine($"|{FullName,22} | {Age,7} | {Illness,19} |");
        }
    }
}