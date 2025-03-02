using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableClue : MonoBehaviour
{
    public Clue clueData;

    private void OnMouseDown()
    {
        if (!InventoryManager.Instance.collectedClues.Contains(clueData))
        {
            InventoryManager.Instance.AddClue(clueData);
            gameObject.SetActive(false); // Remove clue from scene after collection
        }
    }
}
