using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class BottleScript : GrabObjectScript
{
    bool PourZone = false;
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

        if ( y > 90 && y < 260 && !IgnorePourZone && PourZone)
        {
            Pour(y);
        }
    }

    public GameObject PourPoint;
    public GameObject FluidPrefab;
    public float pourSpeed = 5f;

    private void Pour(float y)
    {
        GameObject fluid = Instantiate(FluidPrefab, PourPoint.transform.position, Quaternion.identity);
        
        float radians = y * Mathf.Deg2Rad;
        Vector2 pourDirection = new Vector2(Mathf.Sin(radians), Mathf.Cos(radians));
        
        Rigidbody2D fluidRb = fluid.GetComponent<Rigidbody2D>();
        if (fluidRb != null)
        {
            
            fluidRb.linearVelocity = -pourDirection * pourSpeed;
        }
    }
}
