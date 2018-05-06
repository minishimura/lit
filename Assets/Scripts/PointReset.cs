using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PointReset : MonoBehaviour {

	private int HighScore = 0;
	private int Point = 0;
	public Text HScore;

	void Start () {
		Point = PlayerPrefs.GetInt("point");
		HighScore = PlayerPrefs.GetInt("highscore");
		if (Point > HighScore) {
			HighScore = Point;
			PlayerPrefs.SetInt("highscore", HighScore);
		}
		PlayerPrefs.DeleteKey("coin");
		PlayerPrefs.DeleteKey("point");
		HScore.text = HighScore.ToString("0000000");
	}

	void Update () {	
	}
}
