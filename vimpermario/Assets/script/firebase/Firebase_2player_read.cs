using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using UnityEngine.UI;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor;

public class Firebase_2player_read : MonoBehaviour
{

    public Text player_n_1;
    public Text player_s_1;
    public Text player_n_2;
    public Text player_s_2;

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

        readData();
        //setValue();

    }

    void readData()
    {
        FirebaseDatabase.DefaultInstance
           .GetReference("users")
           .OrderByKey()
           .LimitToLast(2)
           .GetValueAsync()
           .ContinueWith(task =>
           {
               if (task.IsCompleted)
               {
                   DataSnapshot snapshot = task.Result;

                   foreach (DataSnapshot data in snapshot.Children)
                   {
                       IDictionary ranking = (IDictionary)data.Value;

                       Rank rk = new Rank(
                           data.Child("name").Value.ToString(),
                           int.Parse(data.Child("score").Value.ToString())
                          );
                       leaderBoard.Add(rk);
                   }

                   for (int i = 0; i < leaderBoard.Count; i++)
                   {
                       Debug.Log(leaderBoard[i].name.ToString() + "     " + leaderBoard[i].score.ToString());
                   }

               }
           });
    }

    void setValue()
    {
        player_n_1.text = leaderBoard[0].name;
        player_s_1.text = leaderBoard[0].score.ToString();

        player_n_2.text = leaderBoard[1].name;
        player_s_2.text = leaderBoard[1].score.ToString();

    }



    void Update()
    {
        if (leaderBoard.Count == 2)
        {
            setValue();
        }
    }
}
