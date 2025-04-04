using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class CutsceneController : MonoBehaviour
{
    [Header("Cutscene Settings")]
    public Sprite[] cutsceneImages;  // Array of images to display during the cutscene
    public float timePerImage = 10f;  // Time each image is displayed

    [Header("UI Elements")]
    public Image cutsceneImage;  // Reference to the Image component in the UI

    [Header("Scene Transition Settings")]
    public string nextSceneName;  // Name of the scene to load after the cutscene

    public TextMeshProUGUI ControlsText;
    private int imagesflipped = 0;
    private string dialogueText;

    private void Start()
    {
        imagesflipped = 0;
        StartCoroutine(PlayCutscene());
    }

    private IEnumerator PlayCutscene()
    {
        // Loop through each image in the cutscene array
        for (int i = 0; i < cutsceneImages.Length; i++)
        {
            imagesflipped = i; // Images Flipped
            cutsceneImage.sprite = cutsceneImages[i];
            yield return StartCoroutine(TypeSentence());
            yield return new WaitForSeconds(timePerImage);
        }

        LoadNextScene();
    }

    IEnumerator TypeSentence()
    {
        if (imagesflipped == 0)
        {
            dialogueText = "Left Click to Interact and Drag Items";
        }
        if (imagesflipped == 1)
        {
            dialogueText = "Right Click To Move Character (Based on Mouse Position)";
        }
        if (imagesflipped == 2)
        {
            dialogueText = "M to open the Map";
        }
        ControlsText.text = "";
        foreach (char letter in dialogueText) // Type out the string
        {
            ControlsText.text += letter;
            yield return new WaitForSeconds(.04f); // Keep text speed the same
        } 
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);  // Load the next scene
    }
}