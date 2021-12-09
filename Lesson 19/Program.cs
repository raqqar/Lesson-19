using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_19
{
    internal class Program
    {
        //// 1.Модель компьютера  характеризуется кодом  и названием  марки компьютера, типом  процессора,  частотой работы  процессора, 
        ///
        ///объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты,
        ///
        ///стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии.
        ///
        ///Создать список, содержащий 6-10 записей с различным набором значений характеристик.

        ////Определить:
        ////- все компьютеры с указанным процессором.Название процессора запросить у пользователя;

        ////- все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;

        ////- вывести весь список, отсортированный по увеличению стоимости;

        ////- вывести весь список, сгруппированный по типу процессора;

        ////- найти самый дорогой и самый бюджетный компьютер;

        ////- есть ли хотя бы один компьютер в количестве не менее 30 штук?
        class Computer
        {
            public int Id { get; set; }
            public string ModelName { get; set; }
            public string ProcessorType { get; set; }
            public double ProcessorFrequencies { get; set; }
            public int RAM { get; set; }
            public int HDD { get; set; }
            public int VideoCardMemory { get; set; }
            public int Cost { get; set; }
            public int Quantity { get; set; }
            public List<string> Composition { get; set; }
        }
        static void Main(string[] args)
        {
            //Определяем все компьютеры с указанным процессором.Название процессора запросить у пользователя;
            // все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;
            // Выводим список по пользовательским фильтрам
            Console.Write("Введите название процессора ");
            string processorType = Console.ReadLine();
            Console.Write("Введите объем ОЗУ ");
            int rAM = Convert.ToInt32(Console.ReadLine());

            List<Computer> listComputer = new List<Computer>()
            {
                new Computer(){Id = 1, ModelName = "MSI GT 100", ProcessorType="core I7",ProcessorFrequencies=4.5,RAM=16,HDD=512,VideoCardMemory=8,Cost=120000,Quantity=20} ,
                new Computer(){Id = 2, ModelName = "Lenovo live ", ProcessorType="core I5",ProcessorFrequencies=2.5,RAM=16,HDD=256,VideoCardMemory=4,Cost=750000,Quantity=10} ,
                new Computer(){Id = 3, ModelName = "HP", ProcessorType="core I3",ProcessorFrequencies=4,RAM=8,HDD=256,VideoCardMemory=4,Cost=40000,Quantity=30} ,
                new Computer(){Id = 4, ModelName = "DELL", ProcessorType="AMD R",ProcessorFrequencies=4,RAM=32,HDD=1000,VideoCardMemory=6,Cost=90000,Quantity=10} ,
                new Computer(){Id = 5, ModelName = "Apple", ProcessorType="A",ProcessorFrequencies=5,RAM=32,HDD=1000,VideoCardMemory=5,Cost=150000,Quantity=18} ,
                new Computer(){Id = 6, ModelName = "Samsung", ProcessorType="core I5",ProcessorFrequencies=4.3,RAM=16,HDD=512,VideoCardMemory=4,Cost=70000,Quantity=5} ,
                new Computer(){Id = 7, ModelName = "Lenova YOG", ProcessorType="core I3",ProcessorFrequencies=3,RAM=8,HDD=256,VideoCardMemory=3,Cost=40000,Quantity=40} ,
                new Computer(){Id = 8, ModelName = "Lenova MOG ", ProcessorType="core I3",ProcessorFrequencies=3,RAM=16,HDD=256,VideoCardMemory=3,Cost=45000,Quantity=9} ,
                new Computer(){Id = 9, ModelName = "Lenova LOG ", ProcessorType="core I3",ProcessorFrequencies=3,RAM=24,HDD=256,VideoCardMemory=3,Cost=49000,Quantity=53} ,

            };

            //Выводим все компьютеры с указанным процессором и оперативной памятью
            List<Computer> computers = listComputer
               .Where(computer => computer.ProcessorType == processorType)
               .Where(computer => computer.RAM >= rAM)
               .ToList();

            computers = (from computer in computers
                         orderby computer.Cost
                         select computer).ToList();

            foreach (var c in computers)
            {
                Console.WriteLine($" Код: {c.Id}; Модель: {c.ModelName}; Тип процессора: {c.ProcessorType}; Частота процессора: {c.ProcessorFrequencies}; Оперативная память: {c.RAM}; HDD: {c.HDD}; Цена: {c.Cost}; Кол-во на складе: {c.Quantity};");
                
            }

            //Выводим весь список, сгруппированный по типу процессора

            Console.WriteLine("\nСписок сортированный по типу процессора :");
            List<Computer> computersSort = listComputer;

            //var computerGroupS = from computer in computersSort
            //                     group computer by computer.ProcessorType;
            var computerGroupS = computersSort.GroupBy(x => x.ProcessorType);

            foreach (IGrouping<string, Computer> c in computerGroupS)
            {
                Console.WriteLine($"\nТип процессора: {c.Key}");
                foreach (var g in c)
                {
                    Console.WriteLine($" Код: {g.Id}; Модель: {g.ModelName}; Тип процессора: {g.ProcessorType}; Частота процессора: {g.ProcessorFrequencies}; Оперативная память: {g.RAM}; HDD: {g.HDD}; Цена: {g.Cost}; Кол-во на складе: {g.Quantity};");
                }
            }

            //Выводим список с минимальной стоимостью
            Console.WriteLine("\nСписок с минимальной стоимостью");
            var min = listComputer.Min(n => n.Cost);
            listComputer.Where(m => m.Cost == min).ToList();

            List<Computer> computersMin = listComputer
            .Where(m => m.Cost == min).ToList();

            foreach (var g in computersMin)
            {
                Console.WriteLine($" Код: {g.Id}; Модель: {g.ModelName}; Тип процессора: {g.ProcessorType}; Частота процессора: {g.ProcessorFrequencies}; Оперативная память: {g.RAM}; HDD: {g.HDD}; Цена: {g.Cost}; Кол-во на складе: {g.Quantity};");
            }

            //Выводим список с максимальной стоимостью
            Console.WriteLine("\nСписок с максимальной стоимостью"); 
            var max = listComputer.Max(n => n.Cost);
            listComputer.Where(m => m.Cost == min).ToList();

            List<Computer> computersMax = listComputer
            .Where(m => m.Cost == max).ToList();

            foreach (var g in computersMax)
            {
                Console.WriteLine($" Код: {g.Id}; Модель: {g.ModelName}; Тип процессора: {g.ProcessorType}; Частота процессора: {g.ProcessorFrequencies}; Оперативная память: {g.RAM}; HDD: {g.HDD}; Цена: {g.Cost}; Кол-во на складе: {g.Quantity};");
            }

            //Определяем,есть ли хотя бы один компьютер в количестве не менее 30 штук?
            Console.WriteLine("\nСписок компьютеров в количестве не менее 30 шту"); 
            List<Computer> computersCount = listComputer
            .Where(m => m.Quantity >= 30).ToList();

            foreach (var g in computersCount)
            {
                Console.WriteLine($" Код: {g.Id}; Модель: {g.ModelName}; Тип процессора: {g.ProcessorType}; Частота процессора: {g.ProcessorFrequencies}; Оперативная память: {g.RAM}; HDD: {g.HDD}; Цена: {g.Cost}; Кол-во на складе: {g.Quantity};");
            }
            
            

            Console.ReadKey();
        }
    }
    
}

