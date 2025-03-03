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
    public GameObject Inventory;
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
            Inventory.SetActive(false);
        }
        
    }

    public void BeachSelect()
    {
        SceneManager.LoadScene("Beach");
    }

    public void LightSelect()
    {
        SceneManager.LoadScene("Pier"); // THE CODE IS IS MESSED UP AND THE NAMING IS OFF
    }
    public void PeirSelect()
    {
        SceneManager.LoadScene("Hideout"); // THESE ARE THE CORRECT NAMES
    }

    public void ShowEvidence()
    {
        Inventory.SetActive(true);

    }
}
