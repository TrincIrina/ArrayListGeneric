using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListGeneric
{
    internal class ArrayList<T> 
    {
        // Поля
        public int Capacity { get; set; }    // вместимость массива
        private int size;                    // фактическое количество элементов
        private T[] data;                    // данные массива
        private const int K = 2;             // коэфициент расширения
        private const int minCapacity = 4;   // минимальный размер массива, устанавливается,
                                             // если в пустой массив добавляют элемент

        // Конструктор по умолчанию, задаёт размер равный 0
        public ArrayList()
            : this(0) { } 
        // Конструктор инициализирует пустой массив с указанной начальной ёмкостью
        public ArrayList(int capacity)
        {
            Capacity = capacity;
            size = 0;
            data = new T[Capacity];            
        }
        // Инициализирует новый объект, который содержит элементы,
        // скопированные из указанного массива, и обладает начальной емкостью,
        // равной количеству скопированных элементов.
        public ArrayList(T[] data)
            : this(data.Length)
        {            
            for(int i = 0;  i < Capacity; i++)
            {
                this.data[size++] = data[i];
            }
        }

        // Проверка: есть ли элемент с таким индексом
        public bool DataIndex(int index)
        {
            return index < size;
        }

        //Свойства массива
        public int GetSize()   // Возвращает количество элементов в массиве
        {
            return size;
        }
        public T GetElem(int index)    // Возвращает элемент массива по индексу
        {
            if (DataIndex(index))
            {
                return data[index];
            }
            throw new ArgumentException("There is no element with such an index.");
        }
        public void SetElem(int index, T value)  // Устанавливает элемент массива по индексу
        {
            if (DataIndex(index))
            {
                data[index] = value;
            }
            else
            {
                throw new ArgumentException("The index has gone beyond the boundaries of the array.");
            }
        }
        
        // Добавление элемента в конец массива
        public bool AddBack(T value)
        {
            if (Capacity == 0)
            {
                Capacity = minCapacity;
            }
            if (size < Capacity)
            {
                T[] arr = new T[Capacity];
                for (int i = 0; i < size; i++)
                {
                    arr[i] = data[i];
                }
                arr[size++] = value;                
                data = arr;
                return true;
            }
            if(size == Capacity)
            {
                Capacity *= K;
                T[] arr = new T[Capacity];
                for(int i = 0; i < size; i++)
                {
                    arr[i] = data[i];
                }
                arr[size++] = value;                
                data = arr;
                return true;
            }
            return false;
        }
        // Добавление массива
        public void AddArrayBack(T[] data)
        {
            for(int j = 0; j < data.Length; j++)
            {
                AddBack(data[j]);
            }           
        }
        // Добавление элемента по индексу
        public void AddIndex(int index, T value)
        {
            if (size == 0)
            {
                return;
            }
            if (DataIndex(index))
            {
                if (size < Capacity)
                {
                    T[] arr = new T[Capacity];
                    for (int i = 0; i < index; i++)
                    {
                        arr[i] = data[i];
                    }
                    arr[index] = value;
                    for(int i = index; i < size; i++)
                    {
                        arr[i + 1] = data[i];
                    }
                    size++;
                    data = arr;                    
                }
                if (size == Capacity)
                {
                    Capacity *= K;
                    T[] arr = new T[Capacity];
                    for (int i = 0; i < index; i++)
                    {
                        arr[i] = data[i];
                    }
                    arr[index] = value;
                    for (int i = index; i < size; i++)
                    {
                        arr[i + 1] = data[i];
                    }
                    size++;
                    data = arr;
                } 
            }
        }
        // Добавление массива по индексу
        public void AddArrayIndex(int index, T[] data)
        {
            for(int i = 0; i < data.Length; i++)
            {
                AddIndex(index++, data[i]);
            }
        }
        // Удаление последнего элемента массива
        public bool DeleteBack()
        {
            if(size == 0)
            {
                return false;
            }            
            size--;
            return true;
        }
        // Удаление элемента по индексу
        public void DeleteElem(int index)
        {
            T[] arr = new T[Capacity];
            for(int i = 0; i < index; i++)
            {
                arr[i] = data[i];
            }
            for(int i = index + 1; i < size; i++)
            {
                arr[i - 1] = data[i];
            }            
            size--;
            data = arr;
        }
        // Удаление диапозона элементов, передаётся индекс первого
        // удаляемого элемента и последнего
        public void DeleteRange(int ind1,int ind2)
        {
            T[] arr = new T[Capacity];
            for (int i = 0; i < ind1; i++)
            {
                arr[i] = data[i];
            }
            for (int i = ind2 + 1, j = ind1; i < size; i++, j++)
            {
                arr[j] = data[i];
            }
            size -= (ind2 - ind1 + 1);
            data = arr;
        }

        // Метод уменьшения вместимости массива до фактического количества элементов
        public void Shrink()
        {
            Capacity = size;
        }

        // Возвращает строку, представляющую текущий объект
        public override string ToString()
        {
            string str = null;
            for(int i = 0; i < size; i++)
            {
                str += Convert.ToString(data[i] + " ");
            }
            return str;
        }
    }
}
