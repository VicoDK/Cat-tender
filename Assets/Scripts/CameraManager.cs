using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform Cam;
    public float camSpeed = 2f;
    public Transform ServePoint;
    public Transform MakePoint;
    
    public float Stage;
    public GameObject buttom;



    public void Update()
    {
        switch (Stage)
        {
            case 0:
                if (Vector3.Distance(Cam.transform.position, ServePoint.position) > 0.1f)
                {
                    Cam.transform.position = Vector3.MoveTowards(Cam.transform.position, ServePoint.position, camSpeed * Time.deltaTime);
                    
                }
                break;
            case 1:
                if (Vector3.Distance(Cam.transform.position, MakePoint.position) > 0.1f)
                {
                    Cam.transform.position = Vector3.MoveTowards(Cam.transform.position, MakePoint.position, camSpeed * Time.deltaTime);
                    
                }  
                break;
        }
    }

    public void stageChange()
    {
        switch (Stage)
        {
            case 0:
                Stage = 1;
                buttom.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case 1:
                Stage = 0;
                buttom.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        };
    }

}
