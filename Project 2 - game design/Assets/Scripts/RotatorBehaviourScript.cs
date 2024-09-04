using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorBehaviourScript : MonoBehaviour
{

    [SerializeField]
    private float speed = 1.0f;

    void Update()
    {
        // Spin the object around the target at 30 degrees/second.
        transform.RotateAround(transform.position, Vector3.up, 30 * Time.deltaTime * speed);
    }
}
