using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_hit : MonoBehaviour
{
    public GameObject cannonBall;
    private Quaternion startpos;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject obj = Instantiate(cannonBall, new Vector3(transform.position.x, 4.3f, transform.position.z), gameObject.transform.rotation);
            obj.gameObject.GetComponent<Rigidbody>().AddForce((Quaternion.AngleAxis(-45, new Vector3(0, -45, 0)) * transform.forward) * 20000);
            Destroy(obj.gameObject, 5);
        }
    }
}
