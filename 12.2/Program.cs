using ClassLibraryLabor10;
using System;
using System.Collections.Generic;

namespace _12._2
{
    internal class Program
    {
        private static void PrintMenu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Сформировать хэш-таблицу с случайными элементами");
            Console.WriteLine("2. Распечатать полученную хэш-таблицу");
            Console.WriteLine("3. Выход");
        }

        static void Main(string[] args)
        {
            MyHashTable<Musicalinstrument> myhashtable = null;
            int answer = 0;

            while (answer != 3)
            {
                PrintMenu();
                if (!int.TryParse(Console.ReadLine(), out answer))
                {
                    Console.WriteLine("Неверный ввод. Повторите попытку.");
                    continue;
                }

                switch (answer)
                {
                    case 1:
                        Console.WriteLine("Введите количество случайных элементов для добавления:");
                        int elementsCount;
                        if (!int.TryParse(Console.ReadLine(), out elementsCount))
                        {
                            Console.WriteLine("Неверный ввод числа элементов.");
                            break;
                        }
                        myhashtable = new MyHashTable<Musicalinstrument>();
                        myhashtable.AddRandomItems(elementsCount);
                        Console.WriteLine("Хэш-таблица сформирована с случайными элементами.");
                        break;

                    case 2:
                        if (myhashtable == null)
                        {
                            Console.WriteLine("Необходимо сначала сформировать хэш-таблицу.");
                        }
                        else
                        {
                            Console.WriteLine("Распечатывание хэш-таблицы:");
                            myhashtable.PrintTable();

                            AdditionalMenu(myhashtable); // Открываем сразу дополнительное меню после печати таблицы
                        }
                        break;

                    case 3:
                        Console.WriteLine("Программа завершена.");
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        private static void AdditionalMenu(MyHashTable<Musicalinstrument> myhashtable)
        {
            int answer = 0;
            while (answer != 3)
            {
                Console.WriteLine("Дополнительное меню:");
                Console.WriteLine("1. Поиск элемента");
                Console.WriteLine("2. Удаление элемента");
                Console.WriteLine("3. Вернуться в основное меню");

                if (!int.TryParse(Console.ReadLine(), out answer))
                {
                    Console.WriteLine("Неверный ввод. Повторите попытку.");
                    continue;
                }

                switch (answer)
                {
                    case 1:
                        Console.WriteLine("Введите имя музыкального инструмента для поиска:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите ID музыкального инструмента для поиска:");
                        int idNumber;
                        while (!int.TryParse(Console.ReadLine(), out idNumber))
                        {
                            Console.WriteLine("Неверный формат ID. Пожалуйста, введите целое число:");
                        }
                        IdNumber id = new IdNumber(idNumber);
                        Musicalinstrument itemToFind = new Musicalinstrument(name, id.number);

                        if (myhashtable.Contains(itemToFind)) 
                        {
                            Console.WriteLine("Элемент найден.");
                        }
                        else
                        {
                            Console.WriteLine("Элемент не найден.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Введите элемент для удаления:");
                        Musicalinstrument itemToDelete = new Musicalinstrument();
                        // Логика удаления
                        if (myhashtable.RemoveData(itemToDelete))
                        {
                            Console.WriteLine("Элемент успешно удален.");
                        }
                        else
                        {
                            Console.WriteLine("Элемент не найден в хэш-таблице.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Основное меню.");
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}