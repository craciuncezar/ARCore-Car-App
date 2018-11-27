using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePanelController : MonoBehaviour {
    [SerializeField]
    private GameObject HelpPanel;
    [SerializeField]
    private SpawnObject spawnObject;
    [SerializeField]
    private GameObject colorPanel;

    public void hideHelpPanel()
    {
        HelpPanel.SetActive(false);
    }

    public void showHelpPanel()
    {
        HelpPanel.SetActive(true);
    }

    public void repositionCar()
    {
        if (StateManager.Instance.SelectedCar != null)
        {
            Destroy(StateManager.Instance.SelectedCar);
            StateManager.Instance.ModelPlaced = false;
            spawnObject.OnTogglePlanes(true);
        }
    }

    public void changeColor()
    {
        colorPanel.SetActive(!colorPanel.activeInHierarchy);
    }

    public void selectColor(string color)
    {
        GameObject car = GameObject.FindGameObjectWithTag("model");
        Material[] materials = car.GetComponent<Renderer>().sharedMaterials;
        materials[0].mainTexture= (Texture)Resources.Load(color);
    }
}
