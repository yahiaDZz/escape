using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Wait : MonoBehaviour
{
    public float seconds = 17f;
    void Start()
    {
        StartCoroutine(Load());
    }
    IEnumerator Load(){
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(1);
    }
}
