using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_ship : MonoBehaviour
{
    public GameObject monster;
    public static int score = 0;
    public static int health = 5; //5 default (very hard mode) // 10  semi hard // 15 easy
    private static bool isSpedUp = false;
    private static bool isSlowed = false;
    // Start is called before the first frame update

    void Start()
    {
        score = 0;
        health = 5; //5 default (very hard mode)
        isSpedUp = false;
        isSlowed = false;
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
            if (isSlowed)
            {
                this.transform.Translate(Vector3.forward * Time.deltaTime * 10);
            }
            else
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
        if(isSpedUp)
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * 300f);
        }
        if (isSlowed)
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * 10);
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
       
        if (collision.gameObject.tag == "speedBoost")
        {
            //add speed to the object for 5 seconds
            StartCoroutine(speedPickup());
            
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "slowBoost")
        {
            //slow object's speed here for 1 second
            StartCoroutine(slowPickUp());

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "spawnEnemeyBoost")
        {
            //spawns an enemy immediately close to the ship

            float x = collision.transform.position.x;
            float y = collision.transform.position.y;
            float z = collision.transform.position.z;
            StartCoroutine(spawnMonster(new Vector3(x, 4f, z)));
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "portalBoost")
        {
            int x = Random.Range(-4800, 4800);
            int z = Random.Range(-4800, 4800);
            transform.position = new Vector3(x, 0, z);
            Destroy(collision.gameObject);
            //teleports the ship
        }
        if (collision.gameObject.tag == "healthBoost")
        {
            health += 3;
            Destroy(collision.gameObject);
            //this boost increases health with 3 points
        }
    }
    public IEnumerator spawnMonster(Vector3 vec)
    {
        yield return new WaitForSeconds(2f);
        GameObject obj = (Instantiate(monster, vec, transform.rotation));
        obj.tag = "monster";
        obj.SetActive(true);
        obj.transform.LookAt(transform);
    }
    public IEnumerator speedPickup()
    {
        isSpedUp = true;
        isSlowed = false;
        yield return new WaitForSeconds(5f);
        isSpedUp = false;
    }
    public IEnumerator slowPickUp()
    {
        isSlowed = true;
        isSpedUp = false;
        yield return new WaitForSeconds(2f);
        isSlowed = false;
    }
}
