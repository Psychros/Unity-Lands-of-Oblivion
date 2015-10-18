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
            if (Object.Equals(u, obj))
            {
                returned = true;
                break;
            }
        }
        return returned;
    }
}

