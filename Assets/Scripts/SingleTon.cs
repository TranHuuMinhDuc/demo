using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T : SingleTon<T>
{
    private static T _instance;
    public static T instance;
    [SerializeField] private bool isDontDestroyOnLoad;



    private void Awake()
    {
        if (instance == null)
        {
            _instance = (T)this;
        }else
        {
            Destroy(gameObject);
        }
        if (isDontDestroyOnLoad)
        {
            DontDestroyOnLoad(this);
        }
    }
}
