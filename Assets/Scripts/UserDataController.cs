using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using Object = System.Object;
using Newtonsoft.Json;

public class UserDataController : MonoBehaviour
{

    [SerializeField] private string dataPath;
    // THIS IS ALL FOR TEST PURPOSES
    [SerializeField] private TMP_Text screenData;
    
    [SerializeField] private TMP_InputField categoryID;
    [SerializeField] private TMP_InputField catValue;

    [SerializeField] private List<DataEntry> allData;
    // Start is called before the first frame update
    private void Awake()
    {
        dataPath = $"{Application.persistentDataPath}/Log.json";
    }

    IEnumerator Start()
    {
        yield return new WaitUntil(() => AppEvents.Instance != null);
        Subscribe();
        ReadAllData();
        LoadUserData();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Subscribe()
    {
        AppEvents.Instance.DateSelectionChanged += OnDateSelectionChange;
        AppEvents.Instance.DeleteLogEntry += OnDeleteLogEntry;
    }

    private void UnSubscribe()
    {
        AppEvents.Instance.DateSelectionChanged -= OnDateSelectionChange;
        AppEvents.Instance.DeleteLogEntry -= OnDeleteLogEntry;
    }

    private void OnDateSelectionChange(DateTime date)
    {
        // TODO: Make date.Date.ToString("D") a global call to reach anywhere
        // Debug.Log($"{this}: Date changed too -> {DateController.Instance.DateString()}");
        UpdateScreenDataWithDate(DateController.Instance.Date());
    }
    
    public void SaveUserDataOld(LogData data)
    {
        var json = JsonConvert.ToString(data);
        StreamWriter writer = new StreamWriter(dataPath, true);
        writer.Write(json);
        writer.Close();
        // LoadUserData(DateTime.Now);
        print(json);
    }

    public void PrepareDataForSave()
    {
        LogData newData = new LogData();
        newData._id = GUID();
        newData.value = Convert.ToInt32(catValue.text);
        newData.categoryID = Convert.ToInt32(categoryID.text);
        SerializeNewDate(newData);
    }

    string GUID()
    {
        string [] split = System.DateTime.Now.TimeOfDay.ToString().Split(new Char [] {':','.'});
        string id = "";
        for(int i = 0; i < split.Length; i++) {
            id+=split[i];
        }
        return id;
    }
    
    public void OnDeleteLogEntry(string uid)
    {
        Debug.Log($"DELETE WAS CALLED WITH UID: {uid}");
        // var targetDataEntry = allData.Remove(allData.Find(t => t.date == DateController.Instance.Date()).data.Find(e => e._id));
        var dataEntry = allData.Find(t => t.date == DateController.Instance.Date()).data;
        dataEntry.Remove(dataEntry.Find(e => e._id == uid));
        WriteData();
    }
    
    public void SerializeNewDate(LogData data)
    {
        // allData.FirstOrDefault(t => t.date == DateController.Instance.Date())?.data.Add(data);
        DataEntry temp = allData.FirstOrDefault(t => t.date == DateController.Instance.Date());
        if (temp == null)
        {
            var newDateEntry = new DataEntry
            {
                date = DateController.Instance.Date()
            };
            allData.Add(newDateEntry);
            WriteData();
        }
        allData.FirstOrDefault(t => t.date == DateController.Instance.Date())?.data.Add(data);
        
        WriteData();
    }

    private void WriteData()
    {
        using (StreamWriter file = new StreamWriter(dataPath, false))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, allData);
            // var json = JsonConvert.ToString(allData);
            // file.Write(json);
            file.Close();
        }
        Debug.LogWarning("Saved to file!");
        ReadAllData();
        LoadUserData();
    }

    public void LoadUserData()
    {
        UpdateScreenDataWithDate(DateController.Instance.Date());
    }

    private void ReadAllData()
    {
        try
        {
            using (StreamReader reader = new StreamReader(dataPath))
            {
                var res = JsonConvert.DeserializeObject<List<DataEntry>>(reader.ReadToEnd());
                reader.Close();
                allData = res;
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    private void UpdateScreenDataWithDate(DateTime date)
    {
        DataEntry targetData = allData.FirstOrDefault(t => t.date == date);
        if (targetData == null)
        {
            CategoryBoxManager.Instance.CleanCatBoxes();
        }
        else
        {
            CategoryBoxManager.Instance.InstantiateCatBoxes(targetData.data);
        }

        
        // DataEntry targetData = ReadAllData()[0];
        // screenData.text = $"Date: {targetData.date:d}\nSub Count: {targetData.data.Count}\nActivities: {targetData.data[0].activities[0]}";
        // //todo: serialise data entry into objects to be able to read them
        // //todo: Disable forward button if date is equal to today
    }
}
