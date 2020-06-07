using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_Enemy : MonoBehaviour
{



    public GameObject book;
    public Transform pos;//총알 생성 위치
    void Start()
    {
        
    }

    public float cooltime;
    private float currenttime;

    private void FixedUpdate()
    {
                if (currenttime <= 0)
                {
                    GameObject bookcy = Instantiate(book, pos.transform.position, transform.rotation);
                    currenttime = cooltime;
                }       
            currenttime -= Time.deltaTime;//현재 시간 감소(타이머임!)
    }
}
