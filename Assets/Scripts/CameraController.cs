using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float duration = 2.5f; // Duration of the interpolation
    public float startZ = -11f; // Starting Z position
    public float endZ = -1.6f; // Ending Z position

    public float endZ1 = -3f;

    private float elapsedTime = 0f;
    private float elapsedTime2 = 0f;
    private bool isMoving = false;
    private bool IsMoving2 = false;
    private bool IsRetracting = false;

    private void Start()
    {   
        
    }

    private void Update()
    {   
        if (isMoving)
        {
            // Update the camera's Z position based on the interpolation
            float t = elapsedTime / duration;
            float zPosition = Mathf.Lerp(startZ, endZ, t);
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= duration)
            {
                // End the movement
                isMoving = false;
            }
        }
        if (IsMoving2)
        {
            // Update the camera's Z position based on the interpolation
            float t = elapsedTime / duration;
            float zPosition = Mathf.Lerp(startZ, endZ1, t);
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= duration)
            {
                // End the movement
                IsMoving2 = false;
            }
        }
        if (IsRetracting)
        {
            // Update the camera's Z position based on the interpolation
            float t = elapsedTime2 / duration;
            float zPosition = Mathf.Lerp(transform.position.z, startZ, t);
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);

            elapsedTime2 += Time.deltaTime;

            if (elapsedTime2 >= duration)
            {
                // End the movement
                IsRetracting = false;
            }
        }
    }

    public void StartCameraMovement()
    {   
        elapsedTime = 0f;
        isMoving = true;
    }
    public void startCamMove1()
    {   
        if(!IsRetracting)
        elapsedTime = 0;
        IsMoving2 = true;
    }
    public void Retract()
    {   
        if(!IsMoving2)
        elapsedTime = 0;
        elapsedTime2 = 0;
        IsRetracting = true;
    }
}
