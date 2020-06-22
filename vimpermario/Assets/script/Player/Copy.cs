using UnityEngine;

public class Copy : MonoBehaviour
{

    public GameObject bullet;
    public Transform pos;

    public GameObject copyob;
    public void Start()
    {

    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.L)&& copyob.GetComponent<copySet>().isEnermy ==true)
        {
            copyob.GetComponent<copySet>().isEnermy = false;
            copyob.SetActive(false);
            
            Instantiate(bullet,pos.position, transform.rotation);


        }
        
    }

}


