using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_fire : MonoBehaviour
{
    [SerializeField] public GameObject ship;
    public Vector3 tar;
    //public void init_tar()
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, ship.transform.position, Time.deltaTime * 100f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ship")
        {
            move_ship.health -= 1;
        }
    }



}
