﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour{
	[SceneName]
	public string nextLevel;

	IEnumerator Start(){
		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(nextLevel);
	}
}
