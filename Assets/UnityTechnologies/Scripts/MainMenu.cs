using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Drag and drop your audio clip in the Inspector
    public AudioSource playSoundEffect;  // Attach an AudioSource with the desired sound

    public void PlayGame()
    {
        // Start the Coroutine to delay the scene load
        StartCoroutine(PlayGameWithDelay());
    }

    private IEnumerator PlayGameWithDelay()
    {
        // Play the sound effect
        if (playSoundEffect != null)
        {
            playSoundEffect.Play();
        }

        // Wait for 3 seconds
        yield return new WaitForSeconds(3f);

        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
