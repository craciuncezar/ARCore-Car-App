using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AInstructionElement : MonoBehaviour {
    protected abstract void InstructionUpdate(InstructionStep step);

    void Awake()
    {
        FindObjectOfType<InstructionController>().OnInstructionUpdate.AddListener(InstructionUpdate);
    }
}
