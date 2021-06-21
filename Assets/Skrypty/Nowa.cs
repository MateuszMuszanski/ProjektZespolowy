using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nowa : MonoBehaviour
{
    public void PlayGame()
    {
        //PlayerPrefs.SetInt("lvl", SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLvl()
    {
        //PlayerPrefs.GetInt("lvl");
        SceneManager.LoadScene(PlayerPrefs.GetInt("lvl"));
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
