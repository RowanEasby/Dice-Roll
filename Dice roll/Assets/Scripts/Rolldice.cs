using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolldice : MonoBehaviour
{
    public GameObject die;
    public Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            die.transform.position = new Vector3(0, 25, 3);
            Vector3 dieRotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            die.transform.eulerAngles = dieRotation;
            rb.velocity = new Vector3(Random.Range(-1,1), -10, Random.Range(-1, 1));
        }
    }
}
