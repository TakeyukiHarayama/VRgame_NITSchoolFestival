using UnityEngine;
using System.Collections;
using System.IO;

public class EnemySpawner : MonoBehaviour
{

    public GameObject Enemy;
    public GameObject Player;
    // static float enemyIntervalTime;
    public float time;
    public int phase;
    float[][] values;
    public int length;
    //public float Interval;

    System.Random rnd = new System.Random();
    // Use this for initialization
    void Start()
    {
        phase = 0;
        time = 0.0f;

        values = new float[][]
        {

            new float[] {5,-76.8f,25.3f,-1.2f,0},
            new float[] {7,-98,2.5f,-50,2},
            new float[] {12,-66.9f,10,-10,4},
            new float[] {15,-119.4f,0,-76.8f,3},
            new float[] {16,-106,30,-85,4},
            new float[] {17,-75,10,-55,1},
            new float[] {24,-110,10,-100,1},
            new float[] {24,-95,5,-100,3},
            new float[] {29,-74,15,-105,1},
            new float[] {31,-80,5,-130,4},
            new float[] {34,-56,15,-100,0},
            new float[] {36,-60,13,-120,1},
            new float[] {38,-80.5f,1,-113,0},
            new float[] {42,-28,10,-95,3},
            new float[] {45,-58.5f,20.5f,-86.2f,0},
            new float[] {46,-50,20.5f,-86.2f,0},
            new float[] {47,-43.5f,20.5f,-86.2f,0},
            new float[] {48,-36.4f,20.5f,-86.2f,0},
            new float[] {49,-50,20.5f,-86.2f,0},
            new float[] {50,-43.5f,20.5f,-86.2f,0},
            new float[] {51,-36.4f,20.5f,-86.2f,0},
            new float[] {52,-58.5f,20.5f,-86.2f,0},
            new float[] {53,-36.4f,20.5f,-86.2f,0},
            new float[] {54,-50,20.5f,-86.2f,0},
            new float[] {55,-43.5f,20.5f,-86.2f,0},
            new float[] {56,-36.4f,20.5f,-86.2f,0},
            new float[] {58,-58.5f,20.5f,-86.2f,0},
            new float[] {58,-50,20.5f,-86.2f,0},
            new float[] {58,-43.5f,20.5f,-86.2f,0},
            new float[] {58,-36.4f,20.5f,-86.2f,0},
            new float[] {62,-37,25,-72,3},
            new float[] {63,-32,26,-68,3},
            new float[] {64,-35,30,-64,3},
            new float[] {66,-40,35,-60,1},
            new float[] {66,-30,38,-60,2},
            new float[] {68,-30,45,-40,2},
            new float[] {69,-40,45,-40,1},
            new float[] {72,-58.5f,20.5f,-86.2f,0},
            new float[] {72,-50,20.5f,-86.2f,0},
            new float[] {72,-43.5f,20.5f,-86.2f,0},
            new float[] {72,-36.4f,20.5f,-86.2f,0},
            new float[] {75,-52.7f,45.0f,-54.8f,4},
            new float[] {75,-52.7f,45.0f,-70.8f,1},
            new float[] {80,-52.7f,35,-45,2},
            new float[] {82,-57.5f,30,-52,2},
            new float[] {84,-55,30,-50,1},
            new float[] {86,-95,15,-70,2},
            new float[] {86,-95,30,-60,0},
            new float[] {86,-95,15,-80,1},
            new float[] {92,-90,30,-28.4f,0},
            new float[] {94,-53.7f,25,-35.4f,2},
            new float[] {94,-94,15,-21,1},
            new float[] {95,-100,20,-21,2},
            new float[] {98,-68.8f,20,-65.8f,0},
            new float[] {101,-58f,18,-90,0},
            new float[] {104,-64.6f,15,-107,4},
            new float[] {105,-64.6f,20,-99,2},
            new float[] {108,-72.6f,9,-80.5f,1},
            new float[] {109,-60,5,-84,2}
        };

        length = values.Length;

        /*try
        {
            //行数のカウント
            string[] lines = File.ReadAllLines("Assets/VRShooting/enemySpawn.csv");
            length = lines.Length;
            values = new string[length][];
            // csvファイルを開く
            using (var sr = new System.IO.StreamReader("Assets/VRShooting/enemySpawn.csv"))
            {

                // ストリームの末尾まで繰り返す
                int i = 0;
                while (!sr.EndOfStream)
                {
                    // ファイルから一行読み込む
                    var line = sr.ReadLine();
                    // 読み込んだ一行をカンマ毎に分けて配列に格納する
                    values[i] = line.Split(',');
                    // 出力する
                    //Debug.Log(values[i]);
                    Debug.Log("OK");
                    foreach (var value in values[i])
                    {
                        Debug.Log(value);
                    }
                    i++;
                }
            }
        }
        catch (System.Exception e)
        {
            // ファイルを開くのに失敗したとき
            Debug.Log(e.Message);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        /*敵のスポーン
            敵の動作についてはSphereScript
            4秒置きに出てくる
        */
        /* int r;
         int s;
         float interval = 3.0f;

         r = rnd.Next(40, 50);
         s = rnd.Next(0, 359);

         if(ScoreManager.Instance.Score < 500)
         {
             interval = 4.0f;
         }
         else if (ScoreManager.Instance.Score < 1000)
         {
             interval = 3.5f;
         }
         else if (ScoreManager.Instance.Score < 2000)
         {
             interval = 3.0f;
         }
         else if (ScoreManager.Instance.Score < 5000)
         {
             interval = 2.5f;
         }
         else if (ScoreManager.Instance.Score < 10000)
         {
             interval = 2.0f;
         }
         else
         {
             interval = 1.8f;
         }

         enemyIntervalTime += Time.deltaTime;
         if (enemyIntervalTime >= interval)
         {
             enemyIntervalTime = 0;
             // Instantiate(Enemy, new Vector3(Player.transform.position.x + rnd.Next(490, 500)*directionX, Player.transform.position.y + rnd.Next(5, 20), Player.transform.position.z + rnd.Next(490, 500)*directionZ), Quaternion.identity);
             //Instantiate(Enemy, new Vector3(Player.transform.position.x + rnd.Next(20, 50) * directionX, Player.transform.position.y + rnd.Next(5, 20), Player.transform.position.z + rnd.Next(20, 50) * directionZ), Quaternion.identity);
             GameObject enemy = Instantiate(Enemy, new Vector3(Player.transform.position.x + r * Mathf.Cos(s), Player.transform.position.y + rnd.Next(5, 30), Player.transform.position.z + r * Mathf.Sin(s)), Quaternion.identity) as GameObject;
             //EnemyScript e = enemy.GetComponent<EnemyScript>();
             //e.setMove(2);
         }*/

        time += Time.deltaTime;
    
        if (phase < length && time >= values[phase][0])
        {
            Debug.Log(phase);
            GameObject enemy = Instantiate(Enemy, new Vector3(values[phase][1], values[phase][2], values[phase][3]), Quaternion.identity) as GameObject;
            EnemyScript e = enemy.GetComponent<EnemyScript>();
            e.setMove((int)values[phase][4]);
            phase++;
        }
    }
}
