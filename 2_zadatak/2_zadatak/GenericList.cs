using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_zadatak
{

        public class GenericList<X> : IGenericList<X>
        {
            private X[] _internalStorage;
            private int count;
            public int size;

            public int Count
            {
                get
                {
                    return count;
                }
            }

            public GenericList()
            {
                this._internalStorage = new X[4];
                size = 4;
            }

            public GenericList(int initialSize)
            {
                this._internalStorage = new X[initialSize];
                size = initialSize;
            }


            public void Add(X item)
            {

                if(size == count)
                {
                    size *= 2;
                    X[] novi = new X[size];
                    Array.Copy(this._internalStorage, novi, this._internalStorage.Length);
                    this._internalStorage = novi;
                    Add(item);
                }
                else
                {
                    this._internalStorage[count] = item;
                    count++;
                }
            }

            public bool RemoveAt(int index)
            {
                if (index < 0 || index > size || this._internalStorage[index] == null)
                {
                    return false;
                }

                for (int i = index; i < count - 1; ++i)
                {
                    this._internalStorage[i] = this._internalStorage[i + 1];
                }
                this._internalStorage[count - 1] = default(X);
                count--;

                return true;

            }

            public bool Remove(X item)
            {
                for (int i = 0; i < count; ++i)
                {
                    if (this._internalStorage[i].Equals(item))
                    {
                        RemoveAt(i);
                        return true;
                    }
                }

                return false;
            }

            public X GetElement(int index)
            {
                if (index > 0 && index < count)
                {
                    return this._internalStorage[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            public int IndexOf(X item)
            {
                for (int i = 0; i < count; ++i)
                {
                    if (this._internalStorage[i].Equals(item))
                    {
                        return i;
                    }
                }
                return -1;
            }

            public void Clear()
            {
                for (int i = 0; i < count; ++i)
                {
                    this._internalStorage[i] = default(X);
                }
                count = 0;
            }

            public bool Contains(X item)
            {
                for (int i = 0; i < count; ++i)
                {
                    if (this._internalStorage[i].Equals(item))
                    {
                        return true;
                    }
                }
                return false;
            }

            public IEnumerator<X> GetEnumerator()
            {
                return new GenericListEnumerator<X>(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

    }


        

}
