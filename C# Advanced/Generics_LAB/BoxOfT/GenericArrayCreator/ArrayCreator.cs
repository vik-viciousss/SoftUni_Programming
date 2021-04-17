﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int lenght, T item) where T : 
        {
            T[] array = new T[lenght];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = item;
            }

            return array;
        }
    }
}
