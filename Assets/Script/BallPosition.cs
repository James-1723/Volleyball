using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPosition : MonoBehaviour
{
    private Rigidbody2D rigid;
    public Vector2 uf;
    public Vector2 rightpos;
    public Vector2 leftpos;

    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
        GetComponent<Transform>().localPosition = rightpos;
        this.rigid.isKinematic = true;//關閉物理模擬
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))//解除禁止
        {
            this.rigid.isKinematic = false;
        }
        if (LeftGround.Ball_Pos == true)//傳送至右側
        {
            GetComponent<Transform>().localPosition = rightpos;
            this.rigid.velocity = new Vector2(0f,0f);//將球速度降至0
            this.rigid.isKinematic = true;//關閉物理模擬

            if (Input.GetKey(KeyCode.Space))//解除禁止
            {
                this.rigid.isKinematic = false;//解除禁止
                LeftGround.Ball_Pos = false;
            }
        }
        if (RightGround.Ball_Poss == true)
        {
            GetComponent<Transform>().localPosition = leftpos;//傳送至左側
            this.rigid.velocity = new Vector2(0f,0f);//將球速降至0
            this.rigid.isKinematic = true;//關閉物理模擬

            if (Input.GetKey(KeyCode.Space))
            {
                this.rigid.isKinematic = false;//解除禁止
                RightGround.Ball_Poss = false;
            }
        }
    }

    //排球碰到角色時會上彈
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            rigid.AddForce(uf, ForceMode2D.Impulse);
        }
    }
}