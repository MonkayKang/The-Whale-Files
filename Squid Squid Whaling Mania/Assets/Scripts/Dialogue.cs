using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string sentence = "Hello, Unity!";
    public float delay = 0.1f; // Delay between letters

    public bool isFish;

    void OnEnable()
    {
        StartCoroutine(TypeSentence());
    }

    void OnDisable()
    {
        textDisplay.text = ""; // Reset text when deactivated
    }

    IEnumerator TypeSentence()
    {
        textDisplay.text = "";
        foreach (char letter in sentence)
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(delay);
        }
    }

    private void Update()
    {

    }

    public void Option1()
    {
        sentence = "I’m doing pretty good! Just did some fishing for my family today.  Gotta put food on the table one way or another.";
        StartCoroutine(TypeSentence());
    }

    public void Option2()
    {
        sentence = "No?! That’s illegal here, If I did I would have reported it to a nearby authority.";
        StartCoroutine(TypeSentence());
    }

    public void Option3()
    {
        sentence = "It’s not what it looks like its not mine";
        StartCoroutine(TypeSentence());
    }


}
