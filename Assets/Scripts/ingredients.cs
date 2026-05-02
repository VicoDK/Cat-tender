using UnityEngine;

public class ingredients : MonoBehaviour
{
    public string ingredientName;
    public bool DestroyOnGlass = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void DoInGlassEffect()
    {
        if (DestroyOnGlass)
        {
            Destroy(gameObject);
            
        }
    }
}
