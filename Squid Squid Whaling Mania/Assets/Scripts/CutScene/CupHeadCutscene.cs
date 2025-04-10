using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CupHeadCutscene : MonoBehaviour
{
    // Which trigger is this (max 3)
    public bool istext1;
    public bool istext2;
    public bool istext3;

    // The text that would write
    public TextMeshProUGUI Text1;
    public TextMeshProUGUI Text2;
    public TextMeshProUGUI Text3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (istext1 && Text1 != null)
            {
                Text1.gameObject.SetActive(true);
            }
            else if (istext2 && Text2 != null)
            {
                Text2.gameObject.SetActive(true);
            }
            else if (istext3 && Text3 != null)
            {
                Text3.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Text1 != null) Text1.gameObject.SetActive(false);
            if (Text2 != null) Text2.gameObject.SetActive(false);
            if (Text3 != null) Text3.gameObject.SetActive(false);
        }
    }
}