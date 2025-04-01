using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fact", menuName = "Scriptable Objects/Fact")]
public class Fact : ScriptableObject
{
    public string factID;
    public Sprite image;
    [TextArea] public string description;
}
