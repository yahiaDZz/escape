using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StoryTeller : MonoBehaviour
{
    public int timeForEachFrame = 15;
    public Animation[]animations;
    void Start(){
        StartCoroutine(Animate());
    }
    IEnumerator Animate(){
        int k = animations.Length;
        for(int i =0;i<k;i++){
            animations[i].gameObject.SetActive(true);
            animations[i].Play();
            yield return new WaitForSeconds(timeForEachFrame);
            animations[i].gameObject.SetActive(false);
        }
        SceneManager.LoadScene(3);
    }
}
