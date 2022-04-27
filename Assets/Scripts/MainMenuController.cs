using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject OptionPanel;
    public GameObject MenuPanel;

    // Start is called before the first frame update
    void Start()
    {
        MenuPanel.SetActive(true);
        OptionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToOptionPanel()
    {
        MenuPanel.SetActive(false);
        OptionPanel.SetActive(true);
    }
    
    public void Back()
    {
        MenuPanel.SetActive(true);
        OptionPanel.SetActive(false);
    }

    public void PlayGame(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); //for debug

    }
}
