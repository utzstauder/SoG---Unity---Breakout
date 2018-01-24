using UnityEngine;

public class Ball : MonoBehaviour {

    [Range(1.0f, 20.0f)]
    public float speed = 1.0f;

    [Range(0, 8.0f)]
    public float deviateAmount = 3.0f;


    Rigidbody2D myRigidbody2D;      // ball
    Rigidbody2D otherRigidbody2D;   // racket / player rigidbody; DEPRECATED

    GameObject player;

    bool readyToShoot = true;


    private void Awake()
    {
        // find Rigidbody2D reference
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        // find player object
        player = GameObject.FindGameObjectWithTag("Player");

        // start game
        // TODO: handle externally
        // readyToShoot = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (readyToShoot)
        {
            // check if we have a reference to the player object
            if (player != null)
            {
                transform.position = player.transform.position + Vector3.up * 0.3f;
            }

            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) {
                Launch();
                readyToShoot = false;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        myRigidbody2D.velocity = Vector2.zero;
        readyToShoot = true;
        */

        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // collision with player / racket
            float deviateFactor;

            deviateFactor = transform.position.x - collision.gameObject.transform.position.x;
            //Debug.LogFormat("deviateFactor: {0}", deviateFactor);

            deviateFactor /= collision.collider.bounds.size.x / 2.0f;
            //Debug.LogFormat("normalized deviateFactor: {0}", deviateFactor);
            //Debug.LogFormat("colliderWidth: {0}", collision.collider.bounds.size.x);

            Vector2 direction = myRigidbody2D.velocity + Vector2.right * deviateFactor * deviateAmount;
            direction.Normalize();

            myRigidbody2D.velocity = direction * speed;

            // Debug.LogFormat("v.magnitude: {0}", myRigidbody2D.velocity.magnitude);
        }
    }

    void Launch()
    {
        myRigidbody2D.velocity = Vector2.up * speed;
    }


    public void SetDirection(Vector2 direction)
    {
        // don't stick to racket
        readyToShoot = false;

        // set velocity
        myRigidbody2D.velocity = direction.normalized * speed;
    }
}
