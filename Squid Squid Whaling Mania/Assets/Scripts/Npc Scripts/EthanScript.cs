using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EthanScript : MonoBehaviour
{
    private bool isSkipping = false;

    public GameObject DialoguePanel;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    public GameObject SkipButton; // Prevent two skips

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


    // Audio 
    public AudioSource audioSource; // Assign in Inspector
    public AudioClip dialogueClip; // Assign the sound effect
    public float minPitch = 0.8f;
    public float maxPitch = 1.2f;

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
        SkipButton.SetActive(true); // No more skipping

        Button1Text.text = sentence1;
        Button2Text.text = sentence2;
        Button3Text.text = sentence3;
        SetButtonFalse();

        float lastPlayTime = 0f;
        float minPlayInterval = 0.15f; // Adjust this value to control the minimum time between sounds

        DialogueText.text = "";
        foreach (char letter in DialogueSetence)
        {
            if (isSkipping)
            {
                DialogueText.text = DialogueSetence; // Instantly complete text
                isSkipping = false; // Reset flag
                break;
            }

            DialogueText.text += letter;

            // Play sound only if enough time has passed since last sound
            if (Time.time - lastPlayTime >= minPlayInterval)
            {
                audioSource.pitch = Random.Range(minPitch, maxPitch);
                audioSource.PlayOneShot(dialogueClip);
                lastPlayTime = Time.time;
            }

            yield return new WaitForSeconds(delay); // Keep text speed the same
        }

        SetButtonActive();
        SkipButton.SetActive(false); // No more skipping
    }

    IEnumerator TypeSentence1()
    {

        Button1Text.text = sentence1;
        Button2Text.text = sentence2;
        Button3Text.text = sentence3;
        SetButtonFalse();

        float lastPlayTime = 0f;
        float minPlayInterval = 0.15f; // Adjust this value to control the minimum time between sounds

        DialogueText.text = "";
        foreach (char letter in DialogueSetence)
        {
            if (isSkipping)
            {
                DialogueText.text = DialogueSetence; // Instantly complete text
                isSkipping = false; // Reset flag
                break;
            }

            DialogueText.text += letter;

            // Play sound only if enough time has passed since last sound
            if (Time.time - lastPlayTime >= minPlayInterval)
            {
                audioSource.pitch = Random.Range(minPitch, maxPitch);
                audioSource.PlayOneShot(dialogueClip);
                lastPlayTime = Time.time;
            }

            yield return new WaitForSeconds(delay); // Keep text speed the same
        }
        Button1.SetActive(true);
        SkipButton.SetActive(false); // No more skipping
    }

    IEnumerator TypeSentence2()
    {

        Button1Text.text = sentence1;
        Button2Text.text = sentence2;
        Button3Text.text = sentence3;
        SetButtonFalse();

        float lastPlayTime = 0f;
        float minPlayInterval = 0.15f; // Adjust this value to control the minimum time between sounds

        DialogueText.text = "";
        foreach (char letter in DialogueSetence)
        {
            if (isSkipping)
            {
                DialogueText.text = DialogueSetence; // Instantly complete text
                isSkipping = false; // Reset flag
                break;
            }

            DialogueText.text += letter;

            // Play sound only if enough time has passed since last sound
            if (Time.time - lastPlayTime >= minPlayInterval)
            {
                audioSource.pitch = Random.Range(minPitch, maxPitch);
                audioSource.PlayOneShot(dialogueClip);
                lastPlayTime = Time.time;
            }

            yield return new WaitForSeconds(delay); // Keep text speed the same
        }

        Button2.SetActive(true);
        SkipButton.SetActive(false); // No more skipping
    }

    IEnumerator TypeSentence3()
    {

        Button1Text.text = sentence1;
        Button2Text.text = sentence2;
        Button3Text.text = sentence3;
        SetButtonFalse();

        float lastPlayTime = 0f;
        float minPlayInterval = 0.15f; // Adjust this value to control the minimum time between sounds

        DialogueText.text = "";
        foreach (char letter in DialogueSetence)
        {
            if (isSkipping)
            {
                DialogueText.text = DialogueSetence; // Instantly complete text
                isSkipping = false; // Reset flag
                break;
            }

            DialogueText.text += letter;

            // Play sound only if enough time has passed since last sound
            if (Time.time - lastPlayTime >= minPlayInterval)
            {
                audioSource.pitch = Random.Range(minPitch, maxPitch);
                audioSource.PlayOneShot(dialogueClip);
                lastPlayTime = Time.time;
            }

            yield return new WaitForSeconds(delay); // Keep text speed the same
        }

        Button3.SetActive(true);
        SkipButton.SetActive(false); // No more skipping
    }

    void SetButtonActive()
    {
        SkipButton.SetActive(false);
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
        SkipButton.SetActive(true); // No more skipping
        Button2.SetActive(false);
        Button3.SetActive(false);
        StopAllCoroutines(); // Ensure only one coroutine runs at a time

        if (UI.fillAmount >= 0.50f)
        {
            // If UI.fillAmount is 0.50 or higher
            DialogueSetence = "You’ve been pretty involved in this, haven’t you? Maybe you’re starting to see how messy things really are.";
            StartCoroutine(EndDialogue());
        }
        else
        {
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
    }

    public void Option2()
    {
        SkipButton.SetActive(true); // No more skipping
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
            UI.fillAmount -= .10f;
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
        SkipButton.SetActive(true); // No more skipping
        Button1.SetActive(false);
        Button2.SetActive(false);
        StopAllCoroutines(); // Ensure only one coroutine runs at a time

        if (UI.fillAmount >= 0.50f)
        {
            // If UI.fillAmount is 0.50 or higher
            DialogueSetence = "You’ve been pretty involved in this, haven’t you? Maybe you’re starting to see how messy things really are.";
            StartCoroutine(EndDialogue());
        }
        else
        {

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
                DialogueSetence = "Let me give you some advice, curiosity is dangerous. Some questions don’t need answers.";
                TimesSpoken2 = 0;
                StartCoroutine(EndDialogue());
                return;
            }
            DialogueText.text = ""; // Reset before typing
            StartCoroutine(TypeSentence3());
        }
    }

    IEnumerator EndDialogue()
    {

        yield return StartCoroutine(EndSentence()); // type response
        yield return new WaitForSeconds(2f);
        box2d.enabled = true;
        DialoguePanel.SetActive(false);

    }

    public void isSkip()
    {
        isSkipping = true;
    }

    public void Disable()
    {
        SkipButton.SetActive(false);
    }

    IEnumerator EndSentence()
    {
        SkipButton.SetActive(true); // No more skipping

        Button1Text.text = sentence1;
        Button2Text.text = sentence2;
        Button3Text.text = sentence3;
        SetButtonFalse();

        float lastPlayTime = 0f;
        float minPlayInterval = 0.15f; // Adjust this value to control the minimum time between sounds

        DialogueText.text = "";
        foreach (char letter in DialogueSetence)
        {
            if (isSkipping)
            {
                DialogueText.text = DialogueSetence; // Instantly complete text
                isSkipping = false; // Reset flag
                break;
            }

            DialogueText.text += letter;

            // Play sound only if enough time has passed since last sound
            if (Time.time - lastPlayTime >= minPlayInterval)
            {
                audioSource.pitch = Random.Range(minPitch, maxPitch);
                audioSource.PlayOneShot(dialogueClip);
                lastPlayTime = Time.time;
            }

            yield return new WaitForSeconds(delay); // Keep text speed the same
        }
        SkipButton.SetActive(false); // No more skipping
    }
}
