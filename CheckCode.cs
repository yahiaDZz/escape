using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CheckCode : MonoBehaviour
{
    public string key = "hash";
    public Animation animationToPlay;
    private bool shiftPressed = false;
    private string currentInput = "";
    public bool loadNextLevel = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            shiftPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            shiftPressed = false;
            currentInput = "";
        }
        if (shiftPressed && Input.inputString.Length > 0)
        {
            currentInput += Input.inputString;

            if (currentInput.Length > key.Length)
            {
                currentInput = currentInput.Substring(currentInput.Length - key.Length);
            }

            if (currentInput.ToLower() == key)
            {
                if(loadNextLevel){
                    LoadNextLevel();
                }
                Animate();
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            shiftPressed = false;
            currentInput = "";
        }
    }
    private void LoadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    private void Animate(){
        if(animationToPlay != null){
            animationToPlay.Play();
        }
    }
}
