using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SingleTonObject<T> : MonoBehaviour where T : SingleTonObject<T>
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;

                if (_instance == null)
                {
                    Debug.LogError("There's no active " + typeof(T) + " in this scene");
                }
            }

            return _instance;
        }
    }
}
