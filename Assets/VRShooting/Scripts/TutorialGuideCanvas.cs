using UnityEngine;
using System.Collections;

public class TutorialGuideCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerBullet")
        {
            Destroy(coll.gameObject);
        }
    }
}
