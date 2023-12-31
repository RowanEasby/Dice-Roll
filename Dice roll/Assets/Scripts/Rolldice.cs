using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class Rolldice : MonoBehaviour
{
    //Declarations
    public GameObject die;
    public Rigidbody rb;

    public ParticleSystem particle;

    string Number;

    public TMP_Text tm;

    //Used to determine when the die has stopped moving
    float speed;
    float realX;
    float realZ;
    float rotX;
    float rotZ;


    public CinemachineVirtualCamera LookCam;
    public CinemachineVirtualCamera TopCam;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        FollowCam();
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
            
            FollowCam();
        }

        //If the Die isn't moving
        if (speed < 0.05)
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

        if (speed < 0.05)
        {
            OverheadCam();
        }
    }

    public void OverheadCam()
    {
        TopCam.gameObject.SetActive(true);
        LookCam.gameObject.SetActive(false);
    }

    public void FollowCam()
    {
        LookCam.gameObject.SetActive(true);
        TopCam.gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {

    //Plays particles when the die hit's the floor
        particle.Play(true);
    }

    private void OnCollisionExit(Collision collision)
    {
    //Turns of the particles when the die leaves the floor
        particle.Play(false);
    }
}
