using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_zadatak
{
   class Program
    {
        public class IntegerList : IIntegerList
        {
            private int[] _internalStorage;
            private int count;

            public int Count
            {
                get
                {
                    return count;
                }
            }

            public IntegerList()
            {
                this._internalStorage = new int[4];
            }

            public IntegerList(int initialSize)
            {
                this._internalStorage = new int[initialSize];
            }


            public void Add(int item)
            {
                bool full = true;
                
                for(int i = 0; i < this._internalStorage.Length; ++i)
                {
                    if (_internalStorage[i] == 0)
                    {
                        full = false;
                        count++;
                        _internalStorage[i] = item;
                        break;

                    }
                }

                if (full)
                {
                    int[] novi;
                    novi = new int[this._internalStorage.Length*2];
                    Array.Copy(this._internalStorage, novi, this._internalStorage.Length);
                    this._internalStorage = novi;
                    Add(item);
                }
            }

            public bool RemoveAt(int index)
            {
                if (index < 0 || index > this._internalStorage.Length || this._internalStorage[index] == 0)
                { 
                    return false;
                }

                for (int i = index; i < count-1; ++i)
                {
                    this._internalStorage[i] = this._internalStorage[i + 1];
                }
                this._internalStorage[count-1] = 0;
                count--;

                return true;

            }

            public bool Remove(int item)
            {
                for(int i = 0; i < count; ++i)
                {
                    if(this._internalStorage[i] == item)
                    {
                        RemoveAt(i);
                        return true;
                    }
                }
                
                return false;
            }

            public int GetElement(int index)
            {
                if(index > 0 && index < count)
                {
                    return this._internalStorage[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            public int IndexOf(int item)
            {
                for(int i = 0; i < count; ++i)
                {
                    if(this._internalStorage[i] == item)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public void Clear()
            {
                for(int i = 0; i < count; ++i)
                {
                    this._internalStorage[i] = 0;
                }
                count = 0;
            }

            public bool Contains(int item)
            {
                for(int i = 0; i < count; ++i)
                {
                    if(this._internalStorage[i] == item)
                    {
                        return true;
                    }
                }
                return false;
            }


        }

        public static void ListExample(IIntegerList listOfIntegers)
        {
            listOfIntegers.Add(1);
            listOfIntegers.Add(2);
            listOfIntegers.Add(3);
            listOfIntegers.Add(4);
            listOfIntegers.Add(5);
            // lista je [1,2,3,4,5]
            // Mičemo prvi element liste.
            listOfIntegers.RemoveAt(0);
            // Lista je [2,3,4,5]
            // Mičemo element liste čija je vrijednost "5".
            listOfIntegers.Remove(5);
            // Lista je [2,3,4]
            Console.WriteLine(listOfIntegers.Count);
            // 3
            Console.WriteLine(listOfIntegers.Remove(100));
            // false, nemamo element u vrijednosti 100
            Console.WriteLine(listOfIntegers.RemoveAt(5));
            // false, nemamo ništa na poziciji 5
            // Brišemo sav sadržaj kolekcije
            listOfIntegers.Clear();
            Console.WriteLine(listOfIntegers.Count);
            // 0

        }

        static void Main()
        {
            IntegerList lista = new IntegerList();

            ListExample(lista);
            Console.ReadKey();
        }
    }
}
