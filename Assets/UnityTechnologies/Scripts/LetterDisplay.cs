using UnityEngine;
using UnityEngine.UI;

public class LetterManager : MonoBehaviour
{
    public GameObject[] letterImages; // Array of letter images
    public Button showLetter1Button;   // Reference to the UI button
    public Button showLetter2Button;   // Reference to the UI button
    public Button showLetter3Button;   // Reference to the UI button
    public Button showLetter4Button;   // Reference to the UI button
    private int currentLetterIndex = -1; // Track the currently displayed letter (-1 means none displayed)

    void Start()
    {
        // Optionally hide the button initially
        showLetter1Button.gameObject.SetActive(false);

        // Set up the button's click event to toggle the first letter
        showLetter1Button.onClick.AddListener(() => ToggleLetter(0));
        showLetter2Button.onClick.AddListener(() => ToggleLetter(1));
        showLetter3Button.onClick.AddListener(() => ToggleLetter(2));
        showLetter4Button.onClick.AddListener(() => ToggleLetter(3));
    }

    void Update()
    {
        // Check if the button or "E" key should toggle the letter
        if (showLetter1Button.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToggleLetter(0); // Change the index as needed for different letters
        }
        if (showLetter2Button.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToggleLetter(1); // Change the index as needed for different letters
        }
        if (showLetter3Button.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Alpha3))
        {
            ToggleLetter(2); // Change the index as needed for different letters
        }
        if (showLetter4Button.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Alpha4))
        {
            ToggleLetter(3); // Change the index as needed for different letters
        }
    }

    // Toggle method to show/hide the letter
    public void ToggleLetter(int letterIndex)
    {
        // If the current letter is active, deactivate it
        if (currentLetterIndex == letterIndex)
        {
            letterImages[letterIndex].SetActive(false);
            currentLetterIndex = -1; // Reset to indicate no letter is displayed
        }
        else
        {
            // Deactivate any currently active letter
            if (currentLetterIndex != -1)
            {
                letterImages[currentLetterIndex].SetActive(false);
            }

            // Activate the selected letter image
            if (letterIndex >= 0 && letterIndex < letterImages.Length)
            {
                letterImages[letterIndex].SetActive(true);
                currentLetterIndex = letterIndex; // Update the current letter index
            }
        }
    }

    // Optional close method if you want a separate close button
    public void CloseLetter()
    {
        if (currentLetterIndex != -1)
        {
            letterImages[currentLetterIndex].SetActive(false);
            currentLetterIndex = -1;
        }
    }
}
