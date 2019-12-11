using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    private GameObject Camera;
    public GameObject Explosion;
    public Vector3 Direction;
    public Quaternion Rotation;
    public float Speed;
    delegate void SomeDelegate();
    SomeDelegate f;

    System.Random rnd = new System.Random();
    // Use this for initialization
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
        Destroy(this.gameObject, 20);
        Rotation = Quaternion.Euler(new Vector3(rnd.Next(-4, 4), rnd.Next(-4, 4), rnd.Next(-4, 4)));

        if (Rotation == Quaternion.Euler(new Vector3(0, 0, 0))){
            Rotation = Quaternion.Euler(new Vector3(3, 3, 3));
        }
        //Speed = rnd.Next(1, 5) * 2.0f;
        Speed = 0.15f;

        /*switch (rnd.Next(0,10))
        {
            case 0:
                f = new SomeDelegate(move0);
                break;
            case 1:
                f = new SomeDelegate(move0);
                break;
            case 2:
                f = new SomeDelegate(move1);
                break;
            case 3:
                f = new SomeDelegate(move1);
                break;
            case 4:
                f = new SomeDelegate(move2);
                break;
            case 5:
                f = new SomeDelegate(move2);
                break;
            case 6:
                f = new SomeDelegate(move3);
                break;
            case 7:
                f = new SomeDelegate(move3);
                break;
            case 8:
                f = new SomeDelegate(move4);
                break;
            case 9:
                f = new SomeDelegate(move4);
                break;
            default:
                break;
        }*/

        SoundManager.Instance.PlayAlarmAudio();
    }

    public void setMove(int s)
    {
        switch (s)
        {
            case 0:
                f = new SomeDelegate(move0);
                break;
            case 1:
                f = new SomeDelegate(move1);
                break;
            case 2:
                f = new SomeDelegate(move2);
                break;
            case 3:
                f = new SomeDelegate(move3);
                break;
            case 4:
                f = new SomeDelegate(move4);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        f();
        //move4();
    }

    //当たり判定
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "PlayerBullet" || coll.gameObject.tag == "MainCamera")
        {
            SoundManager.Instance.PlayExplosionAudio();
            if(coll.gameObject.tag == "PlayerBullet") ScoreManager.Instance.update();
            Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void move0()
    {
        Direction = new Vector3(Camera.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
        Direction = Direction - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Direction = Direction.normalized;
        transform.position += Direction * Speed;
        transform.rotation *= Rotation;
    }

    void move1()
    { 
        Direction = new Vector3(Camera.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
        Direction = Direction - new Vector3(transform.position.x , transform.position.y, transform.position.z);
        Direction = Direction.normalized;
        Vector3 current =  Quaternion.Euler(0, 90, 0) * Direction;
        Vector3 newDir = Vector3.RotateTowards(current, Direction, 1, 1);
        transform.position += newDir * (Speed * 1.2f);
        transform.rotation *= Rotation;
    }

    void move2()
    {
        Direction = new Vector3(Camera.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
        Direction = Direction - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Direction = Direction.normalized;
        Vector3 current = Quaternion.Euler(0, -90, 0) * Direction;
        Vector3 newDir = Vector3.RotateTowards(current, Direction, 1, 1);
        transform.position += newDir * (Speed * 1.2f);
        transform.rotation *= Rotation;
    }

    void move3()
    {
        Direction = new Vector3(Camera.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
        Direction = Direction - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        float a = Direction.magnitude;
        Direction = Direction.normalized;
        Vector3 current = Quaternion.Euler(0, -90, 0) * Direction * Mathf.Sin(a*0.1f);
        Vector3 newDir = Vector3.RotateTowards(current, Direction, 1, 1);
        if(newDir.y > 0)
        {
            newDir.y = -newDir.y;
        }
        transform.position += newDir * (Speed * 1.2f);
        transform.rotation *= Rotation;
    }

    void move4()
    {
        Direction = new Vector3(Camera.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
        Direction = Direction - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        float a = Direction.magnitude;
        Direction = Direction.normalized;
        Vector3 current = Quaternion.Euler(0, -90, 0) * Direction * Mathf.Sin(a * 0.2f);
        Vector3 newDir = Vector3.RotateTowards(current, Direction, 1, 1);
        if (newDir.y > 0)
        {
            newDir.y = -newDir.y;
        }
        transform.position += newDir * (Speed * 1.2f);
        transform.rotation *= Rotation;
    }
}