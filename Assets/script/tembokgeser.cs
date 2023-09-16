using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tembokgeser : MonoBehaviour
{
    public GameObject door;
    public float maxopen = 10f;
    public float maxLoos = 0f;
    public float moveopen = 5f; 
    public float moveclose = 5f;
    bool playerIsHere;
    bool opening;
    private AudioSource audi;
    //[SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        audi = GetComponent<AudioSource>();
        playerIsHere = false;
        opening = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerIsHere)
        {
            if(door.transform.position.x < maxopen){
                door.transform.Translate(moveopen * Time.deltaTime, 0f, 0f);
                audi.Play();
            }
        }else{
            if(door.transform.position.x > maxLoos){
                door.transform.Translate(-moveclose * Time.deltaTime, 0f, 0f);
                audi.Play();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //anim.SetBool("door", true);
            playerIsHere = true;
            Debug.Log("open");
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           //anim.SetBool("door", false);
           playerIsHere = false;
           Debug.Log("close");
        } 
    }
}
