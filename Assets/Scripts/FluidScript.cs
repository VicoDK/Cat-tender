using UnityEngine;

public class FluidScript : MonoBehaviour
{
    public string FluidType;
    void Start()
    {
        Invoke("DestroyFluid", 2f);
    }

    // Update is called once per frame
    void DestroyFluid()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Drink" && collision.gameObject.GetComponent<GlassManager>().FillProcent < 100)
        {
            collision.gameObject.GetComponent<GlassManager>().FillCup(FluidType);
            Destroy(gameObject);
        }
    }
}
