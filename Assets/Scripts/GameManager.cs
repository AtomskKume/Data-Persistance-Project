using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public string actualPlayerName;
    public string playerName;
    public int playerScore;

    private void Awake() {
        if(instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class PlayerData
    {
        public string playerName;
        public int playerScore;
    }

    public void SaveData() {
        PlayerData playerData = new PlayerData();
        playerData.playerName = this.playerName;
        playerData.playerScore = this.playerScore;


        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.persistentDataPath + "/blocksbreakersplayerdata.json", json);
    }
    public void LoadData() {
        string path = Application.persistentDataPath + "/blocksbreakersplayerdata.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);

            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);
            this.playerName = playerData.playerName;
            this.playerScore = playerData.playerScore;
        }
    }
}
