using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterManagerDoor : MonoBehaviour
{
    public GameObject m_ClueOne;
    public Button toActivate;
    public LetterManagerBed m_LetterManagerBed;
    public GameObject Letter1;
    public GameObject LetterSound; // Reference to the LetterSound object with the AudioSource

    private bool m_ClueDoorFound = false;

    void Start()
    {
        Letter1.SetActive(false);
        if (toActivate != null)
        {
            toActivate.gameObject.SetActive(false);
        }
        m_ClueOne.SetActive(true);
        
        if (m_LetterManagerBed == null)
        {
            m_LetterManagerBed = FindObjectOfType<LetterManagerBed>();
            if (m_LetterManagerBed == null)
            {
                Debug.LogError("LetterManager not found!");
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Checking clue");
        if (m_ClueOne.activeSelf && other.gameObject.tag == "Player")
        {
            Debug.Log("Clue One found");
            m_ClueDoorFound = true;
            toActivate.gameObject.SetActive(true);
            Letter1.SetActive(true);
            Debug.Log("Button activated");
            m_LetterManagerBed.Active();

            // Play the sound from the LetterSound object if it has an AudioSource
            AudioSource audioSource = LetterSound.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("No AudioSource found on LetterSound object.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player left the trigger");
            m_ClueOne.SetActive(false);
            Letter1.SetActive(false);
        }
    }

    public bool IsClueDoorFound()
    {
        return m_ClueDoorFound;
    }
}
