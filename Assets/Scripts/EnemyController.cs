using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    public float speed = 3.5f;
    Rigidbody2D e_rigidbody2D;
    private const string m_camera = "MainCamera";
    private bool TorF = false;

    void Start()
    {
        e_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (TorF)
        {
            e_rigidbody2D.velocity = new Vector2(-speed, e_rigidbody2D.velocity.y);
        }
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