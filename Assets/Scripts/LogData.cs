using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DataEntry
{
        public DateTime date;
        public List<LogData> data;
}

[Serializable]
public class LogData
{
        // public DateTime date;
        public string _id;
        public int categoryID;
        public int value;
        public List<string> activities;

        // public string DataString()
        // {
        //         return $"{date.Date.ToString("D")} | {categoryID} | {value}";
        // }
}

