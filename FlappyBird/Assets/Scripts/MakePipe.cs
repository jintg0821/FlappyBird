using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePipe : MonoBehaviour
{
    public GameObject[] obstacles;
    public float timeDiff;
    float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeDiff)
        {
            int randomNum = Random.Range(0, obstacles.Length);
            GameObject newPipe = Instantiate(obstacles[randomNum]);
            newPipe.transform.position = new Vector3(6, Random.Range(-2.3f, 4.5f), 0);
            timer = 0;
            Destroy(newPipe, 10);
        }
    }
}
