using UnityEngine;
using UnityEngine.InputSystem;

public class ReadyButton : MonoBehaviour
{
    public GameObject EscapeMenu;

    public GameObject _Help;
    public void Ready(GameObject button)
    {
        button.SetActive(false);
    }

    public void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame &&!_Help.activeSelf )
        {
            escape();
            
        }

     
        
    }

    public void activeSelf(GameObject self)
    {
        self.SetActive(!self.activeSelf);
    }

    public void escape()
    {
            EscapeMenu.SetActive(!EscapeMenu.activeSelf );
            
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1f;
            }
    }

}
