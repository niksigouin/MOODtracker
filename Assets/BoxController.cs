using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    [SerializeField] private TMP_Text categoryText;
    [SerializeField] private TMP_Text valueText;
    [SerializeField] private SVGImage colorDiskImg;
    [SerializeField] private Button LogButton;
    
    [ReadOnly] public string categoryName = "Mood";
    [ReadOnly] public int categoryValue = -1;
    [ReadOnly] public Color categoryColor = Color.yellow;

    private void Start()
    {
        
        StartCoroutine(FillInData());
        
    }

    private IEnumerator FillInData()
    {
        yield return new WaitUntil(() => CategoryBoxManager.Instance.dataReady);
        SetDataOnStart();
        
    }

    private void SetDataOnStart()
    {
        categoryText.text = categoryName;
        valueText.text = categoryValue.ToString();
        colorDiskImg.color = categoryColor;
    }

    private void ToggleNumberValue(bool b)
    {
        valueText.gameObject.SetActive(b);
        LogButton.gameObject.SetActive(!b);
    }
}
