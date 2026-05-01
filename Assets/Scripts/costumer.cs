using UnityEngine;

public class costumer : MonoBehaviour
{
    [HideInInspector] public Transform barCenter;
    [HideInInspector] public Transform exitPoint;
    [HideInInspector] public BarManager barManager;
    public float moveSpeed = 2f;
    public bool Served;
    public bool testbool = false;
    

    void FixedUpdate()
    {
        if (barCenter != null && !Served && Vector3.Distance(transform.position, barCenter.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, barCenter.position, moveSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, barCenter.position) < 0.1f)
        {
            barManager.CustomerReady = true;
        }




        if (Served)
        {
            barManager.CustomerReady = false;
            transform.position = Vector3.MoveTowards(transform.position, exitPoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, exitPoint.position) < 0.1f)
            {
                Destroy(gameObject);
            }
           

        }

        if (testbool)
        {
            Served = true;
            testbool = false;
        }

    }



}
