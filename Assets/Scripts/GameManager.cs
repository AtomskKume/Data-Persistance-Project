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
    public int playersInLeader;

    private List<PlayerData> listOfPlayers;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        listOfPlayers = new List<PlayerData>();
    }

    [System.Serializable]
    class Players {
        public PlayerData[] players;
    }

    [System.Serializable]
    public class PlayerData {
        public string playerName;
        public int playerScore;

        public PlayerData() { }
        public PlayerData(string name, int score) {
            playerName = name;
            playerScore = score;
        }
    }

    public PlayerData GetPlayer(int index) {
        return listOfPlayers[index];
    }
    
    public void SaveData() {
        AddPlayerToList();
        Players p = new Players();
        p.players = listOfPlayers.ToArray();
        /*PlayerData playerData = new PlayerData();
        playerData.playerName = this.playerName;
        playerData.playerScore = this.playerScore;*/

        string json = JsonUtility.ToJson(p);
        File.WriteAllText(Application.persistentDataPath + "/blocksbreakersplayerdata.json", json);
    }

    public void LoadData() {
        string path = Application.persistentDataPath + "/blocksbreakersplayerdata.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);

            Players p = JsonUtility.FromJson<Players>(json);
            listOfPlayers = new List<PlayerData>(p.players);

            if (listOfPlayers != null) {
                this.playerName = listOfPlayers[0].playerName;
                this.playerScore = listOfPlayers[0].playerScore;
            }
        }
        playersInLeader = listOfPlayers.Count;
    }

    private void AddPlayerToList() {
        int playerIndex = -1;
        int i = 0;

        foreach(PlayerData player in listOfPlayers) {
            if(player.playerName == playerName) {
                playerIndex = i;
            }
            i++;
        }
        if(playerIndex == -1) {
            listOfPlayers.Add(new PlayerData(playerName, playerScore));
        } else {
            if (listOfPlayers[playerIndex].playerScore < playerScore) {
                listOfPlayers[playerIndex] = new PlayerData(playerName, playerScore);
            }
        }
        listOfPlayers.Sort((p,q)=> q.playerScore.CompareTo(p.playerScore));
        playersInLeader++;


    }
}
