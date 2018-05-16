using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BigCoinController : MonoBehaviour
{
    public AudioClip getCoin;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            PointController.instance.BigAddCoin();
            PointController.instance.SetData();
            PointController.instance.LogData();
            AudioSourceController.instance.PlayOneShot(getCoin);
            Destroy(gameObject);
        }
    }
}
