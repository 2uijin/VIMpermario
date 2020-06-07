using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falldown_lamp : MonoBehaviour
{
    GameObject player;
    float posX, posY;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("Player");

        Vector2 pos;
        pos = this.gameObject.transform.position;

        posX = pos.x;
        posY = pos.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.1f, 0); //0.1f의 속도만큼 낙하시킨다.

        if(transform.position.y < 1.0f)//형광등 위치가 1.0 밑으로 간다면
        {
                        Destroy(gameObject);//형광등 삭제
//            this.transform.Translate(new Vector2(posX, posY));//처음 있던 위치로? 하려했는데 안됨..
           
        }

        Vector2 p1 = transform.position;//형광등 중심좌표
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f; //형광등 반경
        float r2 = 0.1f; //플레이어 반경

        if (d < r1 + r2)
        {
            //충돌하면 형광등 사라짐
            Destroy(gameObject);
        }

    }
}
