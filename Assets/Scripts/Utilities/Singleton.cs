using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class of all singletons.
/// </summary>
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{

    /// <summary>
    /// The only instance of this Singleton.
    /// </summary>
    public static T Instance => _instance;

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            _instance = this as T;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        if (Instance == this)
        {
            _instance = null;
        }
    }

    private static T _instance;

}
