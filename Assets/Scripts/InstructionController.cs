using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstructionEvent : UnityEvent<InstructionStep> { }

public class InstructionController : MonoBehaviour {

    public InstructionEvent OnInstructionUpdate = new InstructionEvent();
    private Car car;
    private Guide currentGuide;
    private int currentStep;
    private bool updated;

    void Awake () {
        InitializeGUI();
        updated = false;
	}

    void Update()
    {
        if (!updated)
        {
            InitializeGUI();
        }
    }

    public void CurrentInstructionUpdate() {
        InstructionStep step = currentGuide.getInstruction(currentStep);
        OnInstructionUpdate.Invoke(step);
    }

    public void SelectGuide(int guideNo)
    {
        currentGuide = car.guides[guideNo];
        currentStep = 0;
        CurrentInstructionUpdate();
    }

    public void InitializeGUI()
    {
        currentStep = 0;
        car = Car.dummyCar();
        currentGuide = car.guides[0];
        CurrentInstructionUpdate();
    }

    public void NextStep() {
        if (currentStep < currentGuide.getInstructionsCount() - 1) {
            currentStep++;
            updated = true;
            CurrentInstructionUpdate();
        }
    }

    public void PreviousStep() {
        if (currentStep > 0) {
            currentStep--;
            updated = true;
            CurrentInstructionUpdate();
        }
    }
}
