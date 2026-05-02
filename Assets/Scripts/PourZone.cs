using UnityEngine;

public class PourZone : MonoBehaviour
{
    public GrabObjectScript grabObjectScript;
    Collider2D col;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabObjectScript.GettingDragged)
        {
            col.enabled = false;
        }
        else
        {
            col.enabled = true;
        }
    }
}
