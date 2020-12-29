using UnityEngine;
public class TowerMoving : MonoBehaviour
{
    [SerializeField]
    private Tank TankObj; // tank gameobject
    
    [SerializeField]
    private GameObject Tower; // tower of tank

    private float Rotate = 0; 
    private string State = "Stop"; // currect state of tower
    private void Update()
    {
        #region TowerMoving 
        if (Input.GetKeyDown("e") && State == "Stop")
            State = "Right";

        if (Input.GetKeyUp("e") && State == "Right")
            State = "Stop";

        if (Input.GetKeyDown("q") && State == "Stop")
            State = "Left";

        if (Input.GetKeyUp("q") && State == "Left")
            State = "Stop";

        if (State == "Stop")
        {
            if (Rotate < 0)
            {
                Rotate += TankObj.TowerParams.Boost;

                if (Rotate > 0) Rotate = 0;
            }
            else if (Rotate > 0)
            {
                Rotate -= TankObj.TowerParams.Boost;

                if (Rotate < 0) Rotate = 0;
            }
        }
        else if (State == "Right") 
        {
            Rotate += TankObj.TowerParams.Boost;

            if (Rotate > TankObj.TowerParams.MaxSpeed)
                Rotate = TankObj.TowerParams.MaxSpeed;
        } else if (State == "Left") 
        {
            Rotate -= TankObj.TowerParams.Boost;

            if (Rotate < -TankObj.TowerParams.MaxSpeed)
                Rotate = -TankObj.TowerParams.MaxSpeed;
        }

        Tower.transform.Rotate(Vector3.forward, -Rotate);

        #endregion
    }
}
