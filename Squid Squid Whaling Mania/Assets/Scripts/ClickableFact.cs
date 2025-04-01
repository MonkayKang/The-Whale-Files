using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableFact : MonoBehaviour
{
    public Fact factData;

    private void Start()
    {
        if (InventoryManager.Instance.collectedFacts.Contains(factData))
        {
            gameObject.SetActive(false); // Hide fact if already collected
        }
    }

    private void OnMouseDown()
    {
        if (!InventoryManager.Instance.collectedFacts.Contains(factData))
        {
            InventoryManager.Instance.AddFact(factData);
            gameObject.SetActive(false);  // Hide the object after it’s collected
        }
    }
}
