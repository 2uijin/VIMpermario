using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxcollider;

    public int nextMove;


    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxcollider = GetComponent<BoxCollider2D>();

        Invoke("Think", 5);//일정시간 후에 함수 실행
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y); //나중에 속도 수정하기

    }

    void Think()
    {
        //다음 동작 지정
        nextMove = UnityEngine. Random.Range(-1, 2);

        //애니메이션
        anim.SetInteger("WalkSpeed", nextMove);
        //문워크 방지
        if (nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;

        float nextThinkTime = UnityEngine.Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);

    }

    void Turn()
    {
        nextMove = nextMove * -1;//절벽 앞에서 방향 바꿈
        CancelInvoke();
        Invoke("Think", 2);
        spriteRenderer.flipX = nextMove == 1;


    }

    void OnCollisionEnter2D(Collision2D collision)//충돌 감지
    {
        if (collision.gameObject.tag == "Block") //점프하고 돌아오게
            Turn();
    }

    public void OnDamage() {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        spriteRenderer.flipY = true; //뒤집기
        boxcollider.enabled = false;//콜라이더 지워줌
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        Invoke("DeActive", 3);
    }

    void DeActive() { //지워줌
        gameObject.SetActive(false);
    }


}
