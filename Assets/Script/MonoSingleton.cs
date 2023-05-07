using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T m_Instance;
    public static T Instance
    {
        get
        {
            if(m_Instance == null)
                m_Instance = GameObject.FindObjectOfType(typeof(T)) as T;
            if (m_Instance == null)
            {
                Debug.LogWarning("No instance of" + typeof(T).ToString() + ", a temporay one is created.");
                m_Instance = new GameObject("Temp Instance of" + typeof(T).ToString(), typeof(T)).GetComponent<T>();
                if (m_Instance == null)
                {
                    Debug.LogError("Problem during the creation of" + typeof(T).ToString());
                }
            }
            return m_Instance;
        }
    }
    public void Awake()
    {
        if(Instance != null)
        {
            m_Instance = this as T;
        }
    }
}
