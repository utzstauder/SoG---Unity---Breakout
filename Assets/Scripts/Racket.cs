using UnityEngine;

public class Racket : MonoBehaviour {

    // value types: int, float, bool, etc...
    public float speed = 0.05f;   // movement speed
    float h; // horizontal input
    Vector3 mouseWorldPos;

    // reference types: GameObject, Transform, Rigidbody2D, etc...
    Rigidbody2D myRigidbody2D; // = null;


	// Use this for initialization
	void Start () {
        // Debug.LogFormat("Hello, world! I am {0}.", gameObject.name);

        myRigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        h = Input.GetAxis("Horizontal"); // -1 <= h <= 1

        //transform.position += Vector3.right * speed * Time.deltaTime;

        //Debug.LogFormat("FPS: {0} | dT: {1}", 1f/Time.deltaTime, Time.deltaTime);

        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Debug.LogFormat("MouseWorldPos: {0}", mouseWorldPos);

        // update x-position
        transform.position = new Vector3(
            mouseWorldPos.x,
            transform.position.y,
            transform.position.z);

        /* alternative
        Vector3 newPosition = transform.position;
        newPosition.x = mouseWorldPos.x;
        transform.position = newPosition;
        */
        // transform.position.x = mouseWorldPos.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // get PowerUp component reference
        PowerUp script = collision.gameObject.GetComponent<PowerUp>();

        if (script != null)
        {
            // we found a reference, execute trigger
            script.Trigger();
        }
    }


}
