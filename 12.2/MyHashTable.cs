using ClassLibraryLabor10;
using System.Collections;
namespace _12._2
{
    internal class MyHashTable<T> where T : IInit, ICloneable, new()
    {
        Point<T>[] table;
        public int Capacity => table.Length;

        public MyHashTable(int length = 10)
        {
            table = new Point<T>[length];
        }

        public void AddRandomItems(int elementsCount)
        {
            Random random = new Random();

            for (int i = 0; i < elementsCount; i++)
            {
                T newItem = new T();
                newItem.RandomInit();

                AddPoint(newItem);
            }
        }

        public void PrintTable()
        {
            Console.WriteLine("Содержимое хэш-таблицы:");
            for (int i = 0; i < table.Length; i++)
            {
                Console.Write($"Ячейка {i}: ");

                if (table[i] != null)
                {
                    Console.WriteLine(table[i].Data);

                    Point<T> current = table[i].Next;
                    while (current != null)
                    {
                        Console.WriteLine(current.Data);
                        current = current.Next;
                    }
                }
                else
                {
                    Console.WriteLine("Пусто");
                }
            }
        }

        public int GetIndex(T data)
        {
            return Math.Abs(data.GetHashCode()) % Capacity;
        }

        public void AddPoint(T data)
        {
            int index = GetIndex(data);
            if (table[index] == null)
            {
                table[index] = new Point<T>(data);
            }
            else
            {
                Point<T> current = table[index];
                while (current.Next != null)
                {
                    if (current.Data.Equals(data))
                        return;
                    current = current.Next;
                }
                current.Next = new Point<T>(data);
                current.Next.Pred = current;
            }
        }

        public bool Contains(T data)
        {
            int index = GetIndex(data);
            if (table[index] == null)
            {
                Console.WriteLine("Хэш-таблица пуста.");
                return false;
            }

            if (table[index].Data.Equals(data))
                return true;

            Point<T> current = table[index];
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }

            return false;
        }

        public bool RemoveData(T data)
        {
            Point<T> current;
            int index = GetIndex(data);
            if (table[index] == null)
                return false;
            if (table[index].Data.Equals(data))
            {
                if (table[index].Next == null)
                    table[index] = null;
                else
                {
                    table[index] = table[index].Next;
                    table[index].Pred = null;
                }
                return true;
            }
            else
            {
                current = table[index];
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        Point<T> pred = current.Pred;
                        Point<T> next = current.Next;
                        pred.Next = next;
                        current.Pred = null;
                        if (next != null)
                        {
                            next.Pred = pred;
                            return true;
                        }
                    }
                    current = current.Next;
                }
                return false;
            }
        }
    }
}
