using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persegi : MonoBehaviour {

    public Renderer rend;
    public BoxCollider2D box;
    public BoxCollider2D box2;
    private Vector3 HandleToOriginVector;
    public bool isDragging;

    public GameObject targetOne;
    public GameObject targetTwo;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        box = GetComponent<BoxCollider2D>();
        //rend.enabled = false;
        //box.enabled = false;
        //box2 = target.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rend.enabled = true;
        box.enabled = true;
        targetOne.SetActive(false);
        targetTwo.SetActive(true);
        //box2.enabled = true;
    }

    private void OnMouseDown()
    {
        if (rend.enabled == true) {
            HandleToOriginVector = transform.root.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
    }

    private void OnMouseDrag()
    {
        if (rend.enabled == true) {
            transform.root.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + HandleToOriginVector;
        }
    }

    private void OnMouseUp()
    {
        isDragging = true;
    }
}
