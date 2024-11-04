using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManagerKey : MonoBehaviour
{
    public GameObject m_ClueKey;
    public LetterManagerBath m_LetterManagerBath;

    private bool m_ClueKeyFound = false; //porta

    void Start()
    {
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
            m_ClueKey.SetActive(false);
        }
    }

    public bool IsClueKeyFound()
    {
        return m_ClueKeyFound;
    }
}