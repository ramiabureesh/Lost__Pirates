using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_ship : MonoBehaviour
{
    [SerializeField] public GameObject ship;
    [SerializeField] public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(attack());
    }
    public IEnumerator attack()
    {
        while(true)
        { 
        transform.LookAt(ship.transform);
        Vector3 pos = transform.position;
        GameObject obj = (Instantiate(fire, new Vector3(pos.x, 4, pos.z), transform.rotation));
        obj.tag = "fire";
        obj.SetActive(true);
        Destroy(obj.gameObject, 10);
        yield return new WaitForSeconds(1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
     
    }
}
