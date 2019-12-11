using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameOverScript : MonoBehaviour {
    public float time;
    public GameObject canvas;
	// Use this for initialization
	void Start () {
        canvas.active = false;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if(time > 115)
        {
            canvas.active = true;
        }
    }

    public void PressStartButton()
    {
        SceneManager.LoadScene("home");
    }
}
