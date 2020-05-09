using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpStep : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void aniJump() {
        animator.SetTrigger("jumpstep");
        Debug.Log("dd");

    }
}
