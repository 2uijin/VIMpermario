using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_Paste : MonoBehaviour
{
    public float distance;
    public LayerMask isLayer;
    public float speed=10;

    public GameObject playerRotation;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroybook", 2);

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right * -1, distance, isLayer);
        if (raycast.collider != null)
        {
            if (raycast.collider.tag == "Enermy")
            {
                Debug.Log("복사한거에 맞음");
            }
            Destroybook();
        }
       // if(transform.rotation.y==0)
       if(playerRotation.GetComponent<Player_Move>().key == 1)
            transform.Translate(transform.right * speed * Time.deltaTime);
        else if (playerRotation.GetComponent<Player_Move>().key == -1)
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enermy")
        {
            OnAttack(collision.transform);
        }
    }

    void OnAttack(Transform enemy)
    {
        No_Move_Enermy enermyMove = enemy.GetComponent<No_Move_Enermy>();
        enermyMove.OnDamage();
        Destroybook();
    }



    void Destroybook()
    {
        Destroy(gameObject);
    }
}
