using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour{

	public int playerCOIN;
	public int playerPOINT;
	public Text COIN;
	public Text POINT;

	public void Awake(){
		playerCOIN = PlayerPrefs.GetInt("coin",0);
		playerPOINT = PlayerPrefs.GetInt("point",0);
		SetData ();
	}

	public void AddCoin(){
	}

	public void LossCoin(){
	}

	public void BigAddCoin(){
		playerCOIN += 30;
		playerPOINT += 3000;
	}

	public void BigLossCoin(){
		if (playerCOIN >= 30 && playerPOINT >= 3000) {
			playerCOIN -= 30;
			playerPOINT -= 3000;
		} 
		else {
			playerCOIN = 0;
			playerPOINT = 0;
		}
	}

	public void SetData(){
		COIN.text = playerCOIN.ToString("000");
		POINT.text = playerPOINT.ToString("0000000");
	}

	public void LogData(){
		PlayerPrefs.SetInt("coin", playerCOIN);
		PlayerPrefs.SetInt("point", playerPOINT);
	}

	private static PointController m_instance;

	public static PointController instance{
		get{
			if (m_instance == false){
				m_instance = FindObjectOfType<PointController>();
			}
			return m_instance;
		}
	}

}
