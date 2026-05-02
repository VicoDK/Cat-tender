using UnityEngine;
using UnityEngine.InputSystem;

public class ItemExtracterScript : MonoBehaviour
{
        public bool GettingDragged = false;
        Collider2D col2D;
        public bool ones = true;
        public GameObject SpawnItem;
        GameObject item;
        void Start()
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

            if (Mouse.current.leftButton.wasPressedThisFrame && ones && hit.collider == col2D)
            {
                item = Instantiate(SpawnItem, transform.position, Quaternion.identity);
                ones = false;
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

        if (Mouse.current.leftButton.isPressed == false)
        {
            ones = true;
        }

    }

    public virtual void follow(float mousex, float mousey)
    {
        if (item != null)
        {
            item.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousex, mousey, 10f));
        }
    }
}
