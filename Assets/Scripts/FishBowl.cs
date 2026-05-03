using UnityEngine;

public class FishBowl : MonoBehaviour
{
    public bool WaterRun;

    public Transform PourPoint;
    public GameObject WaterFluid;


    public void StartStopWater()
    {
        WaterRun = !WaterRun;
    }


    public void FixedUpdate()
    {
        if (WaterRun)
        {
            Instantiate(WaterFluid, PourPoint.position, Quaternion.identity); 
        }
    }
}
