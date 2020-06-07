using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//자기가 쓴 코드 주석 조금이라도 달아놓기
/*
 해야할일
 -db(젤 나중에)
 -방향키 때면 멈추게
 -gameManager관련 변수/함수 사용할 때 nullreferenceexceptio 해결하기
     */

public class Player2_Move : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigid2D;
    SpriteRenderer spriterenderer;
    CapsuleCollider2D collider2D;

    public GameManager_2 gameManager;
    public jumpStep jumpS;

    public GameObject next_btn;
    public GameObject namefiled;
    public InputField namee;

    public Copy_2 Copyy;
    public GameObject copy;
    public bool CopySet;


    float jumpForce = 30.0f; //점프 높이
    float walkForce = 25.0f;
    float maxWalkSpeed = 20.0f; //걷는속도 제한
    int key = 0;//방향
    float speedx;


    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.spriterenderer = GetComponent<SpriteRenderer>();
        this.collider2D = GetComponent<CapsuleCollider2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        { //손때면 멈추게
            rigid2D.velocity = new Vector2(rigid2D.velocity.normalized.x * 0.5f, rigid2D.velocity.y);
            //walkForce = Math.Abs(this.rigid2D.velocity.normalized.x * 0.0005f); <<되는데 영원히 낮아짐,,
            this.walkForce = walkForce * 0.0f; //어색하지만 되긴 됨

        }
        //Debug.Log(this.rigid2D.velocity.x);

        //움직이는 방향에 따라 플레이어 보는 방향 바뀜
        if (key != 0)
            spriterenderer.flipX = key == -1;

        //걷는 애니메이션
        if (Mathf.Abs(rigid2D.velocity.x) < 0.3)
            animator.SetBool("isWalking", false);

        else
            animator.SetBool("isWalking", true);



        //점프
        if (Input.GetKeyDown(KeyCode.W) && !animator.GetBool("isJumping"))
        {
            this.rigid2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }

    }

    void FixedUpdate() //플레이어의 속도가 무제한으로 늘지 않게 fixed update 사용
    {
        //좌우 이동
        if (Input.GetKey(KeyCode.D))
        {
            key = 1;
            walkForce = 25.0f;
        }//나중에 누르는 키 수정하기
        if (Input.GetKey(KeyCode.A))
        {
            key = -1;
            walkForce = 25.0f;
        }
        // rigid2D.AddForce(Vector2.right * key, ForceMode2D.Impulse);

        //플레이어 속도
        speedx = Math.Abs(this.rigid2D.velocity.x);

        //속도제한
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if (Input.GetKeyDown(KeyCode.T)) //나중에 누르는 동안만 나오게 수정하기
        {
            if (CopySet == false)
            {
                copy.SetActive(true);
                CopySet = true;
            }
            else
            {
                copy.SetActive(false);
                CopySet = false;
            }
        }
        //붙여넣기
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Copyy.Paste();

        }

    }
    void OnCollisionEnter2D(Collision2D collision)//충돌 감지
    {
        if (collision.gameObject.tag == "Block") //점프하고 돌아오게
            animator.SetBool("isJumping", false);
        // Debug.Log("충돌");

        if (collision.gameObject.tag == "Enermy")
        {
            if (rigid2D.velocity.y < 0 && transform.position.y > collision.transform.position.y)
            { //머리 밟으면 몬스터 죽음
                OnAttack(collision.transform);
            }
            else
                onDamaged(collision.transform.position);
        }

        if (collision.gameObject.tag == "LastLine2")
        {
            Debug.Log("들어갔냐?");
            gameManager.HealthDown();
            transform.position = new Vector3(-25, 50, -60);
        }

        if (collision.gameObject.tag == "spikes")
        { //팅겨냄
            onSpikes(collision.transform.position);
        }

        if (collision.gameObject.tag == "att")//팅겨냄+공격
        {
            onDamaged(collision.transform.position);
        }

        if (collision.gameObject.tag == "Electric")
        {
            onElectric(collision.transform.position);
        }

        if (collision.gameObject.tag == "jump")
        {
            onJump(collision.transform);
        }
    }

    void OnAttack(Transform enemy)
    {
        //밟았을때 반발력
        rigid2D.AddForce(Vector2.up * 5, ForceMode2D.Impulse);

        gameManager.stagePoint += 100; //포인트 추가

        //밟힌 몬스터 제거
        //Enemy_Move enemymove = enemy.GetComponent<Enemy_Move>();
        //enemymove.OnDamage();//애니있는거임

        No_Move_Enermy enermyMove = enemy.GetComponent<No_Move_Enermy>();
        enermyMove.OnDamage();

    }

    void onJump(Transform jup)
    {
        rigid2D.AddForce(Vector2.up * 70, ForceMode2D.Impulse);
        rigid2D.AddForce(Vector2.right * 60, ForceMode2D.Impulse);
        GameObject.Find("jump").GetComponent<jumpStep>().aniJump();
    }

    void onSpikes(Vector2 targetPos)
    {
        gameObject.layer = 11; //레이어 바꾸기

        spriterenderer.color = new Color(1, 1, 1, 0.4f); //맞았을때 투명도 설정

        //튕기기
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid2D.AddForce(new Vector2(dirc, 1) * 20, ForceMode2D.Impulse);

        //애니
        animator.SetTrigger("doDamaged");

        Invoke("Offdamage", 1); //딜레이
    }

    void onDamaged(Vector2 targetPos)
    { //데미지 받음
        gameObject.layer = 11; //레이어 바꾸기

        spriterenderer.color = new Color(1, 1, 1, 0.4f); //맞았을때 투명도 설정

        //튕기기
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid2D.AddForce(new Vector2(dirc, 1) * 20, ForceMode2D.Impulse);

        //애니
        animator.SetTrigger("doDamaged");

        gameManager.HealthDown();

        Invoke("Offdamage", 1); //딜레이
    }

    void onElectric(Vector2 targetPos)
    { //데미지 받음
        gameObject.layer = 11; //레이어 바꾸기

        spriterenderer.color = new Color(1, 1, 1, 0.4f); //맞았을때 투명도 설정

        //튕기기
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rigid2D.AddForce(new Vector2(dirc, 1) * 20, ForceMode2D.Impulse);

        //애니
        animator.SetTrigger("doElectric");

        gameManager.HealthDown();

        Invoke("Offdamage", 1); //딜레이
    }


    void Offdamage()
    { //원상태로 되돌리기
        gameObject.layer = 10;
        spriterenderer.color = new Color(1, 1, 1, 1);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == ("Item"))
        {
            gameManager.stagePoint += 100; //포인트 추가
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Finish")
        {
            //SceneManager.LoadScene("Leaderboard");
            //SceneManager.LoadScene(0);
            namefiled.SetActive(true);
            next_btn.SetActive(true);
        }
    }

    public void Ondie()
    {
        spriterenderer.color = new Color(1, 1, 1, 0.4f);
        spriterenderer.flipY = true; //뒤집기
        collider2D.enabled = false;
        rigid2D.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }

    public void VelocityZero()
    {
        rigid2D.velocity = Vector2.zero;
    }
}
