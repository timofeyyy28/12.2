using ClassLibraryLabor10;
using System.Collections;

namespace _12._2
{
    internal class Program
    {
        private static void PrintMenu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Сформировать хэш-таблицу");
            Console.WriteLine("2. Распечатать полученную хэш-таблицу");
        }
        
        static void Main(string[] args)
        {
            MyHashTable<Musicalinstrument> myhashtable = new MyHashTable<Musicalinstrument>();
            int answer = 0;
            while (answer != 3)
            {
                PrintMenu();
                if (!int.TryParse(Console.ReadLine(), out answer))
                {
                    Console.WriteLine("Неверный ввод. Повторите попытку.");
                    continue;
                }
                switch(answer)
                {
                    case 1:
                        
                        Console.WriteLine("хэш-таблица сформирована");
                        break;
                    case 2:
                        Console.WriteLine("Распечатывание хэш-таблицы:");
                        myhashtable.PrintTable();
                        break;

                }
            }
        }
    }
}
