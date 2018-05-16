using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingController_c : MonoBehaviour
{
    [SceneName]
    public string nextLevel;
    [SceneName]
    public string newLevel;
    [SerializeField]
    private KeyCode enter = KeyCode.X;
    [SerializeField]
    private KeyCode next = KeyCode.RightArrow;


    void Update()
    {
        if (Input.GetKeyDown(enter))
        {
            SceneManager.LoadScene(nextLevel);
        }

        else if (Input.GetKeyDown(next))
        {
            SceneManager.LoadScene(newLevel);
            PlayerPrefs.SetInt("animal", 4);
        }
    }
}
