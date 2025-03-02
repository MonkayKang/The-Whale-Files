using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] private float maxEvidence = 100f;
    private float currentEvidence;
    public List<Clue> collectedClues = new List<Clue>();

    public System.Action onEvidenceUpdated;
    public System.Action onInventoryUpdated;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddClue(Clue newClue) //adding clues to inventory and updating evidence meter
    {
        if (!collectedClues.Contains(newClue))
        {
            collectedClues.Add(newClue);
            currentEvidence += newClue.evidenceValue;
            onEvidenceUpdated?.Invoke();
            onInventoryUpdated?.Invoke();

            if (currentEvidence >= maxEvidence)
            {
                LoadNextScene();
            }
        }
    }

    private void LoadNextScene()
    {
        
    }

    public float GetEvidenceProgress()
    {
        return currentEvidence / maxEvidence;
    }

    
}
