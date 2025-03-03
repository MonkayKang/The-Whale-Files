using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnMouseHover : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI textMeshPro;
    public string Description = "Dylan Was Here";
    public Vector2 offset = new Vector2(10f, 10f); // Offset to position the panel top right of the mouse

    // Used for any facts
    private void OnMouseOver()
    {
        panel.SetActive(true); // Activate Panel
        textMeshPro.text = Description; // Have the Text represent each object
    }

    private void OnMouseDown()
    {
        panel.SetActive(false); // Turn off the panel (this is to fix the UI issue)
    }

    private void OnMouseExit()
    {
        panel.SetActive(false); // Turn off the panel
    }
    private void Update()
    {
        if (panel.activeSelf)
        {
            UpdatePanelPosition(); // Update the position of the panel
        }
    }

    private void UpdatePanelPosition()
    {
        Vector2 mousePosition = Input.mousePosition; // Find Mouse
        panel.transform.position = mousePosition + offset; // Transform it
    }
}
