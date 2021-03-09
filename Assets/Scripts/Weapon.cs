using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float throwForce = 10f;
    public GameObject throwObjectPrefab;
    Camera FPSCamera;

    // Start is called before the first frame update
    void Start()
    {
        FPSCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Throw();
        }
    }

    private void Throw() 
    {
        GameObject apple = Instantiate(throwObjectPrefab, transform.position, Quaternion.identity);
        Vector3 throwAngle = FPSCamera.transform.forward;
        throwAngle.y += 0.6f;
        throwAngle = throwAngle.normalized;
     

        apple.GetComponent<Rigidbody>().AddForce(throwAngle * throwForce, ForceMode.Impulse);
    }

}

