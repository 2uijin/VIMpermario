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
        SceneManager.LoadScene("vimpermario");
    }

    public void Page_startpage() {
        SceneManager.LoadScene("startpage");
    }
}
