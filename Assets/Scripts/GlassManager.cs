using System;
using System.Collections.Generic;
using UnityEngine;


public class GlassManager : MonoBehaviour
{
    [System.Serializable] public class ingredientsListEffects 
    {
        public string ingredientName;
        public GameObject effect;
    }

    public List<string> ingredientsInGlass = new List<string>();

    public ingredientsListEffects[] ingredientsEffects;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ingredient")
        {
            ingredients ing = collision.gameObject.GetComponent<ingredients>();
            ingredientsInGlass.Add(ing.ingredientName);
            ing.DoInGlassEffect();
            AddedToGlass();
             
        }

        if (collision.gameObject.tag == "Fluid")
        {
            Debug.Log("Added Fluid");
             
        }

        
        
    }

    public void AddedToGlass()
    {
        for (int i = 0; i < ingredientsEffects.Length; i++)
        {
            for (int j = 0; j < ingredientsInGlass.Count; j++)
            {
                if (ingredientsEffects[i].ingredientName == ingredientsInGlass[j])
                {
                    ingredientsEffects[i].effect.SetActive(true);
                }
            }
        }
        
    }
}
