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
            Console.WriteLine("1. Сформировать хэш-таблицу со случайными элементами");
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
                        try
                        {
                            Console.Write("Введите количество ячеек: ");
                            int length = int.Parse(Console.ReadLine());

                            
                            if (length <= 0)
                            {
                                Console.WriteLine("Некорректный ввод. Количество ячеек должно быть больше 0.");
                                break;
                            }

                            myhashtable = new MyHashTable<Musicalinstrument>(length);

                            Console.Write("Введите количество элементов, которые вы хотите создать: ");
                            int countOfElements = int.Parse(Console.ReadLine());
                            for (int i = 0; i < countOfElements; i++)
                            {
                                Musicalinstrument mi = new Musicalinstrument();
                                mi.RandomInit();
                                myhashtable.AddPoint(mi);
                                mi.Name = "hhh";

                            }

                            Console.WriteLine("Хеш-таблица создана.");
                        }
                        catch
                        {
                            Console.WriteLine("Некорректный ввод для создания хеш-таблицы.");
                        }
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

            Musicalinstrument itemToFind = new Musicalinstrument();

            int answer = 0;
            while (answer != 4)
            {
                Console.WriteLine("Дополнительное меню:");
                Console.WriteLine("1. Поиск элемента");
                Console.WriteLine("2. Удаление элемента");
                Console.WriteLine("3. Добавление элемента");
                Console.WriteLine("4. Вернуться в основное меню");

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
                                Console.WriteLine("Экземпляр не найден.");
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хеш-таблицу.");
                        }
                        break;

                    case 2:
                        if (myhashtable != null)
                        {
                            Musicalinstrument itemToDelete = new Musicalinstrument();
                            Console.WriteLine("Введите экземпляр для удаления:");
                            itemToDelete.Init();

                            if (myhashtable.RemoveData(itemToDelete))
                            {
                                Console.WriteLine("Элемент успешно удален.");
                            }
                            else
                            {
                                Console.WriteLine("Элемент не найден в хэш-таблице.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хэш-таблицу.");
                        }
                        break;
                    case 3:
                        if (myhashtable != null)
                        {
                            Musicalinstrument itemToAdd = new Musicalinstrument();
                            Console.WriteLine("Введите экземпляр, который хотите добавить");
                            itemToAdd.Init();
                            myhashtable.AddPoint(itemToAdd);
                            Console.WriteLine("Экземпляр добавлен");
                        }
                        else
                        {
                            Console.WriteLine("Сначала сформируйте хеш-таблицу.");
                        }
                        break;
                        break;
                    case 4:
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