using System;
using System.Collections.Generic;
using ClassLibraryLabor10;

namespace _12._2
{
    internal class MyHashTable<T> where T : IInit, ICloneable, new()
    {
        Point<T>[] table;
        public int Capacity => table.Length;
        private int size;
        private int count;
        public int Size
        {
            get { return size; }
            set
            {
                if (value > 100)
                    size = 100;
                else
                {
                    if (value > 0)
                        size = value;
                    else
                        size = 1;
                }
            }
        }
        public MyHashTable(int size)
        {
            Size = size;
            table = new Point<T>[Size];
        }
        public Point<T> SearchItem(T itemToFind)
        {
            int index = GetIndex(itemToFind);
            if (table[index] == null)
                return default;
            else
            {
                while (true)
                {
                    if (table[index].Data.Equals(itemToFind))
                        return table[index];
                    table[index] = table[index].Next;
                    if (table[index] == null)
                        return default;
                }
            }
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
            if (table != null)
            {
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i] != null)
                    {
                        Console.WriteLine($"{i}: {table[i]}");
                        if (table[i].Next != null)
                        {
                            Point<T> current = table[i].Next;
                            while (current != null)
                            {
                                Console.WriteLine($"   {current.Data}");
                                current = current.Next;
                            }
                        }
                    }
                    else { Console.WriteLine($"{i}: Нет элемента"); }
                }
            }
            else
            {
                throw new Exception("Таблица удалена");
            }
        }

        public int GetIndex(T item)
        {
            return Math.Abs(item.GetHashCode()) % table.Length;
        }

        public void AddPoint(T data)
        {
            int index = GetIndex(data);
            if (table[index] == null)
            {
                table[index] = new Point<T>(data);
                table[index].Data = data;
                count++;
            }
            else
            {
                Point<T> current = table[index];
                if (current.Data.Equals(data))
                    return;
                while (current.Next != null)
                {                   
                    current = current.Next;
                }
                current.Next = new Point<T>(data);
                current.Next.Pred = current;
                count++;
            }
        }

        public bool Contains(T data)
        {
            int index = GetIndex(data);
            if (table == null)
                throw new Exception("empty table");
            if (table[index] == null) //цепочка пустая, элемента
                return false;
            if (table[index].Data.Equals(data)) //попали на нужный
                return true;
            else
            {
                Point<T> current = table[index];//идем по цепочке
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
                return false;
            }
        }

        public bool RemoveData(T data)
        {
            if (table == null)
                throw new Exception("empty table");
            int index = GetIndex(data);
            if (table[index] == null)
                return false;
            if (table[index].Data.Equals(data))
            {
                if (table[index].Next == null)
                {
                    table[index] = null;
                }
                else
                {
                    table[index] = table[index].Next;
                    table[index].Pred = null;
                }
                count--;
                return true;
            }
            Point<T> current = table[index];
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    Point<T> pred = current.Pred;
                    Point<T> next = current.Next;
                    pred.Next = next;
                    if (next != null)
                        next.Pred = pred;
                    current.Pred = null;
                    count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
    }
}