using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FogOfWarManager : MonoBehaviour
{
    [SerializeField] private Image fogLocation2;
    [SerializeField] private Image fogLocation20;// The fog overlay for second location
    [SerializeField] private Image fogLocation3;
    [SerializeField] private Image fogLocation30;
    [SerializeField] private Image fogLocation31;// The fog overlay for third location
    [SerializeField] private float evidenceRequiredForLocation2 = 5f;
    [SerializeField] private float evidenceRequiredForLocation3 = 1f;

    private void Start()
    {
        // Subscribe to InventoryManager events so we update whenever evidence changes
        InventoryManager.Instance.onEvidenceUpdated += UpdateFog;

        // Update once at Start, in case evidence is already accumulated
        UpdateFog();
    }

    private void OnDestroy()
    {
        // Unsubscribe to avoid errors if object is destroyed
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.onEvidenceUpdated -= UpdateFog;
        }
    }

    private void UpdateFog()
    {
        // Get the raw amount of evidence the player currently has
        float currentEvidence = InventoryManager.Instance.GetEvidenceProgress();

        // If we don't meet the threshold, keep fog visible; otherwise, hide it
        bool showFogForLocation2 = currentEvidence < evidenceRequiredForLocation2;
        bool showFogForLocation3 = currentEvidence < evidenceRequiredForLocation3; 

        if (fogLocation2 != null)
        {
            fogLocation20.gameObject.SetActive(showFogForLocation2);
            fogLocation2.gameObject.SetActive(showFogForLocation2);
            Debug.Log("Beach visible");
        }

        if (fogLocation3 != null)
        {
            fogLocation30.gameObject.SetActive(showFogForLocation3);
            fogLocation31.gameObject.SetActive(showFogForLocation3);
            fogLocation3.gameObject.SetActive(showFogForLocation3);
            Debug.Log("Hideout visible");
        }
    }
}
