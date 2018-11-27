using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateMenu : MonoBehaviour {

    public Vector3 showPosition;
    private Vector3 hidePosition;
    private Vector3 desiredPosition;

    public GameObject arrow;
    private bool isVisiblePanel;
    public GameObject navigationPanel;

    public InstructionController instructionController;

    private void Awake()
    {
        hidePosition = transform.localPosition;
        desiredPosition = hidePosition;
        isVisiblePanel = false;
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, desiredPosition, 2f * Time.deltaTime);
    }

    public void ShowMenu()
    {
        desiredPosition = showPosition;
    }

    public void ShowGuidePanel()
    {
        if (isVisiblePanel)
        {
            arrow.transform.localRotation = Quaternion.Euler(0, 0, 0);
            desiredPosition = hidePosition;
        }
        else
        {
            arrow.transform.localRotation = Quaternion.Euler(0, 0, 180);
            desiredPosition = showPosition;
        }
        isVisiblePanel = !isVisiblePanel;
    }

    public void SelectGuide(int guideNo)
    {
        navigationPanel.SetActive(true);
        this.ShowGuidePanel();
        instructionController.SelectGuide(guideNo);
    }
}
