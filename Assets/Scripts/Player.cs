//using UnityEngine;
//using System.Collections;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Player : MonoBehaviour {

	public float speed =  0.000001f;
	
	//bullet prefab
	public GameObject bullet;

	public GameObject bom;

	// Use this for initialization
	IEnumerator Start () {
		
		while (true) {
			Vector2 pos = new Vector2(transform.position.x,transform.position.y + 0.1f);

			Instantiate(bullet,pos, transform.rotation);
			yield return new WaitForSeconds(0.05f);
		}
	}
	
	// Update is called once per frame
	void Update () {
//		float x = Input.GetAxisRaw ("Horizontal");
//		float y = Input.GetAxisRaw ("Vertical"); 

		int touchCount = Input.touches.Count(t => t.phase != TouchPhase.Ended && t.phase != TouchPhase.Canceled);
		if (touchCount == 1) {
			Touch t = Input.touches.First ();
			switch (t.phase) {
			case TouchPhase.Moved:
				float x = Input.GetTouch (0).deltaPosition.x;
				float y = Input.GetTouch (0).deltaPosition.y;
				Vector2 direction = new Vector2 (x, 0.0f).normalized;
				Move (direction);
				break;
			}
		}	
		
	}

	public void Bom ()
	{
		Instantiate (bom, transform.position, transform.rotation);
	}


	void Move (Vector2 direction)
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		Vector2 pos = transform.position;

		pos += direction  * speed * Time.deltaTime;

		pos.x = Mathf.Clamp (pos.x, min.x + 0.1f, max.x - 0.1f);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		transform.position = pos;
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		if (layerName == "Enemy") {
			Destroy (gameObject);
			Bom ();
		}
	}

}
