using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float health = 100f;

    public AudioClip deathClip;
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    public TextMeshProUGUI hpText;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hpText.text = Mathf.RoundToInt(health).ToString()+" HP";
    }

    public void PlayRandomAudio()
    {
        if (audioClips.Length == 0)
        {
            Debug.LogWarning("No audio clips available.");
            return;
        }

        int randomIndex = Random.Range(0, audioClips.Length);
        
        AudioClip randomClip = audioClips[randomIndex];

        audioSource.clip = randomClip;
        audioSource.Play();
    }
    public void TakeDamage(float damage){
        PlayRandomAudio();
        health -= damage;
        if(health <0)health=0;
        hpText.text = Mathf.RoundToInt(health).ToString()+" HP";
        if(health<=0){
            StartCoroutine(Die());
        }
    }
      IEnumerator Die(){
        GetComponent<PlayerMovement>().enabled=false;
        audioSource.clip = deathClip;
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      
      }
}
