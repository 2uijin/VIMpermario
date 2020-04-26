using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public int stagePoint;
    public int health;

    public Player_Move player;

    public Text score;
    public Image[] HpUi;
    public GameObject UIResetBtn;
    public GameObject UImain;

    public void NextStage()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = stagePoint + "점";//점수 출력

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HealthDown(); //체력 -1
            collision.attachedRigidbody.velocity = Vector2.zero; //낙하속도 0으로
            collision.transform.position = new Vector3(-27, 6, 1); //떨어졌을때 원래 자리로
            //떨어진 자리에서 돌아오는거로 바꾸기
        }
    }

    public void HealthDown()
    {
        if (health > 0)
        {
            health--;
            HpUi[health].color = new Color(1, 1, 1, 0.4f);
        }
        else
        {
            player.Ondie();
            HpUi[0].color = new Color(1, 1, 1, 0.4f);
            UIResetBtn.SetActive(true);
            UImain.SetActive(true);
            player.Ondie();
        }
    }
}
