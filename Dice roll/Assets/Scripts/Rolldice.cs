using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Rolldice : MonoBehaviour
{
    public GameObject die;
    public Rigidbody rb;

    public string Number;

    public TMP_Text tm;

    public bool started;

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

        started = false;
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

        Debug.Log(started);

        if (Input.GetKeyDown("space"))
        {

            started = true;

            die.transform.position = new Vector3(0, 25, 3); //Moves the die up
            Vector3 dieRotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)); //Creates a Vector3 with random rotations
            die.transform.eulerAngles = dieRotation; //Applies the above Vector3 to the Die
            rb.velocity = new Vector3(Random.Range(-25,25), -10 , Random.Range(-25, 25));//Gives the Die random velocities on the X and Z axis
        }

        //If the Die isn't moving
        if ((speed < 0.1) && (started = true))
        {

            Rolled();
        }



    }

    public void Rolled()
    {
        //1
        if ((rotX == 0) && (rotZ == 1) || ((rotX == 2) && (rotZ == 3))){
            Number = "1";
        }
        //2
        if ((rotX == 0) && (rotZ == 2) || ((rotX == 2) && (rotZ == 0))){
            Number = "2";
        }
        //3
        if (rotX == 1){
            Number = "3";
        }
        //4
        if(rotX == 3){
            Number = "4";
        }
        //5
        if ((rotX == 0) && (rotZ == 0) || ((rotX == 2) && (rotZ == 2))){
            Number = "5";
        }
        //6
        if ((rotX == 0) && (rotZ == 3) || ((rotX == 2) && (rotZ == 1))){
            Number = "6";
        }

        tm.text = Number; //Changes the UI text to show the die roll result

    }
               
}
