using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReferenceTest : MonoBehaviour {

	public float moveSpeed = 10;
	//public float jumpSpeed = 8.0f;
	public float turnSpeed = 60;
	public float gravity = 20.0f;
	private Vector3 moveDir = Vector3.zero;

	public GameObject Psword, EngD;

	public Slider healthBar;

	private int gold,silver;
	private int ammo;
	private int health;
	public Text goldCount;
	public Text silverCount;
	public Text ammoCount;
	bool sword = true;
	bool gun = false;
	bool running = false;

	public Transform shooter;
	public Rigidbody bullet;
	float bulSpeed = 40.0f;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();
		health = 100;
		ammo = 6;
        gold = 0;
		silver = 0;
		//healthBar.value = 50;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController> ();

		if (controller.isGrounded) {
			moveDir = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDir = transform.TransformDirection (moveDir);
			moveDir *= moveSpeed;
            //float ver = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
            //transform.Translate (0, 0, ver);

            //if (Input.GetButton ("Jump")) {
            //	moveDir.y = jumpSpeed;
            //}
        }

		if (Input.GetKey("up") || Input.GetKey("right") || Input.GetKey("left") || Input.GetKey("down") || Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s"))
        {
            anim.SetTrigger("Move");
			running = true;
        }
        else
        {
            anim.SetTrigger("stop");
			running = false;
        }

        if(Input.GetKeyDown("mouse 1"))
        {
            anim.SetTrigger("Change");
			if(sword == true) 
			{
				sword = false;
				//GameObject.FindWithTag("Sword").SetActive(false);
				Psword.gameObject.SetActive (false);
				gun = true;
				//GameObject.FindWithTag("Gun").SetActive(true);
				EngD.gameObject.SetActive (true);
			} 
			else if(gun == true) 
			{
				gun = false;
				//GameObject.FindWithTag("Gun").SetActive(false);
				EngD.gameObject.SetActive (false);
				sword = true;
				//GameObject.FindWithTag("Sword").SetActive(true);
				Psword.gameObject.SetActive (true);
			}
        }

		if (Input.GetKeyDown("mouse 0"))
        {
			if (running == false) 
			{
				if (sword == true) 
				{
					anim.SetTrigger ("attack");
				} 
				else if (gun == true && ammo != 0) 
				{
					anim.SetTrigger ("Shoot");
					ammo -= 1;
					UpdateAmmo ();
					Rigidbody instantiatedProjectile = Instantiate(bullet, shooter.position, shooter.rotation) as Rigidbody;
					instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, bulSpeed));

				}
			}
        }

        float hor = Input.GetAxis ("Horizontal") * turnSpeed * Time.deltaTime;
		transform.Rotate (0, hor, 0);

		moveDir.y -= gravity * Time.deltaTime;
		controller.Move(moveDir * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Doubloon")) {
			other.gameObject.SetActive (false);
			gold += 1;
			UpdateGold ();
		}

		if (other.gameObject.CompareTag ("Piece")) {
			other.gameObject.SetActive (false);
			silver += 1;
			UpdateSilver ();
		}


		if (other.gameObject.CompareTag ("CanonShot")) {
			Destroy (other.gameObject);
			healthBar.value -= 10;
		}
	}

	void UpdateGold(){
		goldCount.text = "" + gold;
	}

	void UpdateSilver(){
		silverCount.text = "" + silver;
	}

	void UpdateAmmo(){
		ammoCount.text = "" + ammo;
	}
}
