using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rolldice : MonoBehaviour
{
    public GameObject die;
    public Rigidbody rb;

    public float Number;

    public string textNumber;

    public TMP_Text tm;

    //Used to determine when the die has stopped moving
    float speed;
    float realX;
    float realZ;
    float rotX;
    float rotZ;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        textNumber = "Nothing";
    }

    // Update is called once per frame
    void Update()
    {
        //determines the die's speed
        speed = rb.velocity.magnitude;

        //Determines the Die's current rotational position to calculate what number has been rolled
        realX = Mathf.Round(transform.localEulerAngles.x);
        realZ = Mathf.Round(transform.localEulerAngles.z);

        rotX = Mathf.Round(realX / 90);
        rotZ = Mathf.Round(realZ / 90);

        if(rotX == 4){
            rotX = 0;
        }
        if (rotZ == 4){
            rotZ = 0;
        }

        if (Input.GetKeyDown("space"))
        {
            die.transform.position = new Vector3(0, 25, 3); //Moves the die up
            Vector3 dieRotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)); //Creates a Vector3 with random rotations
            die.transform.eulerAngles = dieRotation; //Applies the above Vector3 to the Die
            rb.velocity = new Vector3(Random.Range(-25,25), -10 , Random.Range(-25, 25));//Gives the Die random velocities on the X and Z axis
        }

        //If the Die isn't moving
        if (speed < 0.5)
        {

            Rolled();
        }



    }

    public void Rolled()
    {
        if (rotX == 1)
        {
            Debug.Log("3");
            Number = 3;
        }
        if(rotX == 3)
        {
            Debug.Log("4");
            Number = 4;
        }
        //if()


        textNumber = Number.ToString();
        tm.text = textNumber;

    }
               
}
