using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// �⺻ ��ũ��Ʈ�� ��� ����� ���Ŀ� �� ��ũ��Ʈ�� ����ǵ��� ���� 
// UI�� �����ϱ� ���� �ٸ� �׸��� �ʱ�ȭ�ؾ� �� �� �����Ƿ� UI�� ����
[DefaultExecutionOrder(1000)]
public class StartMenuManager : MonoBehaviour
{
    public void StartNewGame()
    {
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
