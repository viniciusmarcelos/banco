using System;

namespace ArrayLibrary
{
    public class ArrayLib
    {
        #region 1 Dimention
        ///returns an array iqual to the array imput + 1 length
        public static string[] AddOneLength(string[] array)
        {
            string[] newArray = new string[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }
        ///returns an array iqual to the array imput - 1 length
        public static string[] RemoveLast(string[] array)
        {
            string[] newArray = new string[array.Length - 1];
            for (int i = 0; i < array.Length - 1; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }
        ///prints the array using ", " between the elements, and "." after the last one
        public static void PrintArray(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + (i < (array.Length - 1) ? ", " : ".\n"));
            }
        }
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + (i < (array.Length - 1) ? ", " : ".\n"));
            }
        }
        ///prints an array with indexes, example: {name1 , name2 , name3} = "0. name1, 1. name2, 2. name3."
        public static void PrintArrayWithIndexes(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(i + ". " + array[i] + (i < (array.Length - 1) ? ", " : ".\n"));
            }
        }
        ///returns the position of the target or -1 if not found
        public static int Find_Ordinary(string[] array, string target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }
        ///returns the position of the target or -1 if not found. THE ARRAY WILL BE SORTED after using this.
        public static int Find_Binary(string[] array, string target)
        {
            //Method: sorts the array, checks in witch half target is, than witch half of that half, and so on until it finds it 
            int start = 0;
            int end = array.Length - 1;
            int mid = 0;
            SortArray_BubbleSort(array);
            do
            {
                mid = MiddlePosition(start, end);
                if (IsTheFirstSmaller(target, array[mid])) //checks if the inserted name is smaller than middle position string
                {
                    end = mid;
                }
                else
                {
                    start = mid;
                }
            }
            while (end - start > 1);
            if (array[end] == target)
            {
                return end;
            }
            else if (array[start] == target)
            {
                return start;
            }
            else return -1;
        }
        ///returns an array with the elements of piece1 followed by elements of piece2
        public static string[] Join(string[] piece1, string[] piece2)
        {
            string[] jointedPieces = new string[(piece1.Length + piece2.Length)];
            for (int i = 0; i < piece1.Length; i++)
            {
                jointedPieces[i] = piece1[i];
            }
            for (int i = 0; i < piece2.Length; i++)
            {
                jointedPieces[(piece1.Length + i)] = piece2[i];
            }
            return jointedPieces;
        }
        ///removes empty strings from the array, reducing it's size
        public static string[] Trim(string[] array)
        {
            int voidlessArraySize = 0;
            int pos = 0; //position to record on the voidless array
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != "")
                {
                    voidlessArraySize++;
                }
            }
            string[] voidlessArray = new string[voidlessArraySize];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != "")
                {
                    voidlessArray[pos] = array[i];
                    if (pos < voidlessArraySize)
                    {
                        pos++;
                    }
                }
            }
            return voidlessArray;
        }
        ///fills all slots of the array with the fillingText
        public static string[] Fill(string[] array, string fillinglText)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = fillinglText;
            }
            return array;
        }
        ///sorts an array with Bubble Sort method, this is the enhanced version
        public static string[] SortArray_BubbleSort(string[] array)
        {
            int iMax = array.Length - 1;
            int lastSwap = 0;
            do
            {
                lastSwap = 0;
                for (int i = 0; i < iMax; i++)
                {
                    if (!IsTheFirstSmaller(array[i], array[i + 1]))
                    {
                        SwapPositions(array, i, i + 1);
                        lastSwap = i;
                    }
                }
                iMax = lastSwap;
            }
            while (lastSwap != 0);
            return array;
        }
        ///by finding the smallest string then swaping it with the first one on the array, and so on
        public static string[] SortArray_InsertionSort(string[] array)
        {
            int lastOrdered = 0;
            do
            {
                int smallestIndex = lastOrdered;
                for (int i = lastOrdered; i < array.Length - 1; i++)
                {
                    if (!IsTheFirstSmaller(array[smallestIndex], array[i + 1]))
                    {
                        smallestIndex = i + 1;
                    }
                }
                SwapPositions(array, lastOrdered++, smallestIndex);
            }
            while (lastOrdered < array.Length - 1);
            return array;
        }
        ///swaps positions between elements in position1 and position2
        private static string[] SwapPositions(string[] array, int position1, int position2)
        {
            string aux = null;
            aux = array[position1];
            array[position1] = array[position2];
            array[position2] = aux;
            return array;
        }
        ///checks if string1 is smaller than string2, returns true or false
        private static bool IsTheFirstSmaller(string string1, string string2)
        {
            bool smaller = true;
            bool smallerFound = false;
            int a = 0;
            int max = string1.Length > string2.Length ? string2.Length : string1.Length; //uses the smaller length vallue
            do
            {
                if (string1[a] > string2[a])
                {
                    smaller = false;
                    smallerFound = true;
                }
                else if (string1[a] < string2[a])
                {
                    smaller = true;
                    smallerFound = true;
                }
                else
                {
                    a++;
                }
            }
            while (!smallerFound && a < max);
            if (!smallerFound)
            {
                smaller = string1.Length > string2.Length ? false : true; //if all the compared characters are equal, then the string with less characters is the smaller
            }
            return smaller;
        }
        ///returns the average between number1 and number2
        private static int MiddlePosition(int number1, int number2)
        {
            return (number1 + number2) / 2;
        }
        #endregion
        #region 2 Dimention
        //public static string[,] AddData(string[,] array, int dimentionToInsert)
        //{
        //    int i = 0;
        //    do
        //    {
        //        a[i] = Console.ReadLine();
        //        if (a[i] == "")
        //        {
        //            a = RemoveLast(a);
        //            break;
        //        }
        //        Console.WriteLine("O nome {0} foi adicionado. Total de {1} nomes.\n" +
        //                        "Entre com o próximo nome, ou apenas ENTER se terminou:", a[i], a.Length);
        //        a = AddOneLength(a);
        //        i++;
        //    }
        //    while (true);
        //    return a;
        //}
        ///returns a 2D array iqual to the 2D array imput + 1 length on the (0) position
        public static string[,] AddOneLength(string[,] array)
        {
            string[,] newArray = new string[array.GetLength(0) + 1, array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    newArray[i, x] = array[i, x];
                }
            }
            return newArray;
        }
        public static decimal[,] AddOneLength(decimal[,] array)
        {
            decimal[,] newArray = new decimal[array.GetLength(0) + 1, array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    newArray[i, x] = array[i, x];
                }
            }
            return newArray;
        }
        /// <summary>
        /// Removes the last line of a string [line,column].
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string[,] RemoveLast(string[,] array)
        {
            string[,] newArray = new string[array.GetLength(0) - 1, array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0) - 1; i++)
            {
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    newArray[i, x] = array[i, x];
                }
            }
            return newArray;
        }
        public static decimal[,] RemoveLast(decimal[,] array)
        {
            decimal[,] newArray = new decimal[array.GetLength(0) - 1, array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0) - 1; i++)
            {
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    newArray[i, x] = array[i, x];
                }
            }
            return newArray;
        }
        ///prints the 2D array using ", " between the position (1),
        ///";\n" between the position (0) and ".\n" for the last one
        public static void PrintArray(string[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    Console.Write(array[i, x]);
                    if (x < array.GetLength(1) - 1)
                    {
                        Console.Write(", ");
                    }
                    else if (i != array.GetLength(0) - 1)
                    {
                        Console.Write(";\n");
                    }
                    else
                    {
                        Console.Write(".\n");
                    }
                }
            }
        }
        ///prints the 2D array using ", " between the position (1),
        ///";\n" between the position (0) and ".\n" for the last one
        public static void PrintArray(decimal[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    Console.Write(array[i, x]);
                    if (x < array.GetLength(1) - 1)
                    {
                        Console.Write(", ");
                    }
                    else if (i != array.GetLength(0) - 1)
                    {
                        Console.Write(";\n");
                    }
                    else
                    {
                        Console.Write(".\n");
                    }
                }
            }
        }
        //public static void PrintArrayWithIndexes(string[] array) //prints an array with indexes, example: {name1 , name2 , name3} = "0. name1, 1. name2, 2. name3."
        //{
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        Console.Write(i + ". " + array[i] + (i < (array.Length - 1) ? ", " : ".\n"));
        //    }
        //}
        /// <summary>
        /// Imput a string [line,column], a target and the column to search it in. 
        /// Returns the line in which the target is at or -1 if not found.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="target"></param>
        /// <param name="columnTargetIs"></param>
        /// <returns></returns>
        public static int Find_Ordinary(string[,] array, string target, int columnTargetIs)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i, columnTargetIs] == target)
                {
                    return i;
                }
            }
            return -1;
        }
        public static int Find_Ordinary(decimal[,] array, decimal target, int columnTargetIs)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i, columnTargetIs] == target)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Returns the position of the target or -1 if not found. THE ARRAY WILL BE SORTED after using this. 
        /// Method: sorts the array, checks in witch half target is, than witch half of that half, and so on until it finds it. 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="target"></param>
        /// <param name="columnTargetIs":></param>
        /// <returns></returns>
        public static int Find_Binary(string[,] array, string target, int columnTargetIs)
        {
            int start = 0;
            int end = array.GetLength(0) - 1;
            int mid = 0;
            SortArray_BubbleSort(array,columnTargetIs);
            do
            {
                mid = MiddlePosition(start, end);
                if (IsTheFirstSmaller(target, array[mid,columnTargetIs])) //checks if the inserted name is smaller than middle position string
                {
                    end = mid;
                }
                else
                {
                    start = mid;
                }
            }
            while (end - start > 1);
            if (array[end,columnTargetIs] == target)
            {
                return end;
            }
            else if (array[start,columnTargetIs] == target)
            {
                return start;
            }
            else return -1;
        }
        //public static string[] Join(string[] piece1, string[] piece2) //returns an array with the elements of piece1 followed by elements of piece2
        //{
        //    string[] jointedPieces = new string[(piece1.Length + piece2.Length)];
        //    for (int i = 0; i < piece1.Length; i++)
        //    {
        //        jointedPieces[i] = piece1[i];
        //    }
        //    for (int i = 0; i < piece2.Length; i++)
        //    {
        //        jointedPieces[(piece1.Length + i)] = piece2[i];
        //    }
        //    return jointedPieces;
        //}
        //public static string[] Trim(string[] array) //removes empty strings from the array, reducing it's size
        //{
        //    int voidlessArraySize = 0;
        //    int pos = 0; //position to record on the voidless array
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        if (array[i] != "")
        //        {
        //            voidlessArraySize++;
        //        }
        //    }
        //    string[] voidlessArray = new string[voidlessArraySize];
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        if (array[i] != "")
        //        {
        //            voidlessArray[pos] = array[i];
        //            if (pos < voidlessArraySize)
        //            {
        //                pos++;
        //            }
        //        }
        //    }
        //    return voidlessArray;
        //}
        //public static string[] Fill(string[] array, string fillinglText) //fills all slots of the array with the fillingText
        //{
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        array[i] = fillinglText;
        //    }
        //    return array;
        //}
        /// <summary>
        /// Sorts the array by the order of the elements from columnToSort.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="columnToSort"></param>
        /// <returns></returns>
        public static string[,] SortArray_BubbleSort(string[,] array, int columnToSort) 
        {
            int iMax = array.GetLength(0) - 1;
            int lastSwap = 0;
            do
            {
                lastSwap = 0;
                for (int i = 0; i < iMax; i++)
                {
                    if (!IsTheFirstSmaller(array[i,columnToSort], array[i + 1,columnToSort]))
                    {
                        SwapLines(array, i, i + 1);
                        lastSwap = i;
                    }
                }
                iMax = lastSwap;
            }
            while (lastSwap != 0);
            return array;
        }
        //public static string[] SortArray_InsertionSort(string[] array) //by finding the smallest string then swaping it with the first one on the array, and so on
        //{
        //    int lastOrdered = 0;
        //    do
        //    {
        //        int smallestIndex = lastOrdered;
        //        for (int i = lastOrdered; i < array.Length - 1; i++)
        //        {
        //            if (!IsTheFirstSmaller(array[smallestIndex], array[i + 1]))
        //            {
        //                smallestIndex = i + 1;
        //            }
        //        }
        //        SwapPositions(array, lastOrdered++, smallestIndex);
        //    }
        //    while (lastOrdered < array.Length - 1);
        //    return array;
        //}
        /// <summary>
        /// Imputs string[line,column] and swaps the position of all of the elements from the line position1 to line position2.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="position1"></param>
        /// <param name="position2"></param>
        /// <returns></returns>
        public static string[,] SwapLines(string[,] array, int line1, int line2)
        {
            string aux = null;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                aux = array[line1, i];
                array[line1, i] = array[line2, i];
                array[line2, i] = aux;
            }
            return array;
        }
        public static decimal[,] SwapLines(decimal[,] array, int line1, int line2)
        {
            decimal aux = 0;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                aux = array[line1, i];
                array[line1, i] = array[line2, i];
                array[line2, i] = aux;
            }
            return array;
        }
        #endregion
    }
}