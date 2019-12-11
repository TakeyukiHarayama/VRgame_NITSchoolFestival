using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private static GameObject objSignal;

	// Use this for initialization
	void Start () {
        System.GC.Collect();
        Resources.UnloadUnusedAssets();
        if(VRMode.vrmode == false)
            GvrViewer.Instance.VRModeEnabled = false;
        objSignal = GameObject.Find("OverlayCanvas");
        objSignal.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PressResetButton()
    {
        SceneManager.LoadScene("home");
    }

    public void PressSignal()
    {
        objSignal.SetActive(true);
    }
}
