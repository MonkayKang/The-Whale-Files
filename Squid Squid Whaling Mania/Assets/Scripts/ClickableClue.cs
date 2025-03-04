using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableClue : MonoBehaviour
{
    public Clue clueData;

    private void Start()
    {
        if (InventoryManager.Instance.IsClueCollected(clueData))
        {
            gameObject.SetActive(false); // Hide clue if already collected
        }
    }

    private void OnMouseDown()
    {
        if (!InventoryManager.Instance.collectedClues.Contains(clueData))
        {
            InventoryManager.Instance.AddClue(clueData);
            gameObject.SetActive(false);
        }
    }
}
