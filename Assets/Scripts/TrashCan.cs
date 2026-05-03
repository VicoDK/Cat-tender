using UnityEngine;
using UnityEngine.InputSystem;

public class TrashCan : MonoBehaviour
{
    public GameObject Drink;
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drink"))
        {
            Drink = null;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drink"))
        {
            Drink = collision.gameObject;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (!Mouse.current.leftButton.isPressed && Drink != null)
        {
            Invoke("Delete", 0.01f);
            
        }
        
    }

    public void Delete()
    {
        Instantiate(Drink.GetComponent<GlassManager>().GlassPrefab, Drink.GetComponent<GlassManager>().SpawnPoint, Quaternion.identity);
        Destroy(Drink);
    }
}
