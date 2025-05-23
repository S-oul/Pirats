using System;
using UnityEngine;

public class Manager<T> : MonoBehaviour where T : Component
{ 
    public static T Instance;
    public virtual void Awake()
    {
        if (Instance == null) Instance = this as T;
        else
        {
            Debug.LogWarning("There is more than one " + typeof(T).Name + " in the scene. Destroying this one.");
            DestroyImmediate(gameObject);
            return;
        }
    }
}
