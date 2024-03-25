using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class CheckSavedData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       if (DataManager.Instance != null)
        {
            DataManager.Instance.LoadPlayerData();
            Debug.Log("Loaded player name: " + DataManager.Instance.GetPlayerName());
        }
        else
        {
            Debug.LogError("DataManager.Instance is null. Make sure DataManager exists in the scene and is initialized.");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
