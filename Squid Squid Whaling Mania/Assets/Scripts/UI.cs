using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image targetImage;  // the image
    public static float fillAmount = 0f;  // The fill amount (0 to 1)
    public GameObject Map;
    private bool isPressed = false;

    void Start()
    {
        targetImage.fillAmount = fillAmount;
    }

    void Update()
    {
        targetImage.fillAmount = fillAmount;

        if (Input.GetKeyDown(KeyCode.M))
        {
            isPressed = !isPressed; // Toggle the state based on if the player has the mapopen or not
            Map.SetActive(isPressed);
        }
    }

    public void BeachSelect()
    {
        SceneManager.LoadScene("Beach");
    }

    public void LightSelect()
    {
        SceneManager.LoadScene("LightHouse");
    }
    public void PeirSelect()
    {
        SceneManager.LoadScene("Pier");
    }
}
