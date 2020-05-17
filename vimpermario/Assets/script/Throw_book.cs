using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_book : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float distance;
    public LayerMask isLayer;
    void Start()
    {
        Invoke("Destroybook", 4);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        if (raycast.collider != null) {
            if (raycast.collider.tag == "plyer")
                Debug.Log("양아름에게 책으로 맞음ㅋㅋ");
            Destroybook();
        }
        transform.Translate(transform.right * -1f * speed * Time.deltaTime);
    }

    void Destroybook() {
        Destroy(gameObject);
    }
}
