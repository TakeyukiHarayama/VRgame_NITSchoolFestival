using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{

    static float X_Speed = 0.5f;
    static float Z_Speed = 0.5f;

    public GameObject Bullet;

    public int life;
    static float intervalTime;
    static float cameraIntervalTime;
    //static int enemyCount;

    // Use this for initialization
    void Start()
    {
        intervalTime = 0;
        cameraIntervalTime = 0;
        //enemyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //移動(テストで作っただけ)

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey("up"))
        {
            transform.Translate(0, 0, vertical * Z_Speed);
        }
        if (Input.GetKey("down"))
        {
            transform.Translate(0, 0, vertical * Z_Speed);
        }
        if (Input.GetKey("left"))
        {
            transform.Translate(horizontal * X_Speed, 0, 0);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(horizontal * X_Speed, 0, 0);
        }


        //玉の発射
        intervalTime += Time.deltaTime;
        if (Input.GetKeyDown("space") | Input.GetMouseButtonDown(0))
        {
            if (intervalTime >= 0.3f)
            {
                intervalTime = 0.0f;
                //Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), GameObject.Find("Player").GetComponent<Transform>().rotation);
                SoundManager.Instance.PlayShootAudio();
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            if (life > 1)
            {
                life--;
            }
            else
            {
                SceneManager.LoadScene("gameover");
            }
        }
    }

    public void ToggleVRMode()
    {
        GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
    }
}
