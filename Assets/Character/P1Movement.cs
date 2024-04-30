using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Movement : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;
    private Animator m_Animator;
    private SpriteRenderer m_spriteRenderer;
    
    //Movement and jumping;
    public float jumpForce;
    private Vector2 moveDir;
    public bool letjump = true;


    //Animation
    public bool jumpcontrol;
    public bool hitcontrol;
    public float MoveSpeed = 10.0f;

    //Position
    public Vector2 rightpos;
    
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        m_Animator.SetBool("isJumping", jumpcontrol);
        m_Animator.SetBool("isHitting", hitcontrol);

        if(Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.DownArrow))
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.DownArrow))
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
        if (Input.GetKeyUp(KeyCode.RightArrow)||Input.GetKeyUp(KeyCode.LeftArrow))
        {
            moveDir.x = 0;
            m_Animator.SetFloat("MoveSpeed", 0);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && letjump == true)
        {
            m_rigidbody2D.AddForce(Vector2.up * jumpForce);
            letjump = false;
        }
        
        moveDir.y = m_rigidbody2D.velocity.y;
        m_rigidbody2D.velocity = moveDir;

        if(m_rigidbody2D.velocity.y > 0)
        {
            m_Animator.SetBool("isJumping", true);
        }

        if (RightGround.Ball_Poss == true || LeftGround.Ball_Pos == true)
        {
            GetComponent<Transform>().localPosition = rightpos;
            this.m_rigidbody2D.velocity = new Vector2(0f,0f);
        }
        if (GameManager.Over == true)
        {
            GetComponent<Transform>().localPosition = new Vector2(6, -5);
            this.m_rigidbody2D.velocity = new Vector2(0f,0f);
        }
        if (Input.GetKey(KeyCode.M))
        {
            m_Animator.SetBool("isHitting", true);
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            m_Animator.SetBool("isHitting", true);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            letjump = true;
        }
        else if(other.gameObject.CompareTag("Ball"))
        {
            letjump = true;
        }
        else
        {
            letjump = false;
        }
    }
}



//Original Kill 
//if(Input.GetKeyDown(KeyCode.M))
        // {
        //     Vector2 temp = new Vector2();
        //     temp = this.ball.transform.position - this.killPoint.transform.position;
        //     if (temp.magnitude < 2f)
        //     {
        //         this.ball.dir = temp.normalized * 30f;
        //         this.ball.trigger = true;
        //         P2Movement.Sound = true;
        //     }

        // }