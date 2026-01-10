using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    public void OnEnable()
    {
        GetComponent<TextMeshProUGUI>().text = "Best Score: " + Score.bestScore;
    }
}
