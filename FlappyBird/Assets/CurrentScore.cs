using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentScore : MonoBehaviour
{
    public void OnEnable()
    {
        GetComponent<TextMeshProUGUI>().text = "Current Score: " + Score.score.ToString();
    }
}
