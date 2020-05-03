using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.UI;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;

public class firebase_read : MonoBehaviour
{

    public Text rank1;
    public Text rank2;
    public Text rank3;
    public Text rank4;
    public Text rank_player;

    class Rank
    {
        public string name;
        public int score;

        public Rank(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }
    
    
    List<Rank> leaderBoard = new List<Rank>();

    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://vimpermario.firebaseio.com/");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        FirebaseDatabase.DefaultInstance
        .GetReference("users")
        .OrderByChild("score")
        .LimitToLast(4)
        .GetValueAsync()
        .ContinueWith(task =>
        {
            if (task.IsCompleted)
            { 
                DataSnapshot snapshot = task.Result;

                foreach (DataSnapshot data in snapshot.Children)
                {
                    IDictionary ranking = (IDictionary)data.Value;
                    //Debug.Log("이름: " + ranking["name"] + ", 점수: " + ranking["score"]);

                    Rank rk = new Rank(
                     data.Child("name").Value.ToString(),
                     int.Parse(data.Child("score").Value.ToString())
                    );
                    leaderBoard.Add(rk);


                }

               for (int i = 0; i < leaderBoard.Count; i++) {
                    Debug.Log(leaderBoard[i].name.ToString() + "     " + leaderBoard[i].score.ToString());
                }
                Debug.Log(leaderBoard.Count);
            }                

        });
    }

    void setValue() { 
        rank1.text = "1등 : " + leaderBoard[3].name + "     " + leaderBoard[3].score;
        rank2.text = "2등 : " + leaderBoard[2].name + "     " + leaderBoard[2].score;
        rank3.text = "3등 : " + leaderBoard[1].name + "     " + leaderBoard[1].score;
        rank4.text = "4등 : " + leaderBoard[0].name + "     " + leaderBoard[0].score;
    }

    void Update()
    {
        Debug.Log(leaderBoard.Count);

    }

    void LateUpdate()
    {
        setValue();
    }
}
