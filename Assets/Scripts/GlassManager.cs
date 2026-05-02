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

    public string CockTailName;
    public bool Umbrella;


    public GameObject GlassPrefab;
     public Vector3 SpawnPoint;

    void OnTriggerEnter2D(Collider2D collision)
    {

         
        if (collision.gameObject.tag == "ingredient")
        {
            ingredients ing = collision.gameObject.GetComponent<ingredients>();
            ingredientsInGlass.Add(ing.ingredientName);
            ing.DoInGlassEffect(this);
            AddedToGlass();
             
        }



        
        
    }

    public float FillProcent = 0;
    public GameObject fluid;
    public GameObject Fluidmass;
    public void FillCup()
    {
        if (FillProcent < 100)
        {
            FillProcent += 0.5f;
            
        }
        fluid.transform.localPosition = new Vector3(0, -3f + FillProcent * 0.05f, transform.position.z);
        Fluidmass.transform.localScale = new Vector3(2.208103f, FillProcent * 0.031f, 1);
        Fluidmass.transform.localPosition = new Vector3(0, (- FillProcent * 0.05f)/3, transform.position.z);

    }

    void Start()
    {   
        FillProcent = 0;
        Umbrella = false;
        RemoveAll();
        
        fluid.transform.localPosition = new Vector3(0, -3f + FillProcent * 0.05f, transform.position.z);
        Fluidmass.transform.localScale = new Vector3(2.208103f, FillProcent * 0.01f, 1);
        SpawnPoint = transform.position;
    }

    private void RemoveAll()
    {
        // Deactivate all ingredient effects
        for (int i = 0; i < ingredientsEffects.Length; i++)
        {
            ingredientsEffects[i].effect.SetActive(false);
        }
        
        // Clear the ingredients list
        ingredientsInGlass.Clear();
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
