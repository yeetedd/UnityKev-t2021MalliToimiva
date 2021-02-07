using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Security.Cryptography;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    //Hiiren nopeus
    public float mouseSensitivity = 100f;

    //automaattisesti kääntää bodyä kun hiirtä käytetään
    public Transform playerBody;

    //miten paljon on kääntynyt x-akselin suhteen
    private float xRotation = 0f;

    float mouseX;
    float mouseY;
    float minXAngle = -90f;
    float minYAngle = 90f;

    // Start is called before the first frame update
    void Start()
    {
        //asettaa kursorin oikeaan kohtaan näyttöä
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {

        //kääntää hiirtä
        //delta time laskee kuinka kauna yhteen ruutuun menee
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;  //ylos ja alas katsominen
        xRotation = Mathf.Clamp(xRotation, minXAngle, minYAngle);  //kaantaa kameraa ja estaa ylikaantymisen

        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        transform.localRotation = Quaternion.Euler(xRotation, rotationInEuler.y, 0f); //asettaa hiiren sijaintiin

        transform.Rotate(Vector3.up * mouseX);  //vasemmalle ja oikeille

    }
}
