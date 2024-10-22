using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
  public float fadeDuration = 1f;
  public float displayImageDuration = 1f;
  public GameObject player;
  public CanvasGroup exitBackgroundImageCanvasGroup; /*This will store a reference to the CanvasGroup
   component of the exitBackgroundImage GameObject.*/
  public AudioSource exitAudio;
  public CanvasGroup caughtBackgroundImageCanvasGroup; /*This will store a reference to the CanvasGroup
   component of the caughtBackgroundImage GameObject.*/
  public AudioSource caughtAudio;
  bool m_IsPlayerAtExit;
  bool m_IsPlayerCaught;
  float m_Timer;
  bool m_HasAudioPlayed;
  void OnTriggerEnter(Collider other){ 
    if(other.gameObject == player){
        m_IsPlayerAtExit = true;
    }    
  }

  public void CaughtPlayer ()
    {
        m_IsPlayerCaught = true;
    }
  void Update(){
    if(m_IsPlayerAtExit){ //This will check if the player is at the exit
        EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
    }else if(m_IsPlayerCaught){ //This will check if the player is caught
        EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
    }
  }
    void EndLevel (CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource){
        if (!m_HasAudioPlayed){
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        if(m_Timer > fadeDuration + displayImageDuration){
            if(doRestart){
                SceneManager.LoadScene (0);
            }
            else
            {
                Application.Quit ();
            }
        }
    }
}
