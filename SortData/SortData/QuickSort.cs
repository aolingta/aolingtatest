using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortData
{
    class QuickSort
    {
        public static void QuickSortFunction(string[] a, int startIndex, int endIndex)
        {
            if (startIndex > endIndex)
                return;

            int keyIndex = Partion(a, startIndex, endIndex);
            QuickSortFunction(a, startIndex, keyIndex - 1);
            QuickSortFunction(a, keyIndex + 1, endIndex);
        }

        public static int Partion(string[] a, int startIndex, int endIndex)
        {
            string temp = "";
            int leftMaxIndex = startIndex - 1;
            string key = a[endIndex];

            for (int rightMaxIndex = startIndex; rightMaxIndex < endIndex; rightMaxIndex++)
            {
                //if (a[rightMaxIndex] <= key)
                if (string.Compare(a[rightMaxIndex],key) <0)
                {
                    // 小于等于key的放在左边
                    temp = a[leftMaxIndex + 1];
                    a[leftMaxIndex + 1] = a[rightMaxIndex];
                    a[rightMaxIndex] = temp;

                    leftMaxIndex++;
                }
            }

            // 交换标兵
            temp = a[leftMaxIndex + 1];
            a[leftMaxIndex + 1] = a[endIndex];
            a[endIndex] = temp;

            return leftMaxIndex + 1;
        }
    }
}
