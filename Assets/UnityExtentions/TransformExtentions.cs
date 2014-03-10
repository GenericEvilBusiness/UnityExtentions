using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class TransformExtentions
{
    public static Transform FindInChildren(this Transform transform, string name)
    {
        // Heres a smart Linq version, for reference. Not yet tested the performance of this vs the current code
        //return (from x in t.gameObject.GetComponentsInChildren<Transform>()
        //        where x.gameObject.name == name
        //        select x.gameObject).First().transform;

        Transform[] children;
        if (!transform.active)
        {
            // Corner case. GetComponentsInChildren will only work if the game object is active.
            children = transform.GetChildrenWhilstInactive().ToArray<Transform>();
        }
        else
        {
            // Otherwise get children by asking unity for all Transform component children
            children = transform.GetComponentsInChildren<Transform>();
        }

        foreach (Transform child in children)
        {
            if (child.name == name)
                return child;
        }

        // Not found anything with a matching name, return null.
        return null;
    }

    public static List<Transform> GetChildrenWhilstInactive(this Transform transform, List<Transform> list = null)
    {
        // TODO Provide a non recursive version of this method.
        if (list == null)
        {
            list = new List<Transform>();
        }

        foreach (Transform child in transform)
        {
            list.Add(child);
            GetChildrenWhilstInactive(child, list);
        }

        return list;
    }

    public static void DestroyChildren(this Transform transform, bool immediate = false)
    {
        foreach (Transform child in transform)
        {
            if (immediate)
                GameObject.DestroyImmediate(child.gameObject);
            else
                GameObject.Destroy(child.gameObject);
        }
    }

    public static T FindComponentInParents<T>(this Transform transform) where T : Component
    {
        // TODO Provide a getComponents version!
        var t = transform;
        while (t != null)
        {
            var ret = t.GetComponent<T>();
            if (ret != null)
                return ret;
            t = t.parent;
        }

        return null;
    }
}
