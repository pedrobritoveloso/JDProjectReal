using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Drag and drop your audio clip in the Inspector

    public void PlayGame()
    {
        // Start the Coroutine to delay the scene load
        StartCoroutine(PlayGameWithDelay());
    }

    public void PlayGameSkipTutorial()
    {
        // Start the Coroutine to delay the scene load
        StartCoroutine(PlayGameWithDelayTwo());
    }

    private IEnumerator PlayGameWithDelay()
    {
      
        // Wait for 3 seconds
        yield return new WaitForSeconds(1f);

        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

      private IEnumerator PlayGameWithDelayTwo()
    {
      
        // Wait for 3 seconds
        yield return new WaitForSeconds(1f);

        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
