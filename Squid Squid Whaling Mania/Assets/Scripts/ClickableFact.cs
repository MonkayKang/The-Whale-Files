using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableFact : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
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
        source.PlayOneShot(clip);
        if (!InventoryManager.Instance.collectedFacts.Contains(factData))
        {
            InventoryManager.Instance.AddFact(factData);
            UI.FactsCollected += 1; // Add a fact counter
            gameObject.SetActive(false);  // Hide the object after it’s collected
        }
    }
}
