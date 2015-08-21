using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed = 1.0f;

	public int hitPoint = 10;

	public GameObject bom;

	void Start () {
	
	}

	void Update () {
		InRegion ();
	}


	void InRegion ()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		Vector2 pos = transform.position;

		
		pos.x = Mathf.Clamp (pos.x, min.x + 0.1f, max.x - 0.1f);
		pos.y = Mathf.Clamp (pos.y, min.y - 10.0f, max.y + 1.0f);
		
		transform.position = pos;
	}

	public void Bom ()
	{
		Instantiate (bom, transform.position, transform.rotation);
	}


	void OnTriggerEnter2D (Collider2D c)
	{
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		if (layerName == "Bullet") {
			Destroy (c.gameObject);
			hitPoint--;
			if(hitPoint < 0){
				Destroy (gameObject);
				Bom();
			}
			GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f,1.0f);
		}
	}
}
