using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject credits;
    public void PlayGame(){
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void ShowCredits(){
        credits.SetActive(true);
    }
    public void Back(){
        credits.SetActive(false);
    }
    public void Exit(){
        Application.Quit();
    }
}
