using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private static StateManager _instance;
    public static StateManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public bool SearchingTrackables { get; set; }
    public bool ModelPlaced { get; set; }
    public GameObject SelectedCar { get; set; }
    public bool HelpShowed { get; set; }

}