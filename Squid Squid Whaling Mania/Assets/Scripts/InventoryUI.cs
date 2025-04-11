using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

[System.Serializable]

public class InventoryUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject cluePrefab;
    [SerializeField] private Transform inventoryContent;
    [SerializeField] private Image evidenceFillImage;
    [SerializeField] private GameObject hoverPanel;
    [SerializeField] private TextMeshProUGUI hoverText;
    [SerializeField] private Vector2 hoverOffset = new Vector2(0, 50);
    [SerializeField] private Transform factsContent;
    [SerializeField] private Transform dialogContent;
    [SerializeField] private Transform objectivesContent;
    [SerializeField] private GameObject factPrefab;  
    [SerializeField] private GameObject dialogPrefab; 
    [SerializeField] private GameObject objectivePrefab; 
    [SerializeField] private GameObject cluesPanel;
    [SerializeField] private GameObject factsPanel;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private GameObject objectivesPanel;

    public AudioSource source;
    public AudioClip clip;

    private void Start()
    {
        ValidateReferences();

        // Subscribe to updates
        InventoryManager.Instance.onInventoryUpdated += UpdateInventory;
        InventoryManager.Instance.onEvidenceUpdated += UpdateEvidenceMeter;
        InventoryManager.Instance.onInventoryUpdated += UpdateFacts;
        InventoryManager.Instance.onInventoryUpdated += UpdateDialog;

        // Force update UI on scene load
        UpdateInventory();
        UpdateFacts();
        UpdateDialog();
        UpdateObjectives();
        UpdateEvidenceMeter();

        hoverPanel.SetActive(false);
    }
    void Update()
    {
        if (source == null)
        {
            GameObject player = GameObject.Find("Player");
            if (player != null)
            {
                source = player.GetComponent<AudioSource>();
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            source.PlayOneShot(clip);
            CloseAllPanels();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetEvidenceMeter();
        }
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
        if (inventoryContent == null) return; // Prevent error if it's destroyed

        foreach (Transform child in inventoryContent)
        {
            if (child != null) Destroy(child.gameObject);
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

        AddTriggerEvent(trigger, EventTriggerType.PointerEnter, () => {
            hoverPanel.SetActive(true);
            hoverText.text = description;  // Update text when hovering
            PositionHoverPanel(target.GetComponent<RectTransform>());
        });

        AddTriggerEvent(trigger, EventTriggerType.PointerExit, () => {
            if (hoverText.text == description) 
            {
                hoverPanel.SetActive(false);
            }
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
        evidenceFillImage.fillAmount = InventoryManager.Instance.GetEvidence();
    }

    public void ResetEvidenceMeter()
    {
        evidenceFillImage.fillAmount = 0;
    }
    private void UpdateFacts()
    {
        Debug.Log($"Updating Facts UI | Total Facts: {InventoryManager.Instance.collectedFacts.Count}");

        foreach (Transform child in factsContent)
        {
            Destroy(child.gameObject);
        }

        foreach (Fact fact in InventoryManager.Instance.collectedFacts)
        {
            Debug.Log($"Creating Fact Entry: {fact.factID}, Image: {(fact.image != null ? "Exists" : "NULL")}");

            GameObject factEntry = Instantiate(factPrefab, factsContent);
            Image factImage = factEntry.GetComponent<Image>();

            if (factImage != null)
            {
                factImage.sprite = fact.image;
                factImage.SetNativeSize(); // <-- Force the image to adjust to its sprite
                factImage.enabled = false;
                factImage.enabled = true;  // <-- Force Unity to refresh the UI
                Debug.Log("Assigned Fact Image: " + factImage.sprite.name);
                Debug.Log($"Fact Image Assigned: {fact.factID}");
            }
            else
            {
                Debug.LogError($"Fact Prefab is missing an Image component!");
            }

            AddHoverEvents(factEntry, fact.description);
        }

    }
    private void UpdateDialog()
    {
        Debug.Log($"Updating Dialog UI | Total Dialogs: {InventoryManager.Instance.collectedDialogs.Count}");

        foreach (Transform child in dialogContent)
        {
            Destroy(child.gameObject);
        }

        foreach (NPCIntel dialog in InventoryManager.Instance.collectedDialogs)
        {
            Debug.Log($"Creating Dialog Entry: {dialog.npcID}, Image: {(dialog.npcImage != null ? "Exists" : "NULL")}");

            GameObject dialogEntry = Instantiate(dialogPrefab, dialogContent);
            Image dialogImage = dialogEntry.GetComponent<Image>();

            if (dialogImage != null)
            {
                dialogImage.sprite = dialog.npcImage;
                dialogImage.SetNativeSize();
                dialogImage.enabled = false;
                dialogImage.enabled = true;
                Debug.Log($"Dialog Image Assigned: {dialog.npcID}");
            }
            else
            {
                Debug.LogError($"Dialog Prefab is missing an Image component!");
            }

            AddHoverEvents(dialogEntry, dialog.dialogText);

        }
    }
    private void UpdateObjectives()
    {
        foreach (string obj in InventoryManager.Instance.objectives)
        {
            GameObject objEntry = Instantiate(objectivePrefab, objectivesContent);
            objEntry.GetComponent<TextMeshProUGUI>().text = obj;
        }
    }
    public void ShowPanel(string panelName)
    {
        cluesPanel.SetActive(panelName == "Clues");
        factsPanel.SetActive(panelName == "Facts");
        dialogPanel.SetActive(panelName == "Dialog");
        objectivesPanel.SetActive(panelName == "Objectives");

        Debug.Log($"Switching to panel: {panelName}");

        if (panelName == "Facts")
        {
            Debug.Log("Updating Facts UI...");
            UpdateFacts();
        }
        if (panelName == "Dialog")
        {
            Debug.Log("Updating Dialog UI...");
            UpdateDialog();
        }
        if (panelName == "Objectives")
        {
            Debug.Log("Updating Objectives UI...");
            UpdateObjectives();
        }
    }
    public void CloseAllPanels()
    {
        cluesPanel.SetActive(false);
        factsPanel.SetActive(false);
        dialogPanel.SetActive(false);
        objectivesPanel.SetActive(false);
    }

}
