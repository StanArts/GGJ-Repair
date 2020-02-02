using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public KeyCode right;
    public KeyCode left;
    public KeyCode up;
    public KeyCode down;

	public float moveSpeed;

    bool isMoving;

	public bool canMove;

	public Rigidbody2D myRigidbody;

	private Animator myAnim;

	public Vector3 respawnPosition;

	public LevelManager theLevelManager;

	public float knockbackForce;
	public float knockbackLength;
	private float knockbackCounter;

	public float invincibilityLength;
	private float invincibilityCounter;

	public AudioSource hurtSound;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();

		respawnPosition = transform.position;

		theLevelManager = FindObjectOfType<LevelManager>();

		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {

		if(knockbackCounter <= 0 && canMove)
		{
            if (Input.GetKey(left))
            {
                myRigidbody.velocity = new Vector2(-moveSpeed, myRigidbody.velocity.y);
                transform.localScale = new Vector2(1f, 1f);
            }
            else if (Input.GetKey(right))
            {
                myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
                transform.localScale = new Vector2(-1f, 1f);
            } else
            {
                myRigidbody.velocity = new Vector2(0, myRigidbody.velocity.y);
            }

            if (Input.GetKey(up))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, moveSpeed);
            }
            else if (Input.GetKey(down))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -moveSpeed);
            } else
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
            }
            
            if (Mathf.Abs(myRigidbody.velocity.x) > 0.1 || Mathf.Abs(myRigidbody.velocity.y) > 0.1)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }

		if(knockbackCounter > 0)
		{
			knockbackCounter -= Time.deltaTime;

			if(transform.localScale.x > 0)
			{
				myRigidbody.velocity = new Vector3(-knockbackForce, knockbackForce, 0f);
			} else {
				myRigidbody.velocity = new Vector3(knockbackForce, knockbackForce, 0f);
			}
		}

		if(invincibilityCounter > 0)
		{
			invincibilityCounter -= Time.deltaTime;
		}

		if(invincibilityCounter <= 0)
		{
			theLevelManager.invincible = false;
		}

        myAnim.SetBool("isMoving", isMoving);
	}

    public void Knockback()
	{
		knockbackCounter = knockbackLength;
		invincibilityCounter = invincibilityLength;
		theLevelManager.invincible = true;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Checkpoint")
		{
			respawnPosition = other.transform.position;
		}
	}
}
