using UnityEngine;
using UnityEngine.InputSystem;

public class InputDebugScript : MonoBehaviour
{
    private Collider2D col2D;
    private Renderer rend;
    private bool onMouseDragCalled = false;
    private bool legacyInputWorked = false;
    private bool newInputSystemWorked = false;

    void Start()
    {
        col2D = GetComponent<Collider2D>();
        rend = GetComponent<Renderer>();
        Debug.Log("=== INPUT DEBUG START ===");
        Debug.Log("Has Collider2D: " + (col2D != null && col2D.enabled));
        Debug.Log("Has Renderer: " + (rend != null && rend.enabled));
        Debug.Log("Has MainCamera: " + (Camera.main != null));
    }

    void Update()
    {
        // Test New Input System (Legacy Input is disabled in Player Settings)
        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            
            if (hit.collider == col2D)
            {
                if (!newInputSystemWorked)
                {
                    Debug.Log("✓ NEW INPUT SYSTEM WORKS - Mouse is over collider!");
                    newInputSystemWorked = true;
                }
            }
        }
    }

    // This will tell us if OnMouseDrag is being called
    void OnMouseDrag()
    {
        if (!onMouseDragCalled)
        {
            Debug.Log("✓ OnMouseDrag() IS BEING CALLED!");
            onMouseDragCalled = true;
        }
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 200));
        GUILayout.Label("=== INPUT METHOD TEST ===", new GUIStyle(GUI.skin.label) { fontSize = 16, fontStyle = FontStyle.Bold });
        GUILayout.Label("Legacy Input: ✗ DISABLED", new GUIStyle(GUI.skin.label) { normal = { textColor = Color.red } });
        GUILayout.Label($"OnMouseDrag Called: {(onMouseDragCalled ? "✓ YES" : "✗ NO")}");
        GUILayout.Label($"New Input System: {(newInputSystemWorked ? "✓ YES" : "✗ NO")}", 
            new GUIStyle(GUI.skin.label) { normal = { textColor = newInputSystemWorked ? Color.green : Color.red } });
        GUILayout.Label("(Hold mouse over ice while playing)");
        GUILayout.EndArea();
    }
}
