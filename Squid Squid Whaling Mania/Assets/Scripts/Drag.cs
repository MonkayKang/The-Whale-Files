using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Vector3 mousePositionOffeset; // Find the mouse

    public bool isNpc;
    public bool isClue;

    public GameObject dialogue;
    public GameObject dialogue1;

    public GameObject clue1;
    public GameObject clue1CON;

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // Capture Mouse Offset
        if (!isNpc)
        {
            mousePositionOffeset = gameObject.transform.position - GetMouseWorldPosition();
        }

        if (isNpc)
        {
            dialogue.SetActive(true);
            dialogue1.SetActive(true);
        }

        if (isClue)
        {
            Dialogue.hasClue = true;
            clue1.SetActive(false); // Reveal Clue
            // Possible Addition Code
        }
    }

    private void OnMouseDrag()
    {
        if (!isNpc)
        {
            // Capture Mouse Offset
            transform.position = GetMouseWorldPosition() + mousePositionOffeset;
        }
    }

}
