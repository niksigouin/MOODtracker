using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppEvents : MonoBehaviour
{
    public static AppEvents Instance;

    public Action<DateTime> DateSelectionChanged;
    public Action<DateTime, int, int> NewLogEntry;
    public Action<DateTime, string, Color> NewCategoryCreated;
    public Action<string> DeleteLogEntry;
    
    private void Start()
    {
        if (Instance != null && Instance != this) Destroy(this.gameObject);
        else Instance = this;
    }
}
