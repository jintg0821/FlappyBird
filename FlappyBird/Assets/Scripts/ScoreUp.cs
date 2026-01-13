using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BirdJump player = collision.GetComponent<BirdJump>();
        if (player.isDie) return;
        Score.score++;
    }
}
