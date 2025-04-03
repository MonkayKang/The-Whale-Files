using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [SerializeField] private float maxEvidence;
    private float currentEvidence;
    public List<Clue> collectedClues = new List<Clue>();
    public List<Fact> collectedFacts = new List<Fact>();
    public List<NPCIntel> collectedDialogs = new List<NPCIntel>();
    public List<string> objectives = new List<string>();
    public System.Action onEvidenceUpdated;
    public System.Action onInventoryUpdated;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;

            // Reset progress only if this is the first launch of the session
            if (!PlayerPrefs.HasKey("SessionStarted"))
            {
                PlayerPrefs.DeleteAll();
                PlayerPrefs.SetInt("SessionStarted", 1);
                PlayerPrefs.Save();
            }

            LoadCollectedClues();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void ResetGameProgress()
    {
        PlayerPrefs.DeleteKey("CollectedClues");
        PlayerPrefs.DeleteKey("CurrentEvidence");
        PlayerPrefs.DeleteKey("SessionStarted"); // Ensures a fresh reset
        PlayerPrefs.Save();

        collectedClues.Clear();
        currentEvidence = 0f;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        onInventoryUpdated?.Invoke(); // Refresh inventory UI
        onEvidenceUpdated?.Invoke();  // Refresh evidence meter
    }

    public void AddClue(Clue newClue)
    {
        if (!collectedClues.Contains(newClue))
        {
            collectedClues.Add(newClue);
            currentEvidence += newClue.evidenceValue;
            SaveCollectedClues();
            onEvidenceUpdated?.Invoke();
            onInventoryUpdated?.Invoke();

            if (currentEvidence >= maxEvidence)
            {
                LoadNextScene();
            }
        }
    }
    public void AddFact(Fact fact)
    {
        if (!collectedFacts.Contains(fact))
        {
            collectedFacts.Add(fact);
            Debug.Log($"Added Fact: {fact.factID} | Total Facts: {collectedFacts.Count}");
            onInventoryUpdated?.Invoke();
        }
        else
        {
            Debug.Log($"Fact already collected: {fact.factID}");
        }
    }
    public void AddDialog(NPCIntel dialog)
    {
        if (!collectedDialogs.Contains(dialog))
        {
            collectedDialogs.Add(dialog);
            Debug.Log($"Added Dialog: {dialog.npcID} | Total Dialogs: {collectedDialogs.Count}");
            onInventoryUpdated?.Invoke();
        }
        else
        {
            Debug.Log($"Dialog already collected: {dialog.npcID}");
        }
    }
        private void SaveCollectedClues()
    {
        List<string> collectedIDs = new List<string>();
        foreach (Clue clue in collectedClues)
        {
            collectedIDs.Add(clue.clueID);
        }

        PlayerPrefs.SetString("CollectedClues", string.Join(",", collectedIDs));
        PlayerPrefs.SetFloat("CurrentEvidence", currentEvidence);
        PlayerPrefs.Save();
    }

    private void LoadCollectedClues()
    {
        collectedClues.Clear();

        string savedClues = PlayerPrefs.GetString("CollectedClues", "");
        currentEvidence = PlayerPrefs.GetFloat("CurrentEvidence", 0f);

        if (!string.IsNullOrEmpty(savedClues))
        {
            string[] clueIDs = savedClues.Split(',');
            foreach (string id in clueIDs)
            {
                Clue clue = FindClueByID(id);
                if (clue != null)
                {
                    collectedClues.Add(clue);
                }
            }
        }
    }

    private Clue FindClueByID(string id)
    {
        Clue[] allClues = Resources.LoadAll<Clue>(""); // Ensure clues are in Resources folder
        foreach (Clue clue in allClues)
        {
            if (clue.clueID == id)
            {
                return clue;
            }
        }
        return null;
    }

    public bool IsClueCollected(Clue clue)
    {
        return collectedClues.Contains(clue);
    }

    public float GetEvidenceProgress()
    {
        return currentEvidence;
    }

    public float GetEvidence()
    {
        return currentEvidence / maxEvidence;
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Ensure there's a next scene before loading
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes to load!"); // Handle when at the last scene
        }
    }
}


