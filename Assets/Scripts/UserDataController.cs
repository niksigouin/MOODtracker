using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserDataController : MonoBehaviour
{
    [SerializeField] private TMP_InputField dataInput;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitUntil(() => AppEvents.Instance != null);
        Subscribe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Subscribe()
    {
        AppEvents.Instance.DateSelectionChanged += OnDateSelectionChange;
    }

    private void UnSubscribe()
    {
        
    }

    private void OnDateSelectionChange(DateTime date)
    {
        // TODO: Make date.Date.ToString("D") a global call to reach anywhere
        Debug.Log($"{this}: Date changed too -> {DateController.Instance.DateString()}");
    }

    public void SaveUserData()
    {
        
    }
}
