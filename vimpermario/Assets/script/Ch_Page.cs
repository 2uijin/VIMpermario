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

    public void Page_vimpermario() {
        Time.timeScale = 1;
        SceneManager.LoadScene("vimpermario");
    }

    public void Page_vimpermario_hard() {
        Time.timeScale = 1;
        SceneManager.LoadScene("VIMpermario_hard");
    }

    public void Page_startpage() {
        SceneManager.LoadScene("startpage");
    }

    public void Page_leaderboard() {
        SceneManager.LoadScene("Leaderboard");
    }

    public void Page_leaderboard_v() {
        SceneManager.LoadScene("Leaderboard_v");
    }

    public void quitGame() {
        Application.Quit();
    }
}
