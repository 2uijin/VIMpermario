using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public int stagePoint;
    public int health;

    public Player_Move player;

    public Text score;
    public Image[] HpUi;
    public GameObject UIResetBtn;
    public GameObject UImain;

    public bool pause;

    private void Start()
    {
        pause = false;
    }

    public void NextStage()
    {
        
    }

    public void ReTry()
    {
        SceneManager.LoadScene(0);
    }


    // Update is called once per frame
    void Update()
    {
        score.text = stagePoint + "점";//점수 출력

          if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("dd");
            if (pause == false)
            {
                Time.timeScale = 0;
                pause = true;
                btnSetAct(true);
                return;
            }
            if (pause == true) {
                Time.timeScale = 1;
                pause = false;
                btnSetAct(false);
                return;
            }
        }

    }

    private void FixedUpdate()
    {
      
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //떨어진 자리에서 돌아오는거로 바꾸기

            if (health > 1) {
                PlayerReposition();
            }

            HealthDown(); //체력 -1

        }


    }

    public void HealthDown()
    {
        if (health > 1)
        {
            health--;
            HpUi[health].color = new Color(1, 1, 1, 0.4f);
        }
        else 
        {
            HpUi[0].color = new Color(1, 1, 1, 0.4f);
            btnSetAct(true);
            player.Ondie();
        }
    }

    void btnSetAct(bool tf) {
        UIResetBtn.SetActive(tf);
        UImain.SetActive(tf);
    }

    void PlayerReposition() {
        player.transform.position = new Vector3(-30, 40, 1); //떨어졌을때 원래 자리로
        player.VelocityZero();
    }

    private void Awake()
    {
       // DontDestroyOnLoad(gameObject);
    }

    public void board_page() {
        SceneManager.LoadScene("Leaderboard");
    }

}
