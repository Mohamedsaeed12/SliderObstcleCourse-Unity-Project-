using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private GameUI gameUI; // Reference to the GameUI script to access its members

    private void Start()
    {
        gameUI = FindObjectOfType<GameUI>(); // Ensure there is a GameUI component in the scene
        if (gameUI == null)
        {
            Debug.LogError("GameUI component not found in the scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && GameUI.coinCount == 5)
        {
            Debug.Log("Game Finished - Updating Best Score and Resetting Game");
            float currentScore = gameUI.CalculateCurrentScore(gameUI.gameTime);
            // Update Best Time
            if (currentScore < gameUI.bestTime)
            {
                gameUI.bestTime = currentScore;
                PlayerPrefs.SetFloat("BestTime", currentScore); // Correctly save the currentScore as BestTime
            }

            PlayerPrefs.Save();

            ResetGame();
        }
    }

    private void ResetGame()
    {
        GameUI.coinCount = 0; // Reset coin count
        gameUI.ResetGameTime(); // Reset gameTime for a fresh start
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
