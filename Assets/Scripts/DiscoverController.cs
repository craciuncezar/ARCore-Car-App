using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscoverController : MonoBehaviour {

    [SerializeField]
    private Camera FirstPersonCamera;
    [SerializeField]
    private GameObject elementInfoPanel;
    [SerializeField]
    private Text componentName;
    [SerializeField]
    private Text componentDescription;

    private Car car;

    void Awake()
    {
        car = Car.dummyCar();
    }

    // Hit test for icon tap.
    public void Hit(LeanFinger finger)
    {
        Ray raycast = FirstPersonCamera.ScreenPointToRay(finger.ScreenPosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(raycast, out raycastHit))
        {
            if (raycastHit.transform.CompareTag("gameObjectCollider"))
            {
                CarComponent component = car.carComponents[raycastHit.transform.name];
                elementInfoPanel.SetActive(true);
                componentName.text = component.Name;
                componentDescription.text = component.Description;
            }
        }
    }

    public void HideElementInfoPanel()
    {
        elementInfoPanel.SetActive(false);
    }


}
