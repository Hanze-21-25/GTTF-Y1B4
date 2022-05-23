using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject warningUI;
    public GameObject completeLevelUI;

    void Start()
    {
        GameIsOver = false;
        
    }


    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        if (Input.GetKeyDown("["))
        {
            EndGame();
        }

        if (Input.GetKeyDown("]"))
        {
            WinLevel();
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

       

        if (PlayerStats.Lives <= 4)
        {
            Warning();
        }
    }
    void EndGame()
    {
        GameIsOver = true;
        Debug.Log("Game Over!");

        gameOverUI.SetActive(true);

    }

    void Warning()
    {
        
        Debug.Log("Game Over!");

        warningUI.SetActive(true);
        
        

    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }

}