using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_score : MonoBehaviour
{
    UnityEngine.UI.Text score;
    void Start()
    {
        score = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Health: " + move_ship.health;
        if (move_ship.health <= 0)
            score.text = "Health: 0";
    }
}
