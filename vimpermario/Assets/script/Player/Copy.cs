using UnityEngine;

public class Copy : MonoBehaviour
{
    public GameObject copyObj;
    public Transform Pos;//복사 몬스터 생성 위치
    public bool isEnermy;

    public void Start()
    {

    }

    public void Update()
    {
        Vector2 pos = this.gameObject.transform.position;
        Ray2D ray = new Ray2D(pos, Vector2.zero);
        // Physics.BoxCast (레이저를 발사할 위치, 사각형의 각 좌표의 절판 크기, 발사 방향, 충돌 결과, 회전 각도, 최대 거리)
        RaycastHit2D hit = Physics2D.BoxCast(ray.origin, transform.lossyScale,0f, ray.direction);
        Debug.DrawRay(transform.position, Vector2.right, Color.red);

        if (hit.collider != null) {
            if (hit.collider.gameObject.tag == "Enermy")
            {
                Debug.Log("hit");
                copyObj = hit.collider.gameObject;
                isEnermy = true;
            }
        }
    }

    public void Paste() {
        if (isEnermy == true)
            Instantiate(copyObj, Pos.transform.position, transform.rotation);
        else
            Debug.Log("몬스터 없음");
    }

}


