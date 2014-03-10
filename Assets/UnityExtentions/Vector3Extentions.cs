using UnityEngine;
using System.Collections;

public static class Vector3Extentions 
{
    public static void SetX(this Vector3 vec, float val)
    {
        vec.x = val;
    }

    public static void SetY(this Vector3 vec, float val)
    {
        vec.y = val;
    }

    public static void SetZ(this Vector3 vec, float val)
    {
        vec.z = val;
    }
}
