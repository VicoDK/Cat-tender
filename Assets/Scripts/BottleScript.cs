using UnityEngine;

public class BottleScript : GrabObjectScript
{
    Transform glass;
    float glassSize;
    Vector3 startPos;
    float distance;
    float distanceY;
    float thingy;
    public float buffer;
    public float bufferY;

    public float heigtModifier = 1f;
    public void Start()
    {
        base.Start();
        glass = GameObject.Find("Glass").transform;
        glassSize = glass.localScale.x;
        startPos = transform.position;
        distance = Mathf.Abs(startPos.x - glass.position.x);
        distanceY = Mathf.Abs(startPos.y - glass.position.y+glassSize);
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();

         thingy = (((( transform.position.x - distance)/distance) + buffer)*100); 
         heigtModifier = (((( transform.position.y - distanceY)/distanceY) + bufferY)*100)*-1; 
         if (transform.position.y < 0.08f)
         {
             transform.rotation = Quaternion.Euler(0, 0, 0);
         }
         else 
         {
             transform.rotation = Quaternion.Euler(0, 0, 160*(((100-thingy)/100)* (100-heigtModifier)/100));
         }
         



        
    }


    public float xLimit;


    public override void follow(float mousex, float mousey)
    {

        if (mousex > xLimit)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, 10f));
        }
        else 
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(xLimit, mousey, 10f));
        }
        
    }
}
