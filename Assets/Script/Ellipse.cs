using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ellipse : MonoBehaviour {

    public Renderer rend;
    public BoxCollider2D box;
    private Vector3 HandleToOriginVector;
    public bool isDragging;
    public GameObject target;

    // Use this for initialization
    void Start () {
        //rend = GetComponent<Renderer>();
        //box = GetComponent<BoxCollider2D>();
        //target.GetComponent<Renderer>().enabled = false;
        //rend.enabled = false;
        //box.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //rend.enabled = true;
        //box.enabled = true;
        //target.SetActive(false);
        //box2.enabled = true;
    }

    private void OnMouseDown()
    {

            HandleToOriginVector = transform.root.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        
    }

    private void OnMouseDrag()
    {
       
            transform.root.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + HandleToOriginVector;
        
    }

    private void OnMouseUp()
    {
        isDragging = true;
    }
}
