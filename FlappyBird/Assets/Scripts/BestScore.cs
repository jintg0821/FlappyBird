using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Best Score: " + Score.bestScore;
    }
}
