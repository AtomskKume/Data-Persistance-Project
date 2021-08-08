using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LaderBoardHandler : MonoBehaviour {

    public ScrollRect scrollView;
    public GameObject scrollContent;
    public GameObject laderBoardItem;

    // Start is called before the first frame update
    void Start() {
            GenerateLaderBoardList();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void GenerateLaderBoardList() {

        if(GameManager.instance.playersInLeader != 0) {
            for(int i = 0; i< GameManager.instance.playersInLeader; i++) {
                GameObject laderItem = Instantiate(laderBoardItem, scrollContent.transform);
                laderItem.transform.Find("PlayerNameText").gameObject.GetComponent<TextMeshProUGUI>().text = GameManager.instance.GetPlayer(i).playerName;
                laderItem.transform.Find("PlayerScoreText").gameObject.GetComponent<TextMeshProUGUI>().text = GameManager.instance.GetPlayer(i).playerScore.ToString();
            }
        }
    }

    public void BackToMenu() {
        SceneManager.LoadScene(0);
    }
}
