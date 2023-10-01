using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmanager : MonoBehaviour
{
    public static mainmanager data;
    public Color gamecolor;
    private void Awake()
    {
        if(data != null)
        {
            Destroy(gameObject);
            return;
        }
        data = this;
        DontDestroyOnLoad(gameObject);
    }
}
