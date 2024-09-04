using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : GameUI
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && GameUI.coinCount == 5)
        {
            Debug.Log("Game Finished - Updating Best Score and Resetting Game");

            // Update the best score
            int currentScore = 0; // Implement your score calculation logic
            int bestScore = PlayerPrefs.GetInt("BestScore", 0);
            if (currentScore > bestScore)
            {
                PlayerPrefs.SetInt("BestScore", currentScore);
                PlayerPrefs.Save(); // Save PlayerPrefs changes
            }

            // Reset the game state as necessary
            GameUI.coinCount = 0; // Assuming coinCount is accessible and can be reset here

            // Load the beginning of the game
            SceneManager.LoadScene("SampleScene");
        }
    }

}
