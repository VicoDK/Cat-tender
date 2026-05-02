using UnityEngine;

public class FluidScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("DestroyFluid", 2f);
    }

    // Update is called once per frame
    void DestroyFluid()
    {
        Destroy(gameObject);
    }
}
