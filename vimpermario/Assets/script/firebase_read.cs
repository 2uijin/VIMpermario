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

    public Text player_n;
    public Text player_s;

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

    Rank rf ;
    int cnt;
    
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://vimpermario.firebaseio.com/");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        readData();
        //setValue();

    }

    void readData() { 
     FirebaseDatabase.DefaultInstance
        .GetReference("users")
        .OrderByKey()
        .LimitToLast(1)
        .GetValueAsync()
        .ContinueWith(task =>
        {
            if (task.IsCompleted)
            { 
                DataSnapshot snapshot = task.Result;

                foreach (DataSnapshot data in snapshot.Children)
                {
                    IDictionary ranking = (IDictionary)data.Value;
                    Debug.Log("이름: " + ranking["name"] + ", 점수: " + ranking["score"]);

                    rf = new Rank(data.Child("name").Value.ToString(),
                        int.Parse(data.Child("score").Value.ToString())
                        );
                    cnt++;
                    Debug.Log("d");

                }
            }
        });
    }

    void setValue() {
        player_n.text = rf.name;
        player_s.text = rf.score.ToString();
    }



    void Update()
    {
        if (cnt== 1) {
            setValue();
         }
    }
}
