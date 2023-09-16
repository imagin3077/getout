using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    float rotationOnX;
    float mouseSensitifity = 400f;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
       // Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime*mouseSensitifity;
        float m_X = Input.GetAxis("Mouse X") * Time.deltaTime*mouseSensitifity;
        rotationOnX -= mouseY;
        rotationOnX = Mathf.Clamp(rotationOnX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationOnX, 0f, 0f);

        player.Rotate(Vector3.up * m_X);
    }

}
