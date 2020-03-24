using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    // The instance is only accessible by the getter
    private static T mInstance;
    public static bool mIsQuitting;

    public static T Instance
    {
        get
        {
            if (mInstance == null)
            {
                // Making sure that there's not other instances of the same type in memory
                mInstance = FindObjectOfType<T>();

                if (mInstance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    mInstance = obj.AddComponent<T>();
                }
            }
            return mInstance;
        }
    }

    // Virtual Awake() that can be overridden in a derived class
    public virtual void Awake()
    {
        if (mInstance == null)
        {
            // If null, this instance is now the Singleton instance
            // +
        }
    }
}
