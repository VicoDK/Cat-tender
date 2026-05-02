using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class BottleScript : GrabObjectScript
{
    public bool PourZone = false;
    public bool IgnorePourZone = false;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "IgnorePourZone")
        {
            IgnorePourZone = true;
            
        }

        if (other.gameObject.name == "PourZone" )
        {
            PourZone = true;
            gameObject.transform.SetParent(other.gameObject.transform);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "IgnorePourZone")
        {
            IgnorePourZone = false;
        }

        if (other.gameObject.name == "PourZone")
        {
            PourZone = false;
            gameObject.transform.SetParent(null);
        }
        
    }


    public void FixedUpdate()
    {
        float y = -16*(transform.localPosition.x*20)+180;


        if (PourZone && Mouse.current.leftButton.isPressed && !IgnorePourZone)
        {
            transform.rotation = Quaternion.Euler(0, 0, y);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }















    /*Transform glass;
    public float glassSize;
    public Vector3 startPos;
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
        distance = Mathf.Abs(startPos.x - glass.position.x);
        distanceY = Mathf.Abs(startPos.y - glass.position.y+glassSize);
    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
 
         thingy = (((( transform.position.x - distance)/distance) + buffer)*100); 
         heigtModifier = (((( transform.position.y - distanceY)/distanceY) + bufferY)*100)*-1; 
         if (transform.position.y < 0.08f && Mouse.current.leftButton.isPressed || Mouse.current.position.ReadValue().x > XLimit2 && Mouse.current.leftButton.isPressed)
         {
             transform.rotation = Quaternion.Euler(0, 0, 0);
         }
         else 
         {
             transform.rotation = Quaternion.Euler(0, 0, 160*(((100-thingy)/100)* (100-heigtModifier)/100));
         }
         



        
    }


    public float xLimit;
    public float XLimit2;


    public override void follow(float mousex, float mousey)
    {
        Debug.Log(mousex);

        if (mousex > xLimit)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, 10f));
        }
        else
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(xLimit, mousey, 10f));
        }
        
    }*/
}
