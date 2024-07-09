using System.Collections;
using System.Collections.Generic;
using System;
using DefaultNamespace;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.

    public static List<GameObject> ballList = new List<GameObject>();
    public static ScoreManager scoreManager = new ScoreManager();

    public GameObject BasketBall;
    public GameObject FootBall;
    public GameObject BaseBall;

    public TextMeshPro timer;

    public int time = 100;

    // הקוד ידאג ליצר את הכדורים מהפרי פאב שביוניטי לפי זמנים ספציפים
    void Start()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        ballList.Add(Instantiate(BasketBall, new Vector3(0, 10, 0), Quaternion.identity));

        this.timer = GameObject.Find("TimerText").GetComponent<TextMeshPro>();
        timer.text = "Time left: " + time;
    }

    float timePassed = 0f;
    void Update()
    {
        if(time <= 0)
        {
            return;
        }

        timePassed += Time.deltaTime;
        if(timePassed > 1f)
        {
            //do something
            timePassed = 0f;
            timer.text = "Time left: " + time;
            time--;

            System.Random rnd = new System.Random();

            float x = rnd.Next(10) + 0.5f;
            float z = rnd.Next(10) + 0.5f;
            if (scoreManager.score > 70)
            {
                int rndNum = rnd.Next(10 + 1);

                if (rndNum > 7)
                {
                    ballList.Add(Instantiate(BaseBall, new Vector3(x, 10, z), Quaternion.identity));
                    return;
                }

                if (rndNum > 2)
                {
                    ballList.Add(Instantiate(FootBall, new Vector3(x, 10, z), Quaternion.identity));
                    return;
                }

                ballList.Add(Instantiate(BasketBall, new Vector3(x, 10, z), Quaternion.identity));
                return;
            }

            if (scoreManager.score > 30)
            {
                int rndNum = rnd.Next(10+1);

                if (rndNum > 7)
                {
                    ballList.Add(Instantiate(FootBall, new Vector3(x, 10, z), Quaternion.identity));
                    return;
                }
                ballList.Add(Instantiate(BasketBall, new Vector3(x, 10, z), Quaternion.identity));
                return;
            }
            ballList.Add(Instantiate(BasketBall, new Vector3(x, 10, z), Quaternion.identity));
        } 
    }
}