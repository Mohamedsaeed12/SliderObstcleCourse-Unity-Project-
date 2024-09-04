using UnityEngine;

public class PlayerColorChange : MonoBehaviour
{
    // Method to change the player's color
    public void ChangeColor()
    {
        // Generate a random color
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);

        // Apply the new color to the player's material
        GetComponent<Renderer>().material.color = newColor;
    }
}
