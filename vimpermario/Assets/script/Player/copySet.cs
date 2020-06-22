using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copySet : MonoBehaviour
{

    public GameObject copyObj;
    public GameObject copymon;

    public bool isEnermy = false;

    public Player_Move playerPos;
    

    // Start is called before the first frame update
    void Start()
    {
        if (playerPos.key == -1)
        {
            Vector3 vector;
            vector = transform.position;
            vector.x =-7.3f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = this.gameObject.transform.position;
        Ray2D ray = new Ray2D(pos, Vector2.zero);
        // Physics.BoxCast (레이저를 발사할 위치, 사각형의 각 좌표의 절판 크기, 발사 방향, 충돌 결과, 회전 각도, 최대 거리)
        RaycastHit2D hit = Physics2D.BoxCast(ray.origin, transform.position, 0f, ray.direction);
        Debug.DrawRay(transform.position, Vector2.right, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Enermy")
            {
                Debug.Log("hit");
                copymon = hit.collider.gameObject;

                //monsprite = copymon.GetComponent<Sprite>();
                Debug.Log(copymon.GetComponent<SpriteRenderer>().sprite);
                copyObj.GetComponent<SpriteRenderer>().sprite = copymon.GetComponent<SpriteRenderer>().sprite;

                isEnermy = true;
            }

        }
    }
}
