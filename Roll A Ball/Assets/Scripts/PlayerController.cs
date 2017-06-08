using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    
    public float speed;
	public Text winText;
	public Text countText;

    private Rigidbody rb;
	private int count;
	private string win;
    
    // First frame
    void Start () {
        rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
    }
    
	// Input every frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        
        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
        
        rb.AddForce(movement*speed);
	}

	// Eats points
	void OnTriggerEnter(Collider other) {
		// Destroy (other.gameObject);
		if (other.gameObject.CompareTag ("Collect")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText () {
		countText.text = "Count: " + count.ToString ();
		if (count >= 7) {
			winText.text = "You win!";
		}
	}
}
