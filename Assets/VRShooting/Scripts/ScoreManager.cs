using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public int Score = 0;
    public int incremental = 100;

    public Text ScoreText;

    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (ScoreManager)FindObjectOfType(typeof(ScoreManager));
                if (instance == null)
                {
                    Debug.LogError("ScoreManager Instance Error");
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(GameObject.Find("ScoreCanvas"));
    }

    public void increment()
    {
        Score += incremental;
    }

    public void show()
    {
        ScoreText.text = "Score: " + Score.ToString();
    }

    public void update()
    {
        increment();
        show();
    }

    public void gameOver()
    {
        GameObject GameOverText;
        GameOverText = GameObject.Find("GameOverText");
        GameOverText.GetComponent<Text>().text = "Game Over\n" + "Score: " + Score.ToString();
    }
}

