using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class IntroCameraController : MonoBehaviour{
	public Transform IntroStopPosition;
	private Vector3 pos;
	[SceneName]
	public string nextLevel;

	IEnumerator Start(){
		pos = transform.position;
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length + 1);
		SceneManager.LoadScene(nextLevel);
	}

	void Update(){
		float newPosition = Mathf.SmoothStep(pos.x, IntroStopPosition.position.x, Time.timeSinceLevelLoad / GetComponent<AudioSource>().clip.length);
		transform.position = new Vector3(newPosition, pos.y, pos.z);
	}
}
