using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public GameObject Panel; 
    bool show=false;
    
    //Panel.SetActive(false);
    public void open_panel()
    {
        Debug.Log("hena");
        if(show)
        {
            Panel.SetActive(false);
            show=false;
        }
        else
        {
            Panel.SetActive(true);
            show=true;
        
        }
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void GotoMainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GotoUserGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void GotoAIGameScene()
    {
        SceneManager.LoadScene("AIGame");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
