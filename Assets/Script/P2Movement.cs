using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class P2Movement : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;
    private Animator m_Animator;
    private SpriteRenderer m_spriteRenderer;
    public float MoveSpeed = 10.0f;
    public float jumpForce = 1000.0f;
    private Vector2 moveDir;
    public bool isGrounded = false;
    public GameObject groundedObject;
    public Transform killPoint;
    public KillControler ball;
    public static bool Sound;
    public bool letjump2;
    public bool hitcontrol;
    public Vector2 leftpos;

    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Animator.SetBool("isGrounded", isGrounded);
        m_Animator.SetBool("isHitting", hitcontrol);
        if(Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.S))
            {
                moveDir.x = 2*MoveSpeed;
            }
            else
            {
                moveDir.x = MoveSpeed;
                m_Animator.SetFloat("MoveSpeed", 1);
                m_spriteRenderer.flipX=true;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.S))
            {
                moveDir.x = 2*-MoveSpeed;
            }
            else
            {
                moveDir.x = -MoveSpeed;
                m_Animator.SetFloat("MoveSpeed", 1);
                m_spriteRenderer.flipX=false;
            }
        }
        if (Input.GetKeyUp(KeyCode.D)||Input.GetKeyUp(KeyCode.A))
        {
            moveDir.x = 0;
            m_Animator.SetFloat("MoveSpeed", 0);
        }
        if(Input.GetKeyDown(KeyCode.W) && letjump2 == true)
        {
            m_rigidbody2D.AddForce(Vector2.up * jumpForce);
            letjump2 = false;
        }
        moveDir.y = m_rigidbody2D.velocity.y;
        m_rigidbody2D.velocity = moveDir;

        if(m_rigidbody2D.velocity.y == 0)
        {
            m_Animator.SetBool("isJumping", false);
        }
        if(m_rigidbody2D.velocity.y > 0)
        {
            m_Animator.SetBool("isJumping", true);
        }

        if (RightGround.Ball_Poss == true || LeftGround.Ball_Pos == true)
        {
            GetComponent<Transform>().localPosition = leftpos;
            this.m_rigidbody2D.velocity = new Vector2(0f,0f);
        }
        if (GameManager.Over == true)
        {
            GetComponent<Transform>().localPosition = leftpos;
            this.m_rigidbody2D.velocity = new Vector2(0f, 0f);
        }
        if (Input.GetKey(KeyCode.V))
        {
            m_Animator.SetBool("isHitting", true);
            m_spriteRenderer.flipX=true;
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            m_Animator.SetBool("isHitting", true);
        }
    }
    void OnCollisionEnter2D(Collision2D other) // This is use for detecting other gameObject's collider
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            letjump2 = true;
        }
        else if (other.gameObject.CompareTag("Ball"))
        {
            letjump2 = true;
        }
        else
        {
            letjump2 = false;
        }
    }
}
