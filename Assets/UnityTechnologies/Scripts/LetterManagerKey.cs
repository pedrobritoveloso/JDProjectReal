using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterManagerKey : MonoBehaviour
{
    public GameObject m_ClueKey;

    public GameObject LetterKey;

    public Button toActivate;
    public LetterManagerBath m_LetterManagerBath;

    public GameObject Letter4;

    private bool m_ClueKeyFound = false; //porta

    void Start(){
        if (toActivate != null)
        {
            toActivate.gameObject.SetActive(false);
        }
        m_ClueKey.SetActive(false);
        if (m_LetterManagerBath == null)
        {
            m_LetterManagerBath = FindObjectOfType<LetterManagerBath>();
            if (m_LetterManagerBath == null)
            {
                Debug.LogError("LetterManager not found!");
            }
        }

    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            Debug.Log("Player left the trigger");
            m_ClueKey.SetActive(false);
            Letter4.SetActive(false);
        }
    }

    public void Active()
    {
        if (m_LetterManagerBath.IsClueBathFound())
        {
            m_ClueKey.SetActive(true);
            Debug.Log("Clue Key: " + m_ClueKey.activeSelf);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Checking clue");
        if (m_ClueKey.activeSelf && other.gameObject.tag == "Player")
        {
            Debug.Log("Clue Three found");
            m_ClueKeyFound = true;
            toActivate.gameObject.SetActive(true);
            Debug.Log("Button activated");
        }
    }

    public bool IsClueKeyFound()
    {
        return m_ClueKeyFound;
    }
}
