using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManagerBed : MonoBehaviour
{
    public GameObject m_ClueTwo;
    public LetterManagerDoor m_LetterManagerDoor; 
    public LetterManagerBath m_LetterManagerBath;

    private bool m_ClueBedFound = false; //porta
    
    void Start()
    {
        m_ClueTwo.SetActive(false);
        if (m_LetterManagerDoor == null)
        {
            m_LetterManagerDoor = FindObjectOfType<LetterManagerDoor>();
            if (m_LetterManagerDoor == null)
            {
                Debug.LogError("LetterManager not found!");
            }
        }
        if (m_LetterManagerBath == null)
        {
            m_LetterManagerBath = FindObjectOfType<LetterManagerBath>();
            if (m_LetterManagerBath == null)
            {
                Debug.LogError("LetterManager not found!");
            }
        }

    }

    public void Active(){
        if(m_LetterManagerDoor.IsClueDoorFound()){
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
            m_ClueTwo.SetActive(false);
            m_LetterManagerBath.Active();
        }
    }

    public bool IsClueBedFound()
    {
        return m_ClueBedFound;
    }
}

