using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ch_Page : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Page_vimpermario_easy() {
        Time.timeScale = 1;
        SceneManager.LoadScene("vimpermario_easy_1");
    }

    public void Page_vimpermario_hard() {
        Time.timeScale = 1;
        SceneManager.LoadScene("VIMpermario_hard");
    }

    public void Page_vimpermario_normal()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("vimpermario_nomal");
    }

    public void Page_vimpermario_easy_2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("vimpermario_easy_2");
    }

    public void Page_vimpermario_hard_2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("VIMpermario_hard_2");
    }

    public void Page_vimpermario_normal_2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("vimpermario_normal_2");
    }


    public void Page_leaderboard() {
        SceneManager.LoadScene("Leaderboard");
    }

    public void Page_leaderboard_normal()
    {
        SceneManager.LoadScene("Leaderboard_normal");
    }

    public void Page_leaderboard_hard()
    {
        SceneManager.LoadScene("Leaderboard_hard");
    }





    public void Page_startpage() {
        SceneManager.LoadScene("startpage");
    }



    public void Page_leaderboard_v() {
        SceneManager.LoadScene("Leaderboard_v");
    }

    public void Page_diffcultytselect() {
        SceneManager.LoadScene("difficulty_select");
    }

    public void Page_diffcultytselect_2player()
    {
        SceneManager.LoadScene("difficulty_select_2player");
    }

    public void quitGame() {
        Application.Quit();
    }
}
