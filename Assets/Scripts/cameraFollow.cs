using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 6f, -20f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    private void Update()
    {
        // Calculate the target position by adding the offset to the target's position
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera to the target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}