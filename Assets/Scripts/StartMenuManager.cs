using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// �⺻ ��ũ��Ʈ�� ��� ����� ���Ŀ� �� ��ũ��Ʈ�� ����ǵ��� ���� 
// UI�� �����ϱ� ���� �ٸ� �׸��� �ʱ�ȭ�ؾ� �� �� �����Ƿ� UI�� ����
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
