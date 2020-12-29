using UnityEngine;
public class TrackMoving : MonoBehaviour
{
    [SerializeField]
    private Tank TankObj;           

    private float Translation = 0;
    private bool IsStopping = false;

    private void Update()
    {
        #region TrackMoving

        float direction = Input.GetAxis("Vertical");    

        direction *= Time.deltaTime;  

        if (direction > 0)
        {
            direction *= TankObj.TrackParams.BoostForward;

            if (direction > TankObj.TrackParams.MaxSpeedForward) direction = TankObj.TrackParams.MaxSpeedForward;
        }
        else if (direction < 0)
        {
            direction *= TankObj.TrackParams.BoostBack;

            if (-direction > TankObj.TrackParams.MaxSpeedBack) direction = -TankObj.TrackParams.MaxSpeedBack;
        }

        Translation += direction;

        if (Input.GetKeyDown("space")) IsStopping = true;

        if (Input.GetKeyUp("space")) IsStopping = false;

        if (IsStopping)
        {
            if (Translation < 0)
            {
                Translation += TankObj.TrackParams.BoostStop * Time.deltaTime;

                if (Translation > 0) Translation = 0;
            }
            else if (Translation > 0)
            {
                Translation -= TankObj.TrackParams.BoostStop * Time.deltaTime;

                if (Translation < 0) Translation = 0;
            }
        }


        TankObj.transform.Translate(Vector3.up * Translation);  
        #endregion

        #region TrackRotating

        float rotate = Input.GetAxis("Horizontal") * TankObj.TrackParams.BoostRotate;      

            rotate *= Time.deltaTime;       

            TankObj.transform.Rotate(Vector3.forward, -rotate);
        #endregion
    }
}
