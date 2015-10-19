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

    public static  Identifyable[] getDifferences(Identifyable[] array1, Identifyable[] array2)
    {
        if (array1 == null || array2 == null) return null;
        List<Identifyable> tempList = new List<Identifyable>();
        Boolean tempBool;

        foreach (Identifyable temp1 in array1)
        {
            tempBool = false;
            if (temp1 != null)
            {
                foreach (Identifyable temp2 in array2)
                {
                    if (temp2 != null && temp1.id == temp2.id)
                    {
                        tempBool = true;
                        break;
                    }
                }
                if (!tempBool) tempList.Add(temp1);
            }
        }
        return tempList.ToArray();
    }
}

