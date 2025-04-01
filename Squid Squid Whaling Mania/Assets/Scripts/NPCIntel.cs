using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Scriptable Objects/Dialog")]
public class NPCIntel : ScriptableObject
{
    public string npcID;
    public Sprite npcImage;
    [TextArea] public string dialogText;
}
