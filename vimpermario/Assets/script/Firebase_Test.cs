using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Firebase_Test : MonoBehaviour
{
    private static Firebase_Test Instance;
    public DatabaseReference reference;

    //public InputField namee;
    public GameObject btn;



    class Rank
    {
        // 순위 정보를 담는 Rank 클래스
        // Firebase와 동일하게 name, score, timestamp를 가지게 해야함
        public string name;
        public int score;
        // JSON 형태로 바꿀 때, 프로퍼티는 지원이 안됨. 프로퍼티로 X

        public Rank(string name, int score)
        {
            // 초기화하기 쉽게 생성자 사용
            this.name = name;
            this.score = score;
        }
    }

  

    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://vimpermario.firebaseio.com/");
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        
    }

    public void OnCilk() {
        Rank rank1 = new Rank(GameObject.Find("Player").GetComponent<Player_Move>().namee.text, GameObject.Find("GameManger").GetComponent<GameManager>().stagePoint);
        string json = JsonUtility.ToJson(rank1);
        reference.Child("users").Push().SetRawJsonValueAsync(json);
    }

    public void start_page() {
        SceneManager.LoadScene("startpage");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
        }
    }

   
    }
