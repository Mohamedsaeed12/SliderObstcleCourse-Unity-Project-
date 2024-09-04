using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("How fast to move.")]
    [Min(float.Epsilon)]
    [SerializeField]
    private float moveSpeed = 20;

    [Tooltip("Rotation speed in degrees per second.")]
    [SerializeField]
    private float rotationSpeed = 10; // Variable to control rotation speed

    private Vector2 _move;
    private Rigidbody _rigidbody; // Reference to the Rigidbody component

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.interpolation = RigidbodyInterpolation.Interpolate; // Improve smoothness of the movement
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; // Prevent unwanted rotations
    }

    private void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        // Apply a force for movement to create slippery effect
        Vector3 forceDirection = transform.forward * _move.y * moveSpeed;
        _rigidbody.AddForce(forceDirection, ForceMode.Force);

        // For rotation, apply a torque for a slippery rotation effect
        float torque = _move.x * rotationSpeed;
        _rigidbody.AddTorque(0, torque, 0, ForceMode.Force);
    }
}
