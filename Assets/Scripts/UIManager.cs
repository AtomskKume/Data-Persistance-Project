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

    public void StartNew() {
        GameManager.instance.playerName = playerInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit() {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }


}
