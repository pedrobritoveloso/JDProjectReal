using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LetterManagerDoor : MonoBehaviour
{
    public GameObject m_ClueOne;

    public Button toActivate;

    public LetterManagerBed m_LetterManagerBed;

    private bool m_ClueDoorFound = false; //porta

    void Start()
    {
        if( toActivate != null){
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
            Debug.Log("Button activated");
            m_LetterManagerBed.Active();
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            Debug.Log("Player left the trigger");
            m_ClueOne.SetActive(false);
        }
    }

    public bool IsClueDoorFound()
    {
        return m_ClueDoorFound;
    }
}
