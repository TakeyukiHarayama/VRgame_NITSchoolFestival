using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TutorialEnemyScript : MonoBehaviour
{
    public GameObject Explosion;
    public Text ScoreText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //当たり判定
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerBullet")
        {
            SoundManager.Instance.PlayExplosionAudio();
            Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);

            string text = ScoreText.text.Replace("Score: ", "");
            int score = Convert.ToInt32(text) + 100;

            this.ScoreText.text = "Score: " + score.ToString();
        }
    }
}