using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject cluePrefab;
    [SerializeField] private Transform inventoryContent;
    [SerializeField] private Slider evidenceMeter;
    [SerializeField] private GameObject hoverPanel;
    [SerializeField] private TextMeshProUGUI hoverText;
    [SerializeField] private Vector2 hoverOffset = new Vector2(0, 50);

    private void Start()
    {
        ValidateReferences();
        InventoryManager.Instance.onInventoryUpdated += UpdateInventory;
        InventoryManager.Instance.onEvidenceUpdated += UpdateEvidenceMeter;
        hoverPanel.SetActive(false);
    }

    private void ValidateReferences()
    {
        Debug.Assert(hoverPanel != null, "Hover Panel not assigned!");
        Debug.Assert(hoverText != null, "Hover Text not assigned!");
    }

    private void UpdateInventory()
    {
        ClearInventory();
        PopulateClues();
    }

    private void ClearInventory()
    {
        foreach (Transform child in inventoryContent)
        {
            Destroy(child.gameObject);
        }
    }

    private void PopulateClues()
    {
        foreach (Clue clue in InventoryManager.Instance.collectedClues)
        {
            GameObject clueEntry = CreateClueEntry(clue);
            AddHoverEvents(clueEntry, clue.description);
        }
    }

    private GameObject CreateClueEntry(Clue clue)
    {
        GameObject entry = Instantiate(cluePrefab, inventoryContent);
        entry.GetComponent<Image>().sprite = clue.image;
        return entry;
    }

    private void AddHoverEvents(GameObject target, string description)
    {
        EventTrigger trigger = target.AddComponent<EventTrigger>();

        // Hover Enter
        AddTriggerEvent(trigger, EventTriggerType.PointerEnter, () => {
            hoverPanel.SetActive(true);
            hoverText.text = description;
            PositionHoverPanel(target.GetComponent<RectTransform>());
        });

        // Hover Exit
        AddTriggerEvent(trigger, EventTriggerType.PointerExit, () => {
            hoverPanel.SetActive(false);
        });
    }

    private void AddTriggerEvent(EventTrigger trigger, EventTriggerType type, UnityEngine.Events.UnityAction action)
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = type;
        entry.callback.AddListener((data) => action());
        trigger.triggers.Add(entry);
    }

    private void PositionHoverPanel(RectTransform target)
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        RectTransform hoverRect = hoverPanel.GetComponent<RectTransform>();

        Vector3[] corners = new Vector3[4];
        target.GetWorldCorners(corners);
        Vector3 upperRight = corners[2];

        hoverRect.position = upperRight + (Vector3)hoverOffset;
    }

    private void UpdateEvidenceMeter()
    {
        evidenceMeter.value = InventoryManager.Instance.GetEvidenceProgress();
    }
}
