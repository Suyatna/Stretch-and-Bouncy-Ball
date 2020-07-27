using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour {

    bool inside;
    Transform magnet;
    float radius = 5f;
    float force = 100f;

    // Use this for initialization
    void Start() {
        magnet = GameObject.Find("Magnet").GetComponent<Transform>();
        inside = false;

    }

    // Update is called once per frame
    void Update() {
        if (inside)
        {
            Vector3 magnetField = magnet.position - transform.position;
            float index = (radius - magnetField.magnitude) / radius;
            AddForce(force * magnetField * index);
        }
    }

    private void AddForce(Vector3 vector3)
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Magnet")
        {
            inside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Magnet")
        {
            inside = false;
        }
    }
}
