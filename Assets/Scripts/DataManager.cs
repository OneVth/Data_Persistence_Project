using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public int bestScore;
    }

    [SerializeField] private PlayerData playerData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerName(string name)
    {
        playerData.playerName = name;       
    }
    
    public void SavePlayerData()
    {
        string json = JsonUtility.ToJson(playerData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/playerdata.json", json);
    }

    public void LoadPlayerData()
    {
        string filePath = Application.persistentDataPath + "/playerdata.json";
        if (System.IO.File.Exists(filePath))
        {
            string json = System.IO.File.ReadAllText(filePath);
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            playerData = new PlayerData();
        }
    }

    public string GetPlayerName()
    {
        return playerData.playerName;
    }
    public int GetBestScore()
    {
        return playerData.bestScore;
    }

    public void UpdateBestScore(int newScore)
    {
        if (newScore > playerData.bestScore)
        {
            playerData.bestScore = newScore;
            SavePlayerData();
        }
    }
}
