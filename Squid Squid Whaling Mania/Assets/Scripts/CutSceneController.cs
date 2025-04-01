using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutsceneController : MonoBehaviour
{
    [Header("Cutscene Settings")]
    public Sprite[] cutsceneImages;  // Array of images to display during the cutscene
    public float timePerImage = 10f;  // Time each image is displayed

    [Header("UI Elements")]
    public Image cutsceneImage;  // Reference to the Image component in the UI

    [Header("Scene Transition Settings")]
    public string nextSceneName;  // Name of the scene to load after the cutscene

    private void Start()
    {
        StartCoroutine(PlayCutscene());
    }

    private IEnumerator PlayCutscene()
    {

        // Loop through each image in the cutscene array
        foreach (Sprite image in cutsceneImages)
        {
            cutsceneImage.sprite = image;  // Change the sprite of the Image component
            yield return new WaitForSeconds(timePerImage);  // Wait for the specified time
        }

        // Once all images have been shown, load the next scene
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);  // Load the next scene
    }
}