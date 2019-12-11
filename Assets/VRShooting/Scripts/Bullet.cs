using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    float bulletSpeed = 2;
    private GameObject Camera;


    // Use this for initialization
    void Start () {
        Camera = GameObject.Find("Main Camera");
        transform.Rotate(Camera.transform.localEulerAngles.x, Camera.transform.localEulerAngles.y, Camera.transform.localEulerAngles.z);
        Destroy(this.gameObject, 3);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, bulletSpeed);
	}
   
}
