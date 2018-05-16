using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{

    GameObject gamemanager;
    GameManagerScript script;
    public Text LIFE;
    [SceneName]
    public string nextLevel;
    public Transform playerPosition;
    public float DeadYLine = -15.0f;
    private int life;



    public void LossLife()
    {
        if (life >= 1)
        {
            life -= 1;
        }
        else
        {
            life = 0;
        }
        LIFE.text = life.ToString("00");
    }

    public void BigLossLife()
    {
        life = 0;
        LIFE.text = life.ToString("00");
    }

    void Start()
    {
        gamemanager = GameObject.Find("GameManager");
        script = gamemanager.GetComponent<GameManagerScript>();
        int animal = script.ANIMAL;
        int life = script.LIFE;
        if (animal == 1)
        {
            life += 5;
        }


    }
    void Update()
    {
        if (life == 0)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player)
            {
                StartCoroutine(LoadNextLevel());
                enabled = false;
            }
        }
        if (playerPosition.position.y < DeadYLine)
        {
            BigLossLife();
        }
    }

    private IEnumerator LoadNextLevel()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        yield return new WaitForSeconds(0.18f);

        if (player)
        {
            player.SendMessage("TimeOver", SendMessageOptions.DontRequireReceiver);
        }

        yield return new WaitForSeconds(1.65f);
        SceneManager.LoadScene(nextLevel);
    }

    private static LifeController l_instance;

    public static LifeController instance
    {
        get
        {
            if (l_instance == false)
            {
                l_instance = FindObjectOfType<LifeController>();
            }
            return l_instance;
        }
    }

}