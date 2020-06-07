using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falldown_lamp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.1f, 0); //0.1f의 속도만큼 낙하시킨다.

        if(transform.position.y < 10.0f)//형광등 위치가 20.0 밑으로 간다면
        {
            Destroy(gameObject);//형광등 삭제
        }
        
    }
}
