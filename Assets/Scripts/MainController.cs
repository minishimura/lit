using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(BoxCollider2D))]


public class MainController : MonoBehaviour
{

    public float maxSpeed;
    public float jumpPower;
    public Vector2 backwardForce = new Vector2(-4.5f, 5.4f);
    public Transform girl;
    private Animator m_animator;
    private BoxCollider2D m_boxcollier2D;
    private Rigidbody2D m_rigidbody2D;
    private bool m_isGround;
    private const float m_centerY = 1.5f;
    private State m_state = State.Normal;
    private SpriteRenderer m_renderer;
    private bool on_damage = false;

    void Reset()
    {
        Awake();
        // UnityChan2DController
        maxSpeed = 9f;
        jumpPower = 1000;
        backwardForce = new Vector2(-4.5f, 5.4f);
        // Transform
        transform.localScale = new Vector3(1, 1, 1);
        // Rigidbody2D
        m_rigidbody2D.gravityScale = 3.5f;
        //        m_rigidbody2D.fixedAngle = true;
        // BoxCollider2D
        m_boxcollier2D.size = new Vector2(1, 2.5f);
        m_boxcollier2D.offset = new Vector2(0, -0.25f);
        // Animator
        m_animator.applyRootMotion = false;
    }

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_boxcollier2D = GetComponent<BoxCollider2D>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (on_damage == false)
        {
            float x = Input.GetAxis("Horizontal");
            bool jump = Input.GetButtonDown("Jump");
            Move(x, jump);
        }
    }

    void Move(float move, bool jump)
    {
        if (Mathf.Abs(move) > 0)
        {
            Quaternion rot = transform.rotation;
            transform.rotation = Quaternion.Euler(rot.x, Mathf.Sign(move) == 1 ? 0 : 180, rot.z);
        }

        m_rigidbody2D.AddForce(new Vector2(move * maxSpeed, m_rigidbody2D.velocity.y));
        m_animator.SetFloat("Horizontal", move);

        m_animator.SetFloat("Vertical", m_rigidbody2D.velocity.y);
        m_animator.SetBool("isGround", m_isGround);

        if (jump && m_isGround)
        {
            m_animator.SetTrigger("Jump");
            SendMessage("Jump", SendMessageOptions.DontRequireReceiver);
            m_rigidbody2D.AddForce(Vector2.up * jumpPower);
        }
    }


    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {

            m_isGround = true;
            m_animator.SetBool("isGround", m_isGround);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            m_isGround = false;
            m_animator.SetBool("isGround", m_isGround);
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "DamageObject" && !on_damage)
        {
            LifeController.instance.LossLife();
            OnDamageEffect();
            m_animator.SetBool("Damage" ,on_damage);

        }
       
        if (other.tag == "DeathObject" && m_state == State.Normal)
        {
           on_damage = true;
            OnDamageEffect();
            m_animator.SetBool("Damage", on_damage);
            LifeController.instance.BigLossLife();
        }
    }


    void OnDamageEffect()
    {
        on_damage = true;
        float s = 100f * Time.deltaTime;
        girl.transform.Translate(Vector3.up * s);
        if (girl.transform.localScale.x >= 0)
        {
            girl.transform.Translate(Vector3.right * s);
        }
        else
        {
            girl.transform.Translate(Vector3.left * s);
        }
        StartCoroutine("WaitForIt");

    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(1);
        on_damage = false;
        m_renderer.color = new Color(1f, 1f, 1f, 1f);
    }

    enum State
    {
        Normal,
    }

}
	