using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EthanScript : MonoBehaviour
{
    public GameObject DialoguePanel;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    private BoxCollider2D box2d;

    public float delay = 0.1f; // Delay between letters

    public TextMeshProUGUI DialogueText;

    public TextMeshProUGUI Button1Text;
    public TextMeshProUGUI Button2Text;
    public TextMeshProUGUI Button3Text;

    public string DialogueSetence;
    public string sentence1;
    public string sentence2;
    public string sentence3;

    private int TimesSpoken;
    private int TimesSpoken1;
    private int TimesSpoken2;

    private void Start()
    {
        box2d = GetComponent<BoxCollider2D>();
        TimesSpoken = 0;
        TimesSpoken1 = 0;
        TimesSpoken2 = 0;
        Button1Text.text = sentence1;
        Button2Text.text = sentence2;
        Button3Text.text = sentence3;
    }



    private void OnMouseDown()
    {
        StopAllCoroutines(); // Whoops The words keep stacking
        DialogueSetence = "Didn’t expect company. People don’t come here unless they have business with me. So, what are you after?";
        DialoguePanel.SetActive(true);
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        box2d.enabled = false;
        StartCoroutine(TypeSentence());
    }


    IEnumerator TypeSentence()
    {

        Button1Text.text = sentence1;
        Button2Text.text = sentence2;
        Button3Text.text = sentence3;
        SetButtonFalse();

        DialogueText.text = "";
        foreach (char letter in DialogueSetence)
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(delay);
        }

        SetButtonActive();
    }

    IEnumerator TypeSentence1()
    {

        Button1Text.text = sentence1;
        Button2Text.text = sentence2;
        Button3Text.text = sentence3;
        SetButtonFalse();

        DialogueText.text = "";
        foreach (char letter in DialogueSetence)
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(delay);
        }

        Button1.SetActive(true);
    }

    IEnumerator TypeSentence2()
    {

        Button1Text.text = sentence1;
        Button2Text.text = sentence2;
        Button3Text.text = sentence3;
        SetButtonFalse();

        DialogueText.text = "";
        foreach (char letter in DialogueSetence)
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(delay);
        }

        Button2.SetActive(true);
    }

    IEnumerator TypeSentence3()
    {

        Button1Text.text = sentence1;
        Button2Text.text = sentence2;
        Button3Text.text = sentence3;
        SetButtonFalse();

        DialogueText.text = "";
        foreach (char letter in DialogueSetence)
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(delay);
        }

        Button3.SetActive(true);
    }

    void SetButtonActive()
    {

        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);

    }

    void SetButtonFalse()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
    }

    public void Option1()
    {
        Button2.SetActive(false);
        Button3.SetActive(false);
        StopAllCoroutines(); // Ensure only one coroutine runs at a time

        if (TimesSpoken == 0)
        {
            DialogueSetence = "Then pass through somewhere else. I don’t like uninvited guests.";
            sentence1 = "Even if that means taking too much?";
            UI.fillAmount += 0.10f;
            TimesSpoken++;
        }
        else if (TimesSpoken == 1)
        {
            DialogueSetence = "That's the cost of doing business.";
            sentence1 = "You’re saying people disappear?";
            TimesSpoken++;
        }
        else if (TimesSpoken == 2)
        {
            DialogueSetence = "Let me give you some advice, curiosity is dangerous. Some questions don’t need answers.";
            TimesSpoken = 0;
            StartCoroutine(EndDialogue());
            return;
        }

        DialogueText.text = ""; // Reset before typing
        StartCoroutine(TypeSentence1());
    }

    public void Option2()
    {
        Button1.SetActive(false);
        Button3.SetActive(false);
        StopAllCoroutines(); // Ensure only one coroutine runs at a time

        if (TimesSpoken1 == 0)
        {
            DialogueSetence = "Market? I prefer to call it supply and demand. People want fish, I make sure they get it. Simple.";
            sentence2 = "Must take serious connections to keep supply steady.?";
            TimesSpoken1++;
        }
        else if (TimesSpoken1 == 1)
        {
            DialogueSetence = "I just make sure the right people stay in business. If that means some waters dry up, well… that’s the cost of doing business.";
            sentence2 = "Sounds like you’ve got everything under control.";
            TimesSpoken1++;
        }
        else if (TimesSpoken1 == 2)
        {
            DialogueSetence = "Let me give you some advice, curiosity is dangerous. Some questions don’t need answers.";
            TimesSpoken1 = 0;
            StartCoroutine(EndDialogue());
            return;
        }

        DialogueText.text = ""; // Reset before typing
        StartCoroutine(TypeSentence2());
    }

    public void Option3()
    {
        Button1.SetActive(false);
        Button2.SetActive(false);
        StopAllCoroutines(); // Ensure only one coroutine runs at a time

        if (TimesSpoken2 == 0)
        {
            DialogueSetence = "I prefer to call it supply and demand. People want fish, I make sure they get it. Simple.";
            sentence3 = "So you control who eats and who doesn’t?";
            TimesSpoken2++;
        }
        else if (TimesSpoken2 == 1)
        {
            DialogueSetence = "Control is a strong word. I just make sure the right people stay in business. If that means some waters dry up, well… that’s the cost of doing business.";
            sentence3 = "So you don’t worry about getting caught?";
            UI.fillAmount += 0.10f;
            TimesSpoken2++;
        }
        else if (TimesSpoken2 == 2)
        {
            UI.fillAmount += .10f;
            DialogueSetence = "Let me give you some advice, curiosity is dangerous. Some questions don’t need answers.";
            TimesSpoken2 = 0;
            StartCoroutine(EndDialogue());
            return;
        }

        DialogueText.text = ""; // Reset before typing
        StartCoroutine(TypeSentence3());
    }

    IEnumerator EndDialogue()
    {

        yield return StartCoroutine(TypeSentence()); // type response
        box2d.enabled = true;
        DialoguePanel.SetActive(false);

    }
}
