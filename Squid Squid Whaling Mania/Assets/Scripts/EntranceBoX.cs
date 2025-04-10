using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntranceBoX : MonoBehaviour
{
    public GameObject Map;
    private bool hasPressed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Pier");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Pressed");
            if (!hasPressed && Map != null)
            {
                Debug.Log("On");
                Map.SetActive(true);
                hasPressed = true;
            }
            else if (hasPressed && Map != null)
            {
                Debug.Log("Off");
                Map.SetActive(false);
                hasPressed = false;
            }
        }
    }
}
