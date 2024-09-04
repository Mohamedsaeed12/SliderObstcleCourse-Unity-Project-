using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResizerBehaviourScript : MonoBehaviour
{
    // Scale values
    public Vector3 minScale = new Vector3(1, 1, 1);
    public Vector3 maxScale = new Vector3(2, 2, 2);

    // Rate of scale change per second
    public float scaleRate = 1;

    // Internal timer
    private float timer;

    void Update()
    {
        // Update the timer with the loop of 0 to 1 based on scaleRate
        timer += Time.deltaTime * scaleRate;
        if (timer > 1)
        {
            float excess = timer - 1;
            timer = 0 + excess;
            // Swap the min and max scale to reverse the scaling direction
            var temp = minScale;
            minScale = maxScale;
            maxScale = temp;
        }

        // Scale the object
        transform.localScale = Vector3.Lerp(minScale, maxScale, timer);
    }
}