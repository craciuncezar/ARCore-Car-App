
namespace GoogleARCore.ARController
{
    using System;
    using System.Collections.Generic;
    using GoogleARCore;
    using UnityEngine;

#if UNITY_EDITOR
    // Set up touch input propagation while using Instant Preview in the editor.
    using Input = InstantPreviewInput;
#endif

    public class ARController : MonoBehaviour
    {
        // Inspector fields for references
        [SerializeField]
        private GameObject searchingForPlaneUI;
        [SerializeField]
        private GameObject tapToPlaceUI;
        [SerializeField]
        private UIStateMenu guideUI;
        [SerializeField]
        private ARGraphic ARGraphic;
        [SerializeField]
        private InstructionController instructionController;
        [SerializeField]
        private GameObject guideNavigationUI;
        [SerializeField]
        private GameObject homePanel;
        [SerializeField]
        private DiscoverController discoverController;
        [SerializeField]
        private GameObject colorPanel;
        [SerializeField]
        private GameObject hintDiscoverUI;

        /// A list to hold all planes ARCore is tracking in the current frame. This object is used across
        /// the application to avoid per-frame allocations.
        private List<TrackedPlane> m_AllPlanes = new List<TrackedPlane>();

        /// True if the app is in the process of quitting due to an ARCore connection error, otherwise false.
        private bool m_IsQuitting = false;

        public void Update()
        {
            _UpdateApplicationLifecycle();

            // Hide snackbar when currently tracking at least one plane.
            Session.GetTrackables<TrackedPlane>(m_AllPlanes);
            bool showSearchingUI = true;
            for (int i = 0; i < m_AllPlanes.Count; i++)
            {
                if (m_AllPlanes[i].TrackingState == TrackingState.Tracking)
                {
                    showSearchingUI = false;
                    break;
                }
            }
            searchingForPlaneUI.SetActive(showSearchingUI);
            StateManager.Instance.SearchingTrackables = showSearchingUI;

            // Show tap to place information.
            tapToPlaceUI.SetActive(false);
            if (!StateManager.Instance.ModelPlaced && !StateManager.Instance.SearchingTrackables)
            {
                tapToPlaceUI.SetActive(true);
            }

        }

        private void _UpdateApplicationLifecycle()
        {
            // Exit the app when the 'back' button is pressed.
            if (Input.GetKey(KeyCode.Escape)){
                Application.Quit();
            }
            // Only allow the screen to sleep when not tracking.
            if (Session.Status != SessionStatus.Tracking){
                const int lostTrackingSleepTimeout = 15;
                Screen.sleepTimeout = lostTrackingSleepTimeout;
            } else {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }
            if (m_IsQuitting) {
                return;
            }
            // Quit if ARCore was unable to connect and give Unity some time for the toast to appear.
            if (Session.Status == SessionStatus.ErrorPermissionNotGranted) {
                _ShowAndroidToastMessage("Camera permission is needed to run this application.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
            else if (Session.Status.IsError()) {
                _ShowAndroidToastMessage("ARCore encountered a problem connecting.  Please start the app again.");
                m_IsQuitting = true;
                Invoke("_DoQuit", 0.5f);
            }
        }

        // Change app state buttons
        public void GuideButton()
        {
            try {
                GameObject.Find("DiscoverInfo").SetActive(false);
            }
            catch (Exception e) { Debug.Log(e); }
            ARGraphic.clearGraphic();
            guideUI.gameObject.SetActive(true);
            guideUI.ShowGuidePanel();
            homePanel.SetActive(false);
            discoverController.HideElementInfoPanel();
            colorPanel.SetActive(false);
        }

        public void HomeButton()
        {
            try {
                GameObject.Find("DiscoverInfo").SetActive(false);
            } catch(Exception e){ Debug.Log(e); }
            discoverController.HideElementInfoPanel();
            ARGraphic.clearGraphic();
            homePanel.SetActive(true);
            guideUI.gameObject.SetActive(false);
            guideNavigationUI.SetActive(false);
            colorPanel.SetActive(false);
        }

        public void DiscoverButton()
        {
            discoverController.HideElementInfoPanel();
            ARGraphic.clearGraphic();
            ARGraphic.openDoorAndHood();
            homePanel.SetActive(false);
            guideUI.gameObject.SetActive(false);
            guideNavigationUI.SetActive(false);
            colorPanel.SetActive(false);
            hintDiscoverUI.SetActive(true);
            Invoke("HideTip", 3f);
            GameObject parent = GameObject.FindWithTag("model");
            Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
            foreach (Transform t in trs)
            {
                if (t.name == "DiscoverInfo")
                {
                    t.gameObject.SetActive(true);
                }
            }
        }

        /// Actually quit the application.
        private void _DoQuit()
        {
            Application.Quit();
        }

        /// Show an Android toast message.
        public void _ShowAndroidToastMessage(string message)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            if (unityActivity != null)
            {
                AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
                unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity,
                        message, 0);
                    toastObject.Call("show");
                }));
            }
        }

        void HideTip()
        {
            hintDiscoverUI.SetActive(false);
        }
    }
}
