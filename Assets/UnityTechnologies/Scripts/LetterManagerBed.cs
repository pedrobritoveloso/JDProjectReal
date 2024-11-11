using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterManagerBed : MonoBehaviour
{
    public GameObject m_ClueTwo;
    public Button toActivate;
    public LetterManagerDoor m_LetterManagerDoor; 
    public LetterManagerBath m_LetterManagerBath;
    public GameObject Letter2;
    public GameObject LetterSound; // Reference to the LetterSound object with an AudioSource

    private bool m_ClueBedFound = false;

    void Start()
    {
        Letter2.SetActive(false);
        if (toActivate != null)
        {
            toActivate.gameObject.SetActive(false);
        }
        m_ClueTwo.SetActive(false);

        if (m_LetterManagerDoor == null)
        {
            m_LetterManagerDoor = FindObjectOfType<LetterManagerDoor>();
            if (m_LetterManagerDoor == null)
            {
                Debug.LogError("LetterManagerDoor not found!");
            }
        }

        if (m_LetterManagerBath == null)
        {
            m_LetterManagerBath = FindObjectOfType<LetterManagerBath>();
            if (m_LetterManagerBath == null)
            {
                Debug.LogError("LetterManagerBath not found!");
            }
        }
    }

    public void Active()
    {
        if (m_LetterManagerDoor.IsClueDoorFound())
        {
            m_ClueTwo.SetActive(true);
            Debug.Log("Clue Two: " + m_ClueTwo.activeSelf);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Checking clue");
        if (m_ClueTwo.activeSelf && other.gameObject.tag == "Player")
        {
            Debug.Log("Clue Two found");
            m_ClueBedFound = true;
            toActivate.gameObject.SetActive(true);
            Letter2.SetActive(true);
            Debug.Log("Button activated");
            m_LetterManagerBath.Active();

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
            m_ClueTwo.SetActive(false);
            Letter2.SetActive(false);
        }
    }

    public bool IsClueBedFound()
    {
        return m_ClueBedFound;
    }
}


