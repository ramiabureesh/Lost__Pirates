using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_ship : MonoBehaviour
{
    public GameObject monster;
    public static int score = 0;
    public static int health = 5;
    // Start is called before the first frame update
    
    void Start()
    {
        score = 0;
        StartCoroutine(Spawner());
    }
    public IEnumerator Spawner()
    {
        
        while (true)
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
            float leftright = Random.Range(1, 3);
            if(leftright == 1)
            {
                GameObject obj = (Instantiate(monster, new Vector3(x + 100, 4f, z), transform.rotation));
                obj.tag = "monster";
                obj.SetActive(true);
                obj.transform.LookAt(transform);
            }
            else
            {
                GameObject obj =  Instantiate(monster, new Vector3(x - 100, 4f, z), transform.rotation);
                obj.tag = "monster";
                obj.SetActive(true);
                obj.transform.LookAt(transform);
            }
            yield return new WaitForSeconds(2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            GameOVer.GameOver();
        if (Time.timeScale == 0)
            return;
        this.transform.Translate(Vector3.forward * Time.deltaTime * 50f);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime *100f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.back * Time.deltaTime * 100f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(Vector3.up, -1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(Vector3.up, 1);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "monster")
        {
            //collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
           
            if (move_ship.score < 20)
                move_ship.score += 1;
            if (move_ship.score == 20)
            {
                GameOVer.GameOver();
            }
        }
       
        if(collision.gameObject.tag == "border")
        {
            GameOVer.GameOver();
        }
        
    }
}
