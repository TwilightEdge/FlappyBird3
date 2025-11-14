using UnityEngine;

/// <summary>
/// Keeps the camera centered on the target without inheriting rotation.
/// </summary>
public class CameraFollow : MonoBehaviour
{
    // Drag your Cat GameObject here in the Inspector
    [Tooltip("The GameObject (your cat) the camera should follow.")]
    public Transform target;

    // We store the initial offset so the camera stays positioned correctly (e.g., above or behind the cat)
    private Vector3 initialOffset;

    void Start()
    {
        if (target != null)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = target.position.x;
            currentPosition.y = target.position.y;
            transform.position=currentPosition;
            
            // Calculate the initial distance between the camera and the target
            initialOffset = transform.position - target.position;
        }
    }

    // LateUpdate runs once per frame, AFTER all Update and FixedUpdate calls,
    // which makes it ideal for camera movement.
    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the camera's desired new position by adding the initial offset
            Vector3 desiredPosition = target.position + initialOffset;
            
            // Set the camera's new position. We use 'transform' because the script is on the camera.
            transform.position = desiredPosition;

            // CRUCIAL: Since the camera is not a child of the cat, it naturally retains its original rotation (0, 0, 0),
            // meaning it stays upright and ignores the cat's rotation.
        }
    }
}