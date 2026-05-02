using UnityEngine;

public class ReadyButton : MonoBehaviour
{
    public void Ready(GameObject button)
    {
        button.SetActive(false);
    }

}
