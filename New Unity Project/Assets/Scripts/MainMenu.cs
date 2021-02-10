using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text highscoreText;
    void Start()
    {
        highscoreText.text = "High Score : " + ((int)PlayerPrefs.GetFloat("HighScore")).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
