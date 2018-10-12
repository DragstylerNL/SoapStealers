using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private Text text;

    private int score = 0;

    void Start()
    {
        text = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }

    public void AddScore(int add)
    {
        score += add;
        text.text = "Score: " + score;
    }

    public void Die()
    {
        GameObject.FindGameObjectWithTag("Death").GetComponent<RectTransform>().position = new Vector3(960, 540, 0);
    }
}
