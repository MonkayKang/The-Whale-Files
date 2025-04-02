using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableNPC : MonoBehaviour
{
    public NPCIntel dialogData;  // The dialog that this NPC will give

    private void OnMouseDown()
    {
        if (!InventoryManager.Instance.collectedDialogs.Contains(dialogData))
        {
            InventoryManager.Instance.AddDialog(dialogData);
        }
    }
}
