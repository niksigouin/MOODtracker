using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CategoryBoxManager : MonoBehaviour
{
    [SerializeField] private GameObject BoxesParent;

    [SerializeField] private GameObject CatBoxPrefab;

    [ReadOnly]
    public bool dataReady = false; 
    public static CategoryBoxManager Instance { get; private set; }   
    //private List<GameObject>
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this) 
        { Destroy(this); } 
        else 
        { Instance = this; }
        
        // IF there is no custom categories in saved data
        if (true)
        {
            Instantiate(CatBoxPrefab, BoxesParent.transform);
        }
    }

    public void InstantiateCatBoxes(List<LogData> target)
    {
        CleanCatBoxes();
        if(target == null) return;
        foreach (var logdata in target)
        {
            GameObject newObject = Instantiate(CatBoxPrefab, BoxesParent.transform);
            newObject.GetComponent<BoxController>().categoryValue = logdata.value;
            newObject.GetComponent<BoxController>().categoryName = logdata.categoryID.ToString();
            newObject.GetComponent<BoxController>().uid = logdata._id;
        }
    }

    public void CleanCatBoxes()
    {
        for (int i = 0; i < BoxesParent.transform.childCount; i++)
        {
            Destroy(BoxesParent.transform.GetChild(i).gameObject);
        }
    }

}
