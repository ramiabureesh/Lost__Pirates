using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_hit2 : MonoBehaviour
{
    public GameObject cannonBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //GameObject obj = Instantiate(cannonBall, transform.position, Quaternion.identity);
            GameObject obj = Instantiate(cannonBall, new Vector3(transform.position.x, 4.3f, transform.position.z), gameObject.transform.rotation);
            obj.gameObject.GetComponent<Rigidbody>().AddForce((Quaternion.AngleAxis(45, new Vector3(0, -45, 0)) * transform.forward) * -20000);
            Destroy(obj.gameObject, 5);
        }
    }
}
