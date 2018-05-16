using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public AudioClip getCoin;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            PointController.instance.AddCoin();
            PointController.instance.SetData();
            PointController.instance.LogData();
            AudioSourceController.instance.PlayOneShot(getCoin);
            Destroy(gameObject);
        }
    }
}
