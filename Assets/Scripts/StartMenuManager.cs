using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// 기본 스크립트가 모두 실행된 이후에 이 스크립트가 실행되도록 설정 
// UI를 설정하기 전에 다른 항목을 초기화해야 할 수 있으므로 UI에 유용
[DefaultExecutionOrder(1000)]

public class StartMenuManager : MonoBehaviour
{
    public InputField nameInputField;
    public TextMeshProUGUI BestScoreText;

    private void Start()
    {
        DataManager.Instance.LoadPlayerData();
        BestScoreText.text = "Best Score: " + DataManager.Instance.GetPlayerName() + " : " + DataManager.Instance.GetBestScore();
    }
    

    public void StartNewGame()
    {
        if (DataManager.Instance != null)
        {
            DataManager.Instance.SetPlayerName(nameInputField.text);
            DataManager.Instance.SavePlayerData();
        }

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
