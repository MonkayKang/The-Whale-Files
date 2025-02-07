using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string sentence = "Hello World!";
    public float delay = 0.1f; // Delay between letters

    public GameObject Panel;
    public GameObject Panel2;
    public GameObject option1Button;
    public GameObject option2Button;
    public GameObject option3Button;
    public GameObject option1CONButton;
    public GameObject option2CONButton;
    public GameObject option3CONButton;
    public GameObject Background;

    // Animation
    public GameObject NPCMotion;
    private Animator _anim;

    // Conditions
    public static bool hasClue;


    private bool hasSpoke = false;
    private int selectedOption = 0; // 1 = Option1, 2 = Option2, 3 = Option3

    private void Start()
    {
        _anim = NPCMotion.GetComponent<Animator>(); // Find the other objects animation
    }
    void OnEnable()
    {
        sentence = "Hello! What can I do for you?"; // Reset sentence every time it's enabled
        StartCoroutine(TypeSentence());
    }

    void OnDisable()
    {
        textDisplay.text = ""; // Reset text when deactivated
    }

    IEnumerator TypeSentence()
    {
        // **Disable everything before typing starts**
        Panel.SetActive(false);
        Panel2.SetActive(false);
        option1Button.SetActive(false);
        option2Button.SetActive(false);
        option3Button.SetActive(false);
        option1CONButton.SetActive(false);
        option2CONButton.SetActive(false);
        option3CONButton.SetActive(false);

        textDisplay.text = "";
        foreach (char letter in sentence)
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(delay);
        }

        // **Enable the correct UI elements after typing finishes**
        SetButtonsActive();
        _anim.SetBool("hasTalked", true); // set animation
    }

    public void Option1()
    {
        StopAllCoroutines();
        sentence = "I’m doing pretty good! Just did some fishing for my family today. Gotta put food on the table one way or another.";
        hasSpoke = true;
        _anim.SetBool("hasTalked", false); // set animation
        selectedOption = 1;
        StartCoroutine(TypeSentence());
    }

    public void Option1CON()
    {
        StopAllCoroutines();
        sentence = "Bye!";
        hasSpoke = false;
        _anim.SetBool("hasTalked", false); // set animation
        selectedOption = 0;
        StartCoroutine(EndDialogue()); // End Dialogue
    }

    public void Option2()
    {
        StopAllCoroutines();
        sentence = "No?! That’s illegal here, If I saw anything I would have reported it to nearby authorities.";
        hasSpoke = true;
        _anim.SetBool("hasTalked", false); // set animation
        selectedOption = 2;
        StartCoroutine(TypeSentence());
    }

    public void Option2CON()
    {
        StopAllCoroutines();
        sentence = "NO! How dare you accuse me of that! Leave my stall NOW! + SUS";
        UI.fillAmount += .10f; // Add Sus
        hasSpoke = false;
        _anim.SetBool("hasTalked", false); // set animation
        selectedOption = 0;
        StartCoroutine(EndDialogue()); // End Dialogue
    }

    public void Option3()
    {
        StopAllCoroutines();
        sentence = "It’s not what it looks like, someone put that there.";
        hasSpoke = true;
        _anim.SetBool("hasTalked", false); // set animation
        selectedOption = 3;
        StartCoroutine(TypeSentence());
    }

    public void Option3CON()
    {
        UI.fillAmount += .10f; // Add Sus
        StopAllCoroutines();
        sentence = "Okay fine... But I needed the money for my family. If you really want to find the culprit it's Balena Trade! They usually trade whale parts at the pier during the night.";
        hasSpoke = false;
        _anim.SetBool("hasTalked", false); // set animation
        selectedOption = 0;
        StartCoroutine(EndDialogue()); // End Dialogue
    }

    IEnumerator EndDialogue()
    {

        yield return StartCoroutine(TypeSentence()); // type response
        yield return new WaitForSeconds(1f); // delay before closing

        Panel.SetActive(false);
        Panel2.SetActive(false);
        option1Button.SetActive(false);
        option2Button.SetActive(false);
        option3Button.SetActive(false);
        option1CONButton.SetActive(false);  // Ignore this the game bypasses this regardless but it does help prevent looping
        option2CONButton.SetActive(false); // Will be worked on later
        option3CONButton.SetActive(false);

        gameObject.SetActive(false);
        Background.SetActive(false);
    }

    void SetButtonsActive()
    {
        if (hasSpoke)
        {
            Panel2.SetActive(true); // Show continue panel
            if (selectedOption == 1) option1CONButton.SetActive(true);
            if (selectedOption == 2) option2CONButton.SetActive(true);
            if (hasClue)
            {
                if (selectedOption == 3) option3CONButton.SetActive(true); // if the player has found the right clue
            }     
        }
        else
        {
            Panel2.SetActive(false);
            Panel.SetActive(true);
            option1Button.SetActive(true);
            option2Button.SetActive(true);

            if (hasClue)
            {
                option3Button.SetActive(true); // if the player has found the right clue
            }
        }
    }
}