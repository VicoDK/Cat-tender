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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Glass" && collision.gameObject.GetComponent<GlassManager>().FillProcent < 100)
        {
            collision.gameObject.GetComponent<GlassManager>().FillCup();
            Destroy(gameObject);
        }
    }
}
