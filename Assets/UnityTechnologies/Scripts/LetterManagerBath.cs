using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterManagerBath : MonoBehaviour
{
    public GameObject m_ClueThree;

    public Button toActivate;

    public LetterManagerBed m_LetterManagerBed;
    public LetterManagerKey m_LetterManagerKey; 

    private bool m_ClueBathFound = false; //porta

    void Start()
    {
        if( toActivate != null){
            toActivate.gameObject.SetActive(false);
        }
        m_ClueThree.SetActive(false);
        if (m_LetterManagerKey == null)
        {
            m_LetterManagerKey = FindObjectOfType<LetterManagerKey>();
            if (m_LetterManagerKey == null)
            {
                Debug.LogError("LetterManager not found!");
            }
        }
        if(m_LetterManagerBed == null){
            m_LetterManagerBed = FindObjectOfType<LetterManagerBed>();
            if(m_LetterManagerBed == null){
                Debug.LogError("LetterManager not found!");
            }
        }

    }

    public void Active(){
        if(m_LetterManagerBed.IsClueBedFound()){
            m_ClueThree.SetActive(true);
            Debug.Log("Clue Three: " + m_ClueThree.activeSelf);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Checking clue");
        if (m_ClueThree.activeSelf && other.gameObject.tag == "Player")
        {
            Debug.Log("Clue Three found");
            m_ClueBathFound = true;
            m_ClueThree.SetActive(false);
            toActivate.gameObject.SetActive(true);
            Debug.Log("Button activated");
            m_LetterManagerKey.Active();
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            Debug.Log("Player left the trigger");
            toActivate.gameObject.SetActive(false);
        }
    }

    public bool IsClueBathFound()
    {
        return m_ClueBathFound;
    }
}
