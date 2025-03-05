using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogueREWORK : MonoBehaviour
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
        DialogueSetence = "Oh! Hi! Are you here to help track whale patterns? And did you hear about the whaling ships that Greenpeace exposed last month? Super shady stuff!";
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
            DialogueSetence = "Okay, so check this out! Greenpeace has been following ships that claim they’re doing ‘scientific research’ but are really hunting whales illegally. They turn off their trackers, change ship names, and move in restricted waters!";
            sentence1 = "Wait, they actually turn off their trackers? Isn’t that illegal?";
            TimesSpoken++;
        }
        else if (TimesSpoken == 1)
        {
            DialogueSetence = "YES! Turning off tracking signals, called Automatic Identification System (AIS) disabling, is a huge red flag! It usually means a ship doesn’t want to be found. And guess where we keep seeing them pop up? Near marine protected areas where whaling is banned.";
            sentence1 = "So… has anyone ever been caught doing this?";
            TimesSpoken++;
        }
        else if (TimesSpoken == 2)
        {
            DialogueSetence = "Yes! In 2019, Japan’s whalers were caught on camera killing minke whales in an area they swore was just ‘research.’ They denied everything! Until Greenpeace released undeniable proof to the world! That’s why exposing them is so important. If we don’t call them out, they’ll keep pretending it’s ‘legal’ when it’s not!";
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
            DialogueSetence = "*sides eye Leon up and down*";
            sentence2 = "What does Greenpeace do when they find these ships?";
            TimesSpoken1++;
        }
        else if (TimesSpoken1 == 1)
        {
            DialogueSetence = "We document everything! High-resolution images, videos, GPS logs. We use drones and satellite tracking to catch them in the act. Then we expose them to the public nand pressure governments to seize their illegal cargo!";
            sentence2 = "If it’s illegal, why isn’t it stopping?";
            TimesSpoken1++;
        }
        else if (TimesSpoken1 == 2)
        {
            DialogueSetence = "Because money. Some governments don’t want to enforce the bans because whaling companies fund their economy. Plus, there’s a black market for whale meat. As long as people keep buying, the hunting won’t stop.";
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
            // ADD SUS 2 DYLAN
            DialogueSetence = "*gasps and looks offend well side eyeing Leon*";
            sentence3 = "Sounds like a lot of effort just for some whales."; // ADD SUS 3 DYLAN
            TimesSpoken2++;
        }
        else if (TimesSpoken2 == 1)
        {
            DialogueSetence = "You think it’s just whales? The whole ocean ecosystem depends on them. Remove whales, and it messes up everything, fish populations, carbon storage, you name it!";
            sentence3 = "People get away with worse. Maybe it’s just business.";
            TimesSpoken2++;
        }
        else if (TimesSpoken2 == 2)
        {
            DialogueSetence = "I don’t know who you are, but you sound way too okay with illegal stuff. I think we’re done talking."; // ADD SUS 4 DYLAN DONT FORGET
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
