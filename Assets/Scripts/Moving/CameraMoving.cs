using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField]
    private Transform TankTransform;

    private Camera Camera;
    
    private void Start()
    {
        Camera = GetComponent<Camera>();
    }
    private void Update()
    {
        Vector3 Position = TankTransform.position; 

        Position.z = Camera.transform.position.z;

        Camera.transform.position = Position; 
    }
}
