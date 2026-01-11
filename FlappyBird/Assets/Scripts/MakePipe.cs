using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePipe : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject currentObstacle;
    public float timeDiff;
    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeDiff)
        {
            if (Score.score >= 300)
            {
                currentObstacle = obstacles[1];
            }
            else
            {
                currentObstacle = obstacles[0];
            }
            GameObject newPipe = Instantiate(currentObstacle);
            newPipe.transform.position = new Vector3(6, Random.Range(-2.3f, 4.5f), 0);
            timer = 0;
            Destroy(newPipe, 10);
        }
    }
}
