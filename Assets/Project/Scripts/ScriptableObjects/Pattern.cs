using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Pattern", order = 1)]
public class Pattern : ScriptableObject
{
    public int[] sequence;
    public string functionCall;
}
