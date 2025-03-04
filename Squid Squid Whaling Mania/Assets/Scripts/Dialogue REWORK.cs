using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueREWORK : MonoBehaviour
{
    public GameObject DialoguePanel;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;

    public float delay = 0.1f; // Delay between letters

    public TextMeshProUGUI DialogueText;

    public TextMeshProUGUI Button1Text;
    public TextMeshProUGUI Button2Text;
    public TextMeshProUGUI Button3Text;

    public string DialogueSetence;
    public string sentence1;
    public string sentence2;
    public string sentence3;

    private void Start()
    {
        Button1Text.text = sentence1;
        Button2Text.text = sentence2;
        Button3Text.text = sentence3;
    }

    private void OnMouseDown()
    {
        DialoguePanel.SetActive(true);
        Button1.SetActive(false);
        Button2.SetActive(false);
        Button3.SetActive(false);
        StartCoroutine(TypeSentence());
    }


    IEnumerator TypeSentence()
    {
        DialogueText.text = "";
        foreach (char letter in DialogueSetence)
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(delay);
        }

        SetButtonActive();
    }

    void SetButtonActive()
    {
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
    }
}
