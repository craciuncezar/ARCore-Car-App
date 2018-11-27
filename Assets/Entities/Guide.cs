using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide{
    public string GuideName { get; set; }
    public string Description { get; set; }
    private List<InstructionStep> instructionsList;

    public Guide(string guideName, string description, List<InstructionStep> instructionsList)
    {
        this.GuideName = guideName;
        this.Description = description;
        this.instructionsList = instructionsList;
    }

    public InstructionStep getInstruction(int index)
    {
        return instructionsList[index];
    }

    public int getInstructionsCount()
    {
        return instructionsList.Count;
    }
}
