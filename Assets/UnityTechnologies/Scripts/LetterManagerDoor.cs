using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManagerDoor : MonoBehaviour
{
    public GameObject m_ClueOne;

    public LetterManagerBed m_LetterManagerBed;

    private bool m_ClueDoorFound = false; //porta

    void Start()
    {
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
            m_ClueOne.SetActive(false);
            m_LetterManagerBed.Active();
        }
    }

    public bool IsClueDoorFound()
    {
        return m_ClueDoorFound;
    }
}
