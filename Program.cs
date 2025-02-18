using PJT2502181;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L20250218
{
    class DynamicArray
    {
        public DynamicArray()
        {

        }

        ~DynamicArray()
        {

        }

        //objects
        //[1][2][3]
        // ^  ^  ^  ^
        //newObjects
        //[1][2][3][][][]
        //          ^
        //objects <- newObjects 
        //[1][2][3][4][][]
        //          ^
        public void Add(Object inObject)
        {
            if (count >= objects.Length)
            {
                ExtendSpace();
            }
            objects[count] = inObject;
            count++;
        }

        protected void ExtendSpace()
        {
            //배열 늘이기
            //이전 정보 옮기기
            Object[] newObject = new Object[objects.Length * 2];
            //이전값 이동
            for (int i = 0; i < objects.Length; ++i)
            {
                newObject[i] = objects[i];
            }
            objects = null;
            objects = newObject;
        }

        //[][][][][]
        public bool Remove(Object removObject)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (removObject == objects[i])
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                for (int i = index; i < Count - 1; ++i)
                {
                    objects[i] = objects[i + 1];
                }
                count--;
                return true;
            }
            return false;
        }

        // [1][2][3][4]
        // Insert(2, 5);
        // => [1][2][3][5][4]
        public void Insert(int pInsertIndex, Object pObject)
        {
            #region 내 코드
            //Add(pObject);
            //if (pInsertIndex > Count) return;

            //for (int i = Count; i > pInsertIndex + 1; --i)
            //{
            //    objects[i] = objects[i - 1];
            //}
            //objects[pInsertIndex + 1] = pObject;
            //count++;
            #endregion
            #region 강사님 코드

            if (objects.Length == count)
            {
                ExtendSpace();
            }

            for (int i = count; i > pInsertIndex; --i)
            {
                objects[i] = objects[i - 1];
            }
            objects[pInsertIndex + 1] = pObject;
            count++;
            #endregion
        }

        protected Object[] objects = new Object[3];

        protected int count = 0;
        public int Count
        {
            get
            {
                return count;
            }
        }

        public Object this[int index]
        {
            get
            {
                return objects[index];
            }
            set
            {
                if (index < objects.Length)
                {
                    objects[index] = value;
                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            //[] ->                  variable
            //[][][][][]             array -> Array
            //[][][][][][][][][][]   DynamicArray
            //DataStructure          자료구조
            
            TDynamicArray<int> a = new TDynamicArray<int>();
            for (int i = 0; i < 10; ++i)
            {
                a.Add(i);
            }

            TDynamicArray<GameObject> gameObjects = new TDynamicArray<GameObject>();

            GameObject testObject = new GameObject();
            gameObjects.Add(testObject);
            gameObjects.Remove(testObject);




            for (int i = 0; i < a.Count; ++i)
            {
                Console.Write(a[i] + ", ");
            }
        }
    }
}