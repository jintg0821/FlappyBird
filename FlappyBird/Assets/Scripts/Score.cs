using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int score = 0;
    public static int bestScore = 0;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}
