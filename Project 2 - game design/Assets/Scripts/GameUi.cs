using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameUI : BaseUI
{
    public static int coinCount;
    public float gameTime = 0f;
    public float bestTime = Mathf.Infinity;

    protected override void Start()
    {
        base.Start();

        LoadBestTime(); // Load best time from previous sessions

        // Initialize UI elements with starting values
        UpdateTimer(0f);
    }

    private void Update()
    {
        gameTime += Time.deltaTime; // Update gameTime each frame
        UpdateTimer(gameTime); // Update the timer display
        CoinLabel.text = $"Coin: {coinCount} of 5"; // Update coin count display
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Before Increment - coinCount: " + coinCount);
        coinCount += 1;
        Debug.Log("After Increment - coinCount: " + coinCount);
        Destroy(gameObject); // Proper for collectible objects
        FindObjectOfType<PlayerColorChange>().ChangeColor();
    }

   

    private void UpdateTimer(float time)
    {
        timeLabel.text = $"Time: {time.ToString("F2")}"; // Update timer display
    }

  

    private void LoadBestTime()
    {
        bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity); // Load best time
        // Update UI for best time display if you have a specific label for it
        BestLabel.text = $"Best: {bestTime:F2}"; // Update best time display, formatted to two decimal places
    }

    // Placeholder for the actual score calculation method, adjusted to return a float
    public float CalculateCurrentScore(float time)
    {
        // Implement your scoring logic based on time or other factors
        // Ensure this returns a float value representing the score
        return  time; // Example calculation with float
    }
    public void ResetGameTime()
    {
        gameTime = 0f; // Reset the game time
    }
}
