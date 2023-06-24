using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float duration = 2.5f; // Duration of the interpolation
    public float startZ = -11f; // Starting Z position
    public float endZ = -1.6f; // Ending Z position
    public float endZ1 = -3f;

    private float elapsedTime = 0f;
    private float targetZ = 0f;
    private bool isMoving = false;

    private void FixedUpdate()
    {
        if (isMoving)
        {
            // Update the camera's Z position based on the interpolation
            float t = elapsedTime / duration;
            float zPosition = Mathf.Lerp(transform.position.z, targetZ, t);
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= duration)
            {
                // End the movement
                isMoving = false;
            }
        }
    }

    public void StartCameraMovement()
    {
        targetZ = endZ;
        elapsedTime = 0f;
        isMoving = true;
    }

    public void StartCamMove1()
    {
        targetZ = endZ1;
        elapsedTime = 0f;
        isMoving = true;
    }

    public void Retract()
    {
        targetZ = startZ;
        elapsedTime = 0f;
        isMoving = true;
    }
}
