using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public int playerIndex;
    public TMP_Text tmpText;

    private void Start()
    {
        tmpText.text = "0";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ballComponent = collision.GetComponent<Ball>();
        if (ballComponent != null)
        {
            ballComponent.ResetBall();
            GameManager.instance.points[playerIndex]++;
            tmpText.text = GameManager.instance.points[playerIndex].ToString();
        }
    }
}
