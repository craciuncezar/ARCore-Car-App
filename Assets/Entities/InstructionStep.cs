using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionStep : MonoBehaviour {
    public string Information { get; set; }
    public string ARPrefabName { get; set; }

    public InstructionStep(string information, string arPrefab)
    {
        Information = information;
        ARPrefabName = arPrefab;
    }
}
