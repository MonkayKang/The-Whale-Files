using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clue", menuName = "Scriptable Objects/Clue")]
public class Clue : ScriptableObject
{
    public string clueID;
    public string clueName;
    [TextArea] public string description;
    public Sprite image;
    public float evidenceValue;
}