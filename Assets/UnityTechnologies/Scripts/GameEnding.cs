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

    public GameObject m_ClueOne;
    public GameObject m_ClueTwo;
    public GameObject m_ClueThree;
    public GameObject m_Key;
    
    bool m_KeyFound;

    bool m_ClueBedFound;
    bool m_ClueTableFound;
    bool m_ClueBathFound;
    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;
    void OnTriggerEnter(Collider other){ 
        if(other.gameObject == player){
            if (other.gameObject == m_ClueOne) {
                m_ClueBedFound = true; 
                Debug.Log("Clue Found" + m_ClueBedFound);
                m_ClueOne.SetActive(false);
                m_ClueTwo.SetActive(true);
            } else if (other.gameObject == m_ClueTwo && m_ClueBedFound) {
                m_ClueTableFound = true;
                m_ClueTwo.SetActive(false);
                m_ClueThree.SetActive(true);
            } else if (other.gameObject == m_ClueThree && m_ClueTableFound) {
                m_ClueBathFound = true;
                m_ClueThree.SetActive(false);
                m_Key.SetActive(true);
            } else if (other.gameObject == m_Key && m_ClueBathFound) {
                m_KeyFound = true;
                m_Key.SetActive(false);
            } else if (other.gameObject == player && m_KeyFound) {
                m_IsPlayerAtExit = true;
            }
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
