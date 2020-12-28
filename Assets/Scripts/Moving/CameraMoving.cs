using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    public Transform TankTransform;

    private Camera Camera;
    
    private void Start()
    {
        Camera = GetComponent<Camera>();
    }
    private void Update()
    {
        Vector3 Position = TankTransform.position; // getting Tank position

        Position.z = Camera.transform.position.z;

        Camera.transform.position = Position; // set position for camera
    }
}
