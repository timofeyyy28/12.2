﻿using ClassLibraryLabor10;
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

                            AdditionalMenu(myhashtable);
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
            Musicalinstrument itemToDelete = null;
            Musicalinstrument itemToFind = new Musicalinstrument();

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
                        if (myhashtable != null)
                        {
                            Musicalinstrument itemForSearch = new Musicalinstrument();
                            Console.WriteLine("Введите экземпляр, который хотите найти");
                            itemForSearch.Init();
                            Point<Musicalinstrument> point = myhashtable.SearchItem(itemForSearch);
                            if (point != null)
                                Console.WriteLine($"Экземпляр найден. {point}");
                            else
                                Console.WriteLine("Экземпляр не найден");
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хеш-таблицу.");
                        }
                        break;

                    case 2:
                        if (itemToDelete != null)
                        {
                            if (myhashtable.RemoveData(itemToDelete))
                            {
                                Console.WriteLine("Элемент успешно удален.");
                                itemToDelete = null;
                            }
                            else
                            {
                                Console.WriteLine("Элемент не найден в хэш-таблице.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Сначала выполните поиск элемента перед удалением.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Возвращение в основное меню.");
                        break;

                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}