using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{

    [SerializeField] InputField nameInput;
    [SerializeField] Text bestScoreText;

    private SaveLoadHandler saveLoadHandler;

    public void Start()
    {
        bestScoreText.text += SaveLoadHandler.Instance.LoadData().point;
    }

    public void StartNew()
    {
        SaveLoadHandler.Instance.SaveName(nameInput.text);
        
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
