using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DrinkTaker : MonoBehaviour
{

    public OrderManager.CriteiaList criteia;

    public GameObject Drink;
    public costumer costumer;
    public string PromptString;
    public TMP_Text promtText;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drink"))
        {
            Drink = collision.gameObject;
        }
    }

    public void Start()
    {
        criteia = GameObject.Find("OrderManager").GetComponent<OrderManager>().CriteiaCall();
        PromptString = criteia.Prompt;
        string newPomptString = PromptString.Replace("drink", criteia.CockTailName);
        if (criteia.Umbrella)
        {
            newPomptString += " with an umbrella";
        }
        promtText.text = newPomptString;



    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drink"))
        {
            Drink = null;
        }
    }

    public void Update()
    {
        if (!Mouse.current.leftButton.isPressed && Drink != null)
        {

            if (Drink.GetComponent<GlassManager>().FillProcent < 100)
            {
                Debug.Log("Not Filled");
                return;
            }

            if (Drink.GetComponent<GlassManager>().CockTailName != criteia.CockTailName)
            {
                Debug.Log("Wrong Cocktail");
                return;
            }














            Destroy(Drink);
            costumer.Served = true;
            
        }
    }
}
