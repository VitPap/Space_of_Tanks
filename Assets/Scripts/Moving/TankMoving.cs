using UnityEngine;

public class TankMoving : MonoBehaviour
{
    public Tank TankObj;            // tank gameobject
    public SpeedForward Forward;    // moving forward
    public SpeedBack Back;          // moving back
    public SpeedRotate Rotate;      // rotate moving

    private float TimeOfLastStop = 0;   
    private void Update()
    {

        float translation = Input.GetAxis("Vertical");                     //fix press button move
        float rotate = Input.GetAxis("Horizontal") * Rotate.Boost;         //fix press button rotate

        if (translation == 0)  TimeOfLastStop = Time.time; // fix time of last stop (0 = Stop)

        float BoostCoefficent = Time.time - TimeOfLastStop; // fix Coefficent for Boosting speed

        translation *= BoostCoefficent; 

        if (translation == 1) // determine direction and fixing current speed
        {
          translation *= Forward.Boost;

          if (translation > Forward.MaxSpeed) translation = Forward.MaxSpeed;
        }
        else if (translation == -1)
        {
          translation *= Back.Boost;

          if (-translation > Back.MaxSpeed) translation = -Back.MaxSpeed;
        }
        
        translation *= Time.deltaTime;  // per second than per frame
        rotate *= Time.deltaTime;       // per second than per frame

        TankObj.transform.Rotate(Vector3.forward, -rotate); // make rotate
        TankObj.transform.Translate(Vector3.up * translation);  // make moving
    }
}
