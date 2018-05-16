using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController3 : MonoBehaviour
{

    public float speed = 3.5f;
    private float GetX;
    private float GetY;
    private const string m_camera = "MainCamera";
    private bool TorF = false;

    void Start()
    {
        GetX = transform.position.x;
        GetY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector2(GetX + (Mathf.PingPong(Time.time, 2.0f) * speed), GetY);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (TorF)
        {
            if (col.tag == "Bullet")
            {
                Destroy(gameObject);
            }
        }
    }

    void OnWillRenderObject()
    {
        //メインカメラに映った時だけTorFをtrue
        if (Camera.current.tag == m_camera)
        {
            TorF = true;
        }
    }
}