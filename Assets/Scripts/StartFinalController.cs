using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class StartFinalController : MonoBehaviour{
	[SceneName]
	public string Final;
	[SerializeField]
	private int Hscore;
	private KeyCode final = KeyCode.P;

	public void Awake(){
		Hscore = PlayerPrefs.GetInt("highscore",0);
	}

	void Update(){
		if (Hscore >= 30000){
			if (Input.GetKeyDown (final)) {
				StartCoroutine (LoadStageFinal ());
			}
		}
	}

	private IEnumerator LoadStageFinal(){
		foreach (AudioSource audioS in FindObjectsOfType<AudioSource>()){
			audioS.volume = 0.2f;
		}

		AudioSource audioSource = GetComponent<AudioSource>();
		audioSource.volume = 1;
		audioSource.Play();
		yield return new WaitForSeconds(audioSource.clip.length + 0.5f);
		SceneManager.LoadScene(Final);
	}
}
