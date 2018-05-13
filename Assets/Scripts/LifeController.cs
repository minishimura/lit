using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour{

    private int Animal;
	public int playerLIFE;
	public Text LIFE;	
	[SceneName]
	public string nextLevel;
	public Transform playerPosition;
	public float DeadYLine = -15.0f;



	public void LossLife(){
		if (playerLIFE >= 1 ) {
			playerLIFE -= 1;
		} 
		else {
			playerLIFE = 0;
		}
		LIFE.text = playerLIFE.ToString ("00");
	}

	public void BigLossLife(){
		playerLIFE = 0;
		LIFE.text = playerLIFE.ToString ("00");
	}

    void Awake(){

        Animal = PlayerPrefs.GetInt("animal");
        if (Animal == 1){
            playerLIFE += 5;
            LIFE.text = playerLIFE.ToString();
        }

    }

	void Update(){
		if (playerLIFE == 0){
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			if (player){
				StartCoroutine(LoadNextLevel());
				enabled = false;
			}
		}
		if (playerPosition.position.y < DeadYLine) {
			BigLossLife();
		}
	}

	private IEnumerator LoadNextLevel(){
		var player = GameObject.FindGameObjectWithTag ("Player");
		yield return new WaitForSeconds (0.18f);

		if (player) {
			player.SendMessage ("TimeOver", SendMessageOptions.DontRequireReceiver);
		}

		yield return new WaitForSeconds (1.65f);
		SceneManager.LoadScene(nextLevel);
	}		

	private static LifeController l_instance;

	public static LifeController instance{
		get{
			if (l_instance == false){
				l_instance = FindObjectOfType<LifeController>();
			}
			return l_instance;
		}
	}
}

