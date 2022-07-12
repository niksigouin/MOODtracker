using UnityEngine;


public class BoxControllerAddon : MonoBehaviour
{
    public void OnDeleteLogEntryButtonPressed() =>
        AppEvents.Instance.DeleteLogEntry?.Invoke(transform.GetComponent<BoxController>().uid);
}