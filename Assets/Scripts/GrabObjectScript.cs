using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class GrabObjectScript : MonoBehaviour
{
     Collider2D col2D;
     [HideInInspector] public bool GettingDragged = false;
    public void Start()
    {

            col2D = GetComponent<Collider2D>();
        
    }


    public void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();

        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            
            if (hit.collider == col2D)
            { 
                GettingDragged = true;
                
            }
        }
        else
        {
            GettingDragged = false;
        }

        if (GettingDragged)
        {
            
            follow(mousePos.x, mousePos.y);
        }
    }

    public virtual void follow(float mousex, float mousey)
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, 10f));
    }
}
