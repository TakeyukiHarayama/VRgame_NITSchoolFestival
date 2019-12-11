using UnityEngine;
using System.Collections;

public class SphereScript : MonoBehaviour {

    private GameObject Camera;
    public GameObject Explosion;

	// Use this for initialization
	void Start () {
        Camera = GameObject.Find("Main Camera");
        Destroy(this.gameObject, 10);
    }

    // Update is called once per frame
    void Update () {
        transform.LookAt(Camera.transform);
        transform.position += transform.forward * 0.05f;
	}

    //当たり判定
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "PlayerBullet")
        {
            SoundManager.Instance.PlayExplosionAudio();
            Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}