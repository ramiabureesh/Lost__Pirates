using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_destroy : MonoBehaviour
{
    
    private bool detectedBefore = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (detectedBefore)
            return;
        if (collision.gameObject.tag == "cannonball")
        {
            //collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            //gameObject.SetActive(false);
            Destroy(gameObject);
            if(move_ship.score < 20)
                move_ship.score += 1;
            if (move_ship.score == 20)
            {
                GameOVer.GameOver();
            }
            detectedBefore = true;
        }
    }
}
