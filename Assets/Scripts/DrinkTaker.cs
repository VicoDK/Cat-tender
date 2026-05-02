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
    public GameObject MistakePromt;
    public TMP_Text MistakePromtText;
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
                MistakePromt.SetActive(true);
                MistakePromtText.text = "The drink is not full!";
                return;
            }

            if (Drink.GetComponent<GlassManager>().CockTailName != criteia.CockTailName)
            {
                MistakePromt.SetActive(true);
                MistakePromtText.text = "Wrong cocktail!";
                return;
            }

            if (Drink.GetComponent<GlassManager>().Umbrella != criteia.Umbrella)
            {
                MistakePromt.SetActive(true);
                if (criteia.Umbrella)
                {
                    MistakePromtText.text = "You forgot the umbrella!";
                }
                else
                {
                    MistakePromtText.text = "I didnt want an umbrella!";
                }

                return;
            }













            MistakePromt.SetActive(false);
            Instantiate(Drink.GetComponent<GlassManager>().GlassPrefab, Drink.GetComponent<GlassManager>().SpawnPoint, Quaternion.identity);
            Destroy(Drink);
            costumer.ServedDrink();
            
        }
    }
}
