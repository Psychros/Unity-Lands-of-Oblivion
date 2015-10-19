using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Util
{
    public static Boolean contains<T, U>(T obj, U[] array)
    {
        if (array == null) return false;
        Boolean returned = false;
        foreach (U u in array)
        {
            if (u.GetHashCode() == obj.GetHashCode())
            {
                returned = true;
                break;
            }
        }
        return returned;
    }

    public static T[] getDifferences<T>(T[] array1, T[] array2)
    {
        if (array1 == null || array2 == null) return null;
        List<T> tempList = new List<T>();

        foreach (T tempT1 in array1)
        {
            if (tempT1 != null)
            {
                foreach (T tempT2 in array2)
                {
                    if (tempT1.GetHashCode() == tempT2.GetHashCode())
                    {
                        tempList.Add(tempT1);
                        break;
                    }
                }
            }
        }
        return tempList.ToArray();
    }
}

