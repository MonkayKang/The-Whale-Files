using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Vector3 mousePositionOffeset; // Find the mouse

    public bool ispart1;
    public bool isclose;
    public bool isDraggable;
    public bool isClickable;
    public bool isDESTROY;
    private bool isClicked;

    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;
    public GameObject exitbutton;

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
        if (ispart1)
        {
            object1.SetActive(true);
            object2.SetActive(true);
            object3.SetActive(true);
            object4.SetActive(true);
            isClicked = true;
        }

        if(isclose)
        {
            object1.SetActive(false);
            object2.SetActive(false);
            object3.SetActive(false);
            object4.SetActive(false);
            exitbutton.SetActive(false);
        }

        
    }

    private void OnMouseDrag()
    {
        if (isDraggable)
        {
            // Capture Mouse Offset
            transform.position = GetMouseWorldPosition() + mousePositionOffeset;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDESTROY && collision.gameObject.CompareTag("Destroyer"))
        {
            Debug.Log("hit");
            exitbutton.SetActive(true);
            gameObject.SetActive(false);
        }
    }


}
