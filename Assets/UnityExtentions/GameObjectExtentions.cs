using UnityEngine;
using System.Collections;

public static class GameObjectExtentions 
{
    public static void SetRenderersInChildren(this GameObject obj, bool enabled)
    {
        foreach (var renderer in obj.GetComponentsInChildren<Renderer>(true))
        {
            renderer.enabled = enabled;
        }
    }

    public static void SetColidersInChildren(this GameObject obj, bool enabled)
    {
        foreach (var renderer in obj.GetComponentsInChildren<Collider>(true))
        {
            renderer.enabled = enabled;
        }
    }

    public static void SetColider2DsInChildren(this GameObject obj, bool enabled)
    {
        foreach (var renderer in obj.GetComponentsInChildren<Collider2D>(true))
        {
            renderer.enabled = enabled;
        }
    }

    public static GameObject FindParentWithTag(this GameObject obj, string tag, bool incluedSelf = false)
    {
        Transform parent = incluedSelf ? obj.transform : obj.transform.parent;
        while (parent != null)
        {
            if (parent.tag == tag) return parent.gameObject;
            parent = parent.transform.parent;
        }
        return null;
    }

    public static void SetLayerRecursive(this GameObject obj, int layer)
    {
        // todo make a non recursive version
        obj.layer = layer;
        foreach (Transform child in obj.transform)
        {
            child.gameObject.SetLayerRecursive(layer);
        }
    }
}
