using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.MyList
{
    class MyList<T>
    {
        int count = 0; //количество содержащихся элементов в массиве, размер массива

        public int Count { get => count; }

        T[] mass = new T[1]; //обобщенный массив.

        //int position = -1; //позиция перебора начинается с -1 индекса
        int pos = -1; //по этой позиции производится запись в массив

        public void Insert(int index, T item) // вставляет элемент item в списке на позицию index
        {
            count++;
            pos++;
            Array.Resize(ref this.mass, count);
            for (int i = count - 1; i > index; i--)
            {
                this.mass[i] = this.mass[i - 1];
            }

            this.mass[index] = item;
        }

        public bool RemoveAt(int index) // удаление элемента по указанному индексу
        {
            if (count >= index)
            {
                for (int i = index + 1; i < count; i++)
                {
                    this.mass[i - 1] = this.mass[i];
                }

                count--;
                pos--;
                Array.Resize(ref this.mass, count);
                return true;
            }

            return false;
        }

        public bool Remove(T item) // удаляет первое вхождение в массив  1 2 3 4 5 2 3 1 (2) =   
        {
            int my_index = IndexOf(item);
            if (my_index != -1)
            {
                RemoveAt(my_index);
            }

            return false;
        }

        public int IndexOf(T item) //метод поиска элемента в массиве
        {
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void AddRange(T[] arr)// добавление эллементов массива в конец списока
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Add(arr[i]);
            }
        }

        public void Sort() // (Т приводим в double)сортировка по возрастанию (сортировка Пузырьком)
        {
            T temp;

            for (int write = 0; write < this.mass.Length; write++)
            {
                for (int sort = 0; sort < this.mass.Length - 1; sort++)
                {
                    try
                    {
                        if (Convert.ToDouble(this.mass[sort]) > Convert.ToDouble(this.mass[sort + 1]))
                        {
                            temp = this.mass[sort + 1];
                            this.mass[sort + 1] = this.mass[sort];
                            this.mass[sort] = temp;
                        }
                    }
                    catch (Exception)
                    {
                        break;
                    }
                }
            }
        }

        public void Add(T mass) //метод добавления в массив элемента
        {
            count++;  //увеличиваем размер массива
            Array.Resize(ref this.mass, count);
            pos++; //увеличиваем индекс
            this.mass[pos] = mass; //добавляем значение
        }

        public IEnumerator GetEnumerator()// итератор 
        {
            return mass.GetEnumerator();
        }

        public void Clear() //метод очистки массива и обнуления всех счетчико
        {
            mass = new T[1];
            count = 0;
            pos = -1;
        }

        public T this[int index]  //тут создали индексатор
        {
            get { return mass[index]; }
            set { mass[index] = value; }
        }
    }
}
