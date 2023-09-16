using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
        [SerializeField] float moveSpeed = 10f;
    float SpeedY = 0;
    float gravity = -9.81f;
    public Camera Mycamera;
    private Vector3 moveDirection;
    private float kunci = 0;
    private Animator anim;
    private CharacterController controller;
    private Rigidbody rig;
    private AudioSource audi;
    bool IsMoving = false;

    //[SerializeField] float kunci = 0;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        audi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        audioplan();

    }
    public void move()
    {
        float xValue = Input.GetAxis("Horizontal"); //* Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical"); //* Time.deltaTime * moveSpeed;
        if (!controller.isGrounded)
        {
            SpeedY += gravity * Time.deltaTime;
        }
        else
        {
            SpeedY = 0;
        }
        Vector3 movement = new Vector3(xValue, 0, zValue);
        Vector3 verticalmove = Vector3.up * SpeedY;
        Vector3 rotatedMovement = Quaternion.Euler(0, Mycamera.transform.rotation.eulerAngles.y, 0) * movement;
        controller.Move((verticalmove + rotatedMovement * moveSpeed) * Time.deltaTime);
        if (rotatedMovement.magnitude > 0)
        {

            anim.SetFloat("speed", 1, 0.1f, Time.deltaTime);

        }
        else
        {
            anim.SetFloat("speed", 0, 0.1f, Time.deltaTime);

        }
    }

    void audioplan()
    {
        if (rig.velocity.x != 0)
            IsMoving = true;

        else
            IsMoving = false;

        if (rig.velocity.z != 0)
            IsMoving = true;
        else
            IsMoving = false;
        if (IsMoving)
        {
            if (!audi.isPlaying)
                audi.Play();
        }
        else
            audi.Stop();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy")
        {
            canvasKontrol.ck.GameOver();
            this.enabled = false;
            Time.timeScale = 0;
            Debug.Log("kena");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

        }

        if (other.gameObject.tag == "Finish")
        {

            canvasKontrol.ck.Selesai();
            this.enabled = false;
            Time.timeScale = 0;
            Debug.Log("finish");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            /*if(other.gameObject.tag == "kunci")
            {
                kunci += 1;
                Destroy(other.gameObject);
                audi.Play();
                Debug.Log("total  " + kunci);

            }*/





            // }
            // else{   
            //canvasKontrol.ck.kasihtau();
            //  Debug.Log (" you need " + (5 - kunci) + " kunci left to escape");
            // }
        }
    }

    /*private void OnCollisionExit(Collision col)
    {
        if(col.gameObject.tag == "Finish")
        {
            canvasKontrol.ck.kasihtu();
            Debug.Log("muncul");
        }
    }
    /*void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Finish")
        Debug.Log("bye");
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.transform.tag == "home"){
            if(TotalSabun >= 10) 
            {
                canvasKontrol.ck.Selesai();
                this.enabled = false;
            }*/

}
