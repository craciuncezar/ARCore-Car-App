using UnityEngine;

public class ARGraphic : AInstructionElement {
    private GameObject currentGraphic;

    protected override void InstructionUpdate(InstructionStep step)
    {
        clearGraphic();

        // Load step's graphic.
        if (!string.IsNullOrEmpty(step.ARPrefabName))
        {
            currentGraphic = FindObject(step.ARPrefabName);
            currentGraphic.SetActive(true);
            playStepAnimation(step.ARPrefabName);
        }
    }

    public void clearGraphic()
    {
        // Clear possible animations
        GameObject.Find("Tire").GetComponent<Animator>().Play("Idle");
        GameObject.Find("DoorRight").GetComponent<Animator>().Play("Idle");
        GameObject.Find("DoorLeft").GetComponent<Animator>().Play("Idle");
        GameObject.Find("CarHood").GetComponent<Animator>().Play("Idle");
        // Clear current graphic
        if (currentGraphic != null)
        {
            currentGraphic.SetActive(false);
            currentGraphic = null;
        }
    }

    public void playStepAnimation(string step)
    {
        switch (step)
        {
            case "TireOut":
                FindObject("Tire").GetComponent<Animator>().Play("RemoveTire");
                break;
            case "TireIn":
                FindObject("Tire").GetComponent<Animator>().Play("AddTire");
                break;
            case "Park":
                GameObject.Find("DoorRight").GetComponent<Animator>().Play("OpenDoorRight");
                GameObject.Find("DoorLeft").GetComponent<Animator>().Play("OpenDoorLeft");
                break;
            case "PopHood":
                GameObject.Find("DoorLeft").GetComponent<Animator>().Play("OpenDoorLeft");
                GameObject.Find("CarHood").GetComponent<Animator>().Play("OpenHood");
                break;
            case "Dipstick":
            case "CheckLevelOil":
            case "OilTank":
            case "AddTheOil":
            case "FindWindshieldCap":
            case "UnscrewWindshield":
            case "AddWindshield":
            case "ScrewWindshield":
                GameObject.Find("CarHood").GetComponent<Animator>().Play("OpenHood", 0, 0.99f);
                break;
            default:
                break;
        }
    }


    public void openDoorAndHood()
    {
        GameObject.Find("DoorRight").GetComponent<Animator>().Play("OpenDoorRight");
        GameObject.Find("DoorLeft").GetComponent<Animator>().Play("OpenDoorLeft");
        GameObject.Find("CarHood").GetComponent<Animator>().Play("OpenHood");
    }

    public GameObject FindObject(string name)
    {
        GameObject parent = StateManager.Instance.SelectedCar;
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }
}
