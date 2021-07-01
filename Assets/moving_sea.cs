using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_sea : MonoBehaviour
{
    [SerializeField] public GameObject boost;
    void Start()
    {
        StartCoroutine(spawnBoosts());
    }
    void Update()
    {

    }
    public IEnumerator spawnBoosts()
    {
        while(true)
        {
            int x = Random.Range(-1800, 1800);
            int z = Random.Range(-1800, 1800);
            GameObject obj = (Instantiate(boost, new Vector3(x, 4, z), Quaternion.identity));
            obj.SetActive(true);
            int r = Random.Range(0, 5);
            if(r == 0)
            {
                obj.tag = "speedBoost";
                //add speed to the object for 5 seconds
            }
            if(r == 1)
            {
                obj.tag = "slowBoost";
                //slow object's speed here for 2 second
            }
            if(r == 2)
            {
                obj.tag = "spawnEnemeyBoost"; //spawns an enemy immediately close to the ship
            }
            if(r == 3)
            {
                obj.tag = "portalBoost"; //teleports the ship
            }
            if (r == 4)
            {
                obj.tag = "healthBoost"; //adds health to the ship
            }
            //
            //
            yield return new WaitForSeconds(2f);
        }
    }
}
