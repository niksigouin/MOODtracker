using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppEventManager : MonoBehaviour
{
    public static AppEventManager Instance;
    
    public Action<DateTime> DateSelectionChanged;
    
    private void Start()
    {
        if (Instance != null && Instance != this) Destroy(this.gameObject);
        else Instance = this;
    }
}
