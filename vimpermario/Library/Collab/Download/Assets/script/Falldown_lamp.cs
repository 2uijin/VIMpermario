using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falldown_lamp : MonoBehaviour
{
    GameObject player;
    float posX, posY;
    Vector2 pos;

    float DposX, DposY; // 원래 좌표
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");

        
        pos = this.gameObject.transform.position;

        DposX = pos.x;
        DposY = pos.y;

        posX = pos.x;
        posY = pos.y;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.5f, 0); //0.1f의 속도만큼 낙하시킨다.

        //posY -= 0.1f;

        if (transform.position.y <-1.0f)//형광등 위치가 1.0 밑으로 간다면
        {
            posY = DposY;
//            Destroy(gameObject);//형광등 삭제
            this.transform.Translate(new Vector2(this.gameObject.transform.position.x+29.5f, DposY));//처음 있던 위치로? 하려했는데 안됨..
            Debug.Log("x:" + this.gameObject.transform.position.x+"  y:" + this.gameObject.transform.position.y);

        }

        Vector2 p1 = transform.position;//형광등 중심좌표
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f; //형광등 반경
        float r2 = 3.0f; //플레이어 반경

        if (d < r1 + r2)
        {
            //충돌하면 형광등 사라짐
            //           Destroy(gameObject);
             Debug.Log("형광등 닿아서 사라짐");
            this.transform.Translate(new Vector2(this.gameObject.transform.position.x + 29.5f, DposY));//처음 있던 위치로? 하려했는데 안됨..
        }

    }
    
}
