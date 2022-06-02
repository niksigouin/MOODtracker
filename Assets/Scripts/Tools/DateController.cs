using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text dateText;
    private DateTime date = new DateTime();
    
    // private DateTime date = new DateTime();
    void Start()
    {
        InitialiseDate();
    }
    
    void Update()
    {
        
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
        Debug.Log($"Changed date to {date.Date.ToString("D")}");
        UpdateDateText(date);
    }
}
