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
    public bool isBlood;

    public GameObject[] gameObjects; // makes it easier.

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
        if (UI.bloodSamples >= 3)
        {
            StartCoroutine(EndClue());
        }
    }

    private void OnMouseDown()
    {

        if (ispart1)
        {
            foreach (GameObject obj in gameObjects)
            {
                obj.SetActive(true);
            }
        }

        if(isclose)
        {
            foreach (GameObject obj in gameObjects)
            {
                obj.SetActive(false);
            }
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
       if (isBlood && collision.gameObject.CompareTag("Destroyer"))
        {
            UI.bloodSamples++;
            Destroy(gameObject);
        }
    }

    IEnumerator EndClue()
    {
        yield return new WaitForSeconds(1f);
        foreach (GameObject obj in gameObjects)
        {
            Destroy(obj);
        }
    }
}
