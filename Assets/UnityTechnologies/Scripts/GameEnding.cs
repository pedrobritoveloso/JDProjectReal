using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    
    public LetterManagerDoor letterManager;
    public LetterManagerBed letterManager2;
    public LetterManagerBath letterManager3;
    public LetterManagerKey letterManager4; 

    bool m_ClueBathFound = false;
    bool m_ClueBedFound = false;
    bool m_ClueDoorFound = false;
    bool m_ClueKeyFound = false;
    bool m_KeyFound;
    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    float m_Timer;
    bool m_HasAudioPlayed;

    void Start()
    {
        // Ensure the LetterManager is assigned in the inspector or find it dynamically
        if (letterManager == null)
        {
            letterManager = FindObjectOfType<LetterManagerDoor>();
            if (letterManager == null)
            {
                Debug.LogError("LetterManager not found!");
            }
        }
        if (letterManager2 == null)
        {
            letterManager2 = FindObjectOfType<LetterManagerBed>();
            if (letterManager2 == null)
            {
                Debug.LogError("LetterManager not found!");
            }
        }
        if (letterManager3 == null)
        {
            letterManager3 = FindObjectOfType<LetterManagerBath>();
            if (letterManager3 == null)
            {
                Debug.LogError("LetterManager not found!");
            }
        }
        if (letterManager4 == null)
        {
            letterManager4 = FindObjectOfType<LetterManagerKey>();
            if (letterManager4 == null)
            {
                Debug.LogError("LetterManager not found!");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player){
            if (letterManager.IsClueDoorFound())
            {
                m_ClueDoorFound = true;
            }
            if (letterManager2.IsClueBedFound())
            {
                m_ClueBedFound = true;
            }
            if (letterManager3.IsClueBathFound())
            {
                m_ClueBathFound = true;
            }
            if (letterManager4.IsClueKeyFound())
            {
                m_ClueKeyFound = true;
            }
            CheckKeyFound(m_ClueKeyFound);
        }
    }

void CheckKeyFound(bool keyFound)
{
    if (keyFound)
    {
        m_IsPlayerAtExit = true;
        Debug.Log("Player can exit");
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
                    SceneManager.LoadScene("MainScene");
                }
                else
                {
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
}
