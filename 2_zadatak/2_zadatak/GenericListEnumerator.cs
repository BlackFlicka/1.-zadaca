using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_zadatak
{
    class GenericListEnumerator<X> : IEnumerator<X>
    {
        private IGenericList<X> _collection;
        private int _index = 0;

        public GenericListEnumerator(IGenericList<X> collection)
        {
            _collection = collection;
        }

        public bool MoveNext()
        {
            _index++;
            return (_index < _collection.Count);
            // Zove se prije svake iteracije.
            // Vratite true ako treba ući u iteraciju, false ako ne
            // Hint: čuvajte neko globalno stanje po kojem pratite gdje se
            // nalazimo u kolekciji
        }

        public X Current
        {
            get
            {
                return _collection.GetElement(_index);
                // Zove se na svakom ulasku u iteraciju
                // Hint: Koristite stanje postavljeno u MoveNext() dijelu
                // kako bi odredili što se zapravo vraća u ovom koraku
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
            // Ignorirajte
        }

        public void Reset()
        {
            // Ignorirajte
        }
    }
}
