using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentScore : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + Score.score.ToString();
    }

    void Update()
    {
        
    }
}
