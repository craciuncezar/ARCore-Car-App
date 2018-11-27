using GoogleARCore;
using GoogleARCore.HelloAR;
using Lean.Touch;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    // References from unity inspector
    [SerializeField]
    private Camera FirstPersonCamera;
    [SerializeField]
    private GameObject CarPrefab;
    [SerializeField]
    private GameObject helpUI;
    [SerializeField]
    private GameObject homePanel;
    [SerializeField]
    private UIStateMenu stateUI;
    [SerializeField]
    private InstructionController instructionController;
    
    public void Spawn(LeanFinger finger)
    {
        if (CarPrefab != null && finger != null) {
            // Raycast against the location the player touched to search for planes
            TrackableHit hit;
            TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
                                             TrackableHitFlags.FeaturePointWithSurfaceNormal;
            if (Frame.Raycast(finger.ScreenPosition.x, finger.ScreenPosition.y, raycastFilter, out hit) 
                            && !StateManager.Instance.ModelPlaced) {
                // Use hit pose and camera pose to check 
                // If hittest is from the back of the plane, if it is, no need to create the anchor
                if ((hit.Trackable is TrackedPlane) && 
                    Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position, hit.Pose.rotation * Vector3.up) < 0){
                    Debug.Log("Hit at back of the current DetectedPlane");
                } else {
                    // Instantiate Car model at the hit pose.
                    GameObject carObject = Instantiate(CarPrefab, hit.Pose.position, hit.Pose.rotation);
                    // Compensate for the hitPose rotation facing away from the raycast
                    carObject.transform.Rotate(0, 180.0f, 0, Space.Self);
                    // Change the state and hide the planes graphic
                    StateManager.Instance.SelectedCar = carObject;
                    StateManager.Instance.ModelPlaced = true;
                    OnTogglePlanes(false);
                    // Create an anchor to allow ARCore to track the hitpoint as understanding of the physical world evolves
                    var anchor = hit.Trackable.CreateAnchor(hit.Pose);
                    carObject.transform.parent = anchor.transform;
                    // Show the menu and a helpUI only the first time after placing the car
                    stateUI.ShowMenu();
                    if (StateManager.Instance.HelpShowed == false)
                    {
                        helpUI.SetActive(true);
                        StateManager.Instance.HelpShowed = true;
                    }
                    homePanel.SetActive(true);
                }
            }
        }
    }


    // Hide/show the planes visualizer
    public void OnTogglePlanes(bool flag)
    {
        foreach (GameObject plane in GameObject.FindGameObjectsWithTag("plane"))
        {
            Renderer r = plane.GetComponent<Renderer>();
            TrackedPlaneVisualizer t = plane.GetComponent<TrackedPlaneVisualizer>();
            r.enabled = flag;
            t.enabled = flag;
        }
    }
}
