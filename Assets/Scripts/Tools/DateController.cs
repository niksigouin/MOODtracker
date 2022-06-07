using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateController : MonoBehaviour
{
    public static DateController Instance;
    // Start is called before the first frame update
    [SerializeField] private TMP_Text dateText;
    private DateTime date = new DateTime();
    
    void Start()
    {
        if (Instance != null && Instance != this) Destroy(this.gameObject);
        else Instance = this;
        
        InitialiseDate();
    }

    private void InitialiseDate()
    {
        date = DateTime.Today.Date;
        UpdateDateText(date);
    }

    private void UpdateDateText(DateTime d)
    {
        dateText.text = d.Date.ToString("D");
    }

    public void ChangeTargetDate(int t)
    {
        date = date.Date.AddDays(t);
        UpdateDateText(date);
        AppEventManager.Instance.DateSelectionChanged?.Invoke(date);
    }

    public string DateString() => date.Date.ToString("D");
}
