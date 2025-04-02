using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoahScript : MonoBehaviour
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
        DialogueSetence = "Hello there! Are you interested in helping protect whales and supporting stronger laws to keep them safe?";
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

        Button1.SetActive(true);
        SkipButton.SetActive(false); // No more skipping
    }

    IEnumerator TypeSentence2()
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

        Button2.SetActive(true);
        SkipButton.SetActive(false); // No more skipping
    }

    IEnumerator TypeSentence3()
    {
        SkipButton.SetActive(true);

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
                DialogueSetence = "Governments don’t move fast, and companies sure don’t like being told what to do. We push for stricter laws through the International Whaling Commission (stands for IWC). Heard of it?";
                sentence1 = "Yeah, they make the rules about whaling, right??";
                TimesSpoken++;
            }
            else if (TimesSpoken == 1)
            {
                DialogueSetence = "Exactly! They’re supposed to enforce bans and create protected zones, but without the right pressure, those rules don’t mean much. That’s why we need more public support.";
                sentence1 = "That’s why Greenpeace wants stricter laws?";
                TimesSpoken++;
            }
            else if (TimesSpoken == 2)
            {
                DialogueSetence = "Right. We push to close loopholes, stop fake ‘scientific’ whaling, and protect more ocean areas.";
                sentence1 = "Sounds like you know a lot about bending the rules.";
                UI.fillAmount += .10f;
                TimesSpoken++;
            }
            else if (TimesSpoken == 3)
            {
                DialogueSetence = "Rules are tricky. Some people talk about protecting whales, but behind closed doors? It’s a whole different story. That’s just how things work sometimes.";
                sentence1 = "You mean illegal hunting? Where does it happen?";
                TimesSpoken++;
            }
            else if (TimesSpoken == 4)
            {
                DialogueSetence = "Look, I probably shouldn’t be saying this, but if you really want to know… Some ships don’t just ‘go missing.’ They turn off their trackers. No signals, no proof. And they’re not always far away.";
                sentence1 = "So these ships… where do they offload their cargo?";
                TimesSpoken++;
            }
            else if (TimesSpoken == 5)
            {
                DialogueSetence = "Private docks. Hidden harbors. Sometimes, the deals don’t even happen on land, just ship to ship. No records, no trail.";
                sentence1 = "Wait! People around here know about this?";
                TimesSpoken++;
            }
            else if (TimesSpoken == 6)
            {
                DialogueSetence = "You’d be surprised. Some activists talk a big game but work both sides. Like (Name TBD)… guy’s got all the right connections if you catch my drift.";
                sentence1 = "And the IWC? Can’t they track this?";
                TimesSpoken++;
            }
            else if (TimesSpoken == 7)
            {
                DialogueSetence = "They try, but without real enforcement, it’s a losing battle. That’s why we need stronger laws, to give the IWC the power to actually shut this down. But not everyone wants that to happen… for obvious reasons.";
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
        Button1.SetActive(false);
        Button3.SetActive(false);
        StopAllCoroutines(); // Ensure only one coroutine runs at a time

            if (TimesSpoken1 == 0)
            {
                DialogueSetence = "The IWC makes the rules, like banning certain whales from being hunted and protecting parts of the ocean. But let’s be honest, not everyone listens lol.";
                sentence2 = "Not really. What do they do?";
                TimesSpoken1++;
            }
            else if (TimesSpoken1 == 1)
            {
                DialogueSetence = "They set the laws to stop whaling, but let’s be honest… not everyone listens. Some countries claim to hunt for 'scientific research,' but we both know what happens to those whales.";
                sentence2 = "So what happens when people break the rules?";
                TimesSpoken1++;
            }
            else if (TimesSpoken1 == 2)
            {
                DialogueSetence = "*(Noah gets all sus like.)* Some people just ‘ignore’ the rules. And let’s be real, there’s a lot of money in this industry. When money talks, laws don’t always matter.";
                TimesSpoken1 = 0;
                UI.fillAmount -= 0.10f;
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
                DialogueSetence = "It is. Governments don’t move fast, and companies sure don’t like being told what to do. We push for stricter laws through the International Whaling Commission (stands for IWC). Heard of it?";
                sentence3 = "Do the IWC’s rules even matter?";
                UI.fillAmount += .10f;
                TimesSpoken2++;
            }
            else if (TimesSpoken2 == 1)
            {
                DialogueSetence = "*(Noah smiles weirdly.)* Depends. The rules matter to the people who ‘follow’ them. But some folks… well, they see laws as more of a ‘suggestion’ hehehehehehe.";
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

        yield return StartCoroutine(EndSentence()); // end response
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
