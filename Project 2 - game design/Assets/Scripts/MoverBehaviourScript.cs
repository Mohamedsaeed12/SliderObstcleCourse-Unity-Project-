using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBehaviourScript : MonoBehaviour
{
    [Tooltip("Where to start moving the object from")]
    [SerializeField]
    private float start = 4;

    [Tooltip("Where to end moving the object")]
    [SerializeField]
    private float end = -4;

    [Tooltip("The speed of the object moving")]
    [SerializeField]
    private float speed = 1;

    private float direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial position of the GameObject
        Transform t = transform;
        Vector3 position = t.position;
        t.position = new Vector3(x:start, position.y, position.z);
    }

 
    void Update()
    {
        Transform t = transform;
        // Move the object towards the end point
        if (direction == 1)
        {
            t.position += Vector3.left * (speed * Time.deltaTime);
            // Check if the object has passed the end point and reverse direction if so
            if (t.position.x <= end)
            {
                direction = -1;
            }
        }
        // Move the object towards the start point
        else if (direction == -1)
        {
            t.position += Vector3.right * (speed * Time.deltaTime);
            // Check if the object has passed the start point and reverse direction if so
            if (t.position.x >= start)
            {
                direction = 1;
            }
        }
    }

   
}