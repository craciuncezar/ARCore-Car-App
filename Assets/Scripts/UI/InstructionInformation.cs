using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class InstructionInformation : AInstructionElement {
    protected override void InstructionUpdate(InstructionStep step)
    {
        GetComponent<Text>().text = step.Information;
    }
}
