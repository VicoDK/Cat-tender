using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class GlassManager : MonoBehaviour
{
    [System.Serializable] public class ingredientsListEffects 
    {
        public string ingredientName;
        public GameObject effect;
    }

    public List<string> ingredientsInGlass = new List<string>();

    [System.Serializable] public class FluidAmounts 
    {
        public FluidAmounts(string _Fluid, float amount)
        {
            Fluid = _Fluid;
            Amount = amount;
        }
        public string Fluid;
        public float Amount;
    }
    public List<FluidAmounts> FluidList = new List<FluidAmounts>();

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
    public void FillCup(string FluidType)
    {
        if (FillProcent < 100)
        {
            FillProcent += 0.5f;

    
            int index = FluidList.FindIndex(f => f.Fluid == FluidType);
            if (index != -1)
            {
                FluidList[index].Amount += 0.5f;
            }
            else
            {
                FluidList.Add(new FluidAmounts(FluidType, 0.5f));
            }

            CockTailName = CheckCocktail();
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
        FluidList = new List<FluidAmounts>();
        fluid.transform.localPosition = new Vector3(0, -3f + FillProcent * 0.05f, transform.position.z);
        Fluidmass.transform.localScale = new Vector3(2.208103f, FillProcent * 0.01f, 1);
       
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
        CockTailName = CheckCocktail();
        
    }



    public List<Recipes> recipes = new List<Recipes>();

    [System.Serializable] public class Liquids 
    {
        public string FluidName;
        public float FluidAmount;
    }

    [System.Serializable] public class Recipes 
    {
        public List<Liquids> liquids = new List<Liquids>();
        public bool Catnip;
        public bool Ice;
        public string CocktilName;

    }


    public string CheckCocktail()
    {
            foreach (Recipes _recipes in recipes)
        {
            if ((ingredientsInGlass.Contains("CatNip") && !_recipes.Catnip) ||
                (!ingredientsInGlass.Contains("CatNip") && _recipes.Catnip))
            {
                continue;
            }

            if ((ingredientsInGlass.Contains("Ice") && !_recipes.Ice) ||
                (!ingredientsInGlass.Contains("Ice") && _recipes.Ice))
            {
                continue;
            }

            int validFluidCount = FluidList.Count(f => f.Amount >= 10);

            if (validFluidCount != _recipes.liquids.Count)
            {
                continue;
            }

            bool valid = true;

            foreach (FluidAmounts _FluidList in FluidList)
            {
                
                if (_FluidList.Amount < 10)
                    continue;

                int index = _recipes.liquids.FindIndex(f => f.FluidName == _FluidList.Fluid);

                if (index == -1 ||
                    _FluidList.Amount < _recipes.liquids[index].FluidAmount / 2)
                {
                    valid = false;
                    break;
                }
            }

            if (valid)
            {
                return _recipes.CocktilName;
            }

          
            
        }

        return null;

        /*foreach (Recipes _recipes in recipes)
        {
            if ((ingredientsInGlass.Contains("CatNip") && !_recipes.Catnip) || (!ingredientsInGlass.Contains("CatNip") && _recipes.Catnip) )
            {
                Debug.Log("not : " + _recipes.CocktilName + " catnip   ");
                continue;
            }


            if (FluidList.Count != _recipes.liquids.Count)
            {
                Debug.Log("not : " + _recipes.CocktilName + " fluid count    ");
                continue;
            }

            foreach (FluidAmounts _FluidList in FluidList)
            {
                
                int index = _recipes.liquids.FindIndex(f => f.FluidName == _FluidList.Fluid);


                if (index != -1)
                {
                    if (_FluidList.Amount < _recipes.liquids[index].FluidAmount/2)
                    {
                        Debug.Log("not : " + _recipes.CocktilName + " enogh   ");
                        continue;
                    }
                }
                else
                {
                    Debug.Log("not : " + _recipes.CocktilName + "    ");
                    continue;
                }
                
            }




            return _recipes.CocktilName;

            
        }



        return null;*/
    }


}
