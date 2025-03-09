using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;


[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputName;
    public Text menuBestName;

    private void Start()
    {
        MenuManager.Instance.LoadName();
        menuBestName.text = $"Best Score: {MenuManager.Instance.bestName} : {MenuManager.Instance.bestScore}";
    }


    public void StartNew()
    {
        MenuManager.Instance.curName = inputName.text;
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
