using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.sceneLoaded += OnSceneLoaded;

#if UNITY_EDITOR
            PlayerPrefs.DeleteAll(); // Force reset in Editor Play Mode
            PlayerPrefs.Save();
#endif

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


