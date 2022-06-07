using System.Collections;
using System.Collections.Generic;
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

}
