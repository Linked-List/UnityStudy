using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField]
    private int sceneNum;
    public void ChangMyScene()
    {
        SceneManager.LoadScene(sceneNum);
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
