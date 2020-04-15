using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player_Move : MonoBehaviour
{

    Rigidbody2D rigid2D;
    float jumpForce = 600.0f; //점프 높이

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //왼쪽
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            //this.rigid2D.AddForce(Vector3.left * 100f);
            rigid2D.AddForce(Vector2.right *2 *-1, ForceMode2D.Impulse);
        }
        //오른쪽
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //this.rigid2D.AddForce(Vector3.right * 100f);
            rigid2D.AddForce(Vector2.right * 2 , ForceMode2D.Impulse);

        }*/

        //왼쪽 오른쪽 컨트롤 << 지금은 방향키로 되어있음 나중에 수정
        float h = Input.GetAxisRaw("Horizontal");
        rigid2D.AddForce(Vector2.right * h * 2, ForceMode2D.Impulse);

        //점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(Vector3.up * this.jumpForce);
        }
    }
}
