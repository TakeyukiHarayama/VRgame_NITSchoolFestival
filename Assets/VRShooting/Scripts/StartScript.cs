using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        System.GC.Collect();
        Resources.UnloadUnusedAssets();
        if(VRMode.vrmode == false)
            GvrViewer.Instance.VRModeEnabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PressStartButton()
    {
        SceneManager.LoadScene("vrs");
    }

    public void PressTutorialButton()
    {
        SceneManager.LoadScene("tutorial");
    }

    public void PressChangeVRModeButton()
    {
        VRMode.vrmode = !VRMode.vrmode;
        GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
    }
}
