using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class update_score : MonoBehaviour
{
    // Start is called before the first frame update
    UnityEngine.UI.Text score;
    void Start()
    {
        score = GetComponent< UnityEngine.UI.Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + move_ship.score;
    }
}
