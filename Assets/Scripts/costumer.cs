using Unity.Mathematics;
using UnityEngine;

public class costumer : MonoBehaviour
{
    [HideInInspector] public Transform barCenter;
    [HideInInspector] public Transform exitPoint;
    [HideInInspector] public BarManager barManager;

    [HideInInspector] public Transform target;
     public float moveSpeed = 2f;
    [HideInInspector]public bool Served;
    public GameObject prompt;



    //sinus ting
    public float a;
    public float b;

    

    void FixedUpdate()
    {
        if (target == null)
        {
            target = barCenter;
        }


        if (transform.position.x <= target.position.x)
        {
            float y = a*math.sin(b*transform.position.x + 1);
            transform.position += new Vector3(moveSpeed * Time.deltaTime, y , 0);

        }

        if (transform.position.x >= target.position.x)
        {
            barManager.CustomerReady = true;
            prompt.SetActive(true);

        }




        if (Served)
        {
            prompt.SetActive(false);
            if (target != exitPoint)
            {
                OrderComplete(exitPoint);
            }

            barManager.CustomerReady = false;
            
            if (Served && transform.position.x >= target.position.x)
            {
                Destroy(gameObject);
            }
           

        }


    }

    public void OrderComplete(Transform newTarget)
    {
        target = newTarget;
       
    }

    public void ServedDrink()
    {
        Served = true;
    }



}
