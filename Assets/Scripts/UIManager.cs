using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class UIManager : MonoBehaviour {

    [SerializeField] private TMP_InputField playerInput;
    [SerializeField] private GameObject previousChampionScreen;
    [SerializeField] private TextMeshProUGUI previousChampionText;

    private void Start() {
        GameManager.instance.LoadData();
        UpdatePreviousChampion();
    }

    public void StartNew() {
        GameManager.instance.actualPlayerName = playerInput.text;
        SceneManager.LoadScene(1);
    }

    public void GoToladerBoard() {
        SceneManager.LoadScene(2);
    }

    public void Exit() {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    private void UpdatePreviousChampion() {
        if(GameManager.instance.playerName!= "") {
            previousChampionText.text = GameManager.instance.playerName + " Score: " + GameManager.instance.playerScore;
            previousChampionScreen.SetActive(true);
        }
    }
}
