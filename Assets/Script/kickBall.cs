using UnityEngine;
using UnityEngine.SceneManagement;

public class kickBall : MonoBehaviour
{
    private object rigidbody2d;

    public Rigidbody2D rb;

    public Vector2 direction;

    public Vector3 mMouseDownPos;
    public Vector3 mMouseUpPos;
    public Vector3 mousePosFar;
    public Vector3 mousePosF;

    public float Bouncbillity = 1.1f;
    public float r;
    public float timeLeft;

    public bool mulai = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;

            //Menghitung garis singgung
            r = Mathf.Sqrt(Mathf.Abs(x * x) + Mathf.Abs(y * y));

            mousePosFar = new Vector3(x, y, Camera.main.farClipPlane);
            mousePosFar.z = 0;

            mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
            Debug.Log(mousePosF.ToString());
        }
    }

    void OnMouseDown()
    {
        mMouseDownPos = Input.mousePosition;
        mMouseDownPos.z = 0;
        Debug.Log(Input.mousePosition);
    }

    void OnMouseUp()
    {
        mMouseUpPos = Input.mousePosition;
        mMouseUpPos.z = 0;

        var direction = mMouseDownPos - mMouseUpPos;
        if (r >= 3)
        {
            rb.AddForce(direction * 10);
        }
    }
    
    void OnMouseDrag()
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 positionF = Camera.main.ScreenToWorldPoint(position);
        Debug.Log(positionF.ToString());
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = rb.velocity / Bouncbillity;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Berhasil!");
        gameObject.SetActive(false);
    }
}