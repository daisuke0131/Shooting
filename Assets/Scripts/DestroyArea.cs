using UnityEngine;
using System.Collections;

public class DestroyArea : MonoBehaviour {


	public int trigger = 10;
	public GameObject enemy;
	private int triggerTmp;

	// Use this for initialization
	void Start () {
		triggerTmp = trigger;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit2D (Collider2D c)
	{
		string layerName = LayerMask.LayerToName(c.gameObject.layer);
		if (layerName == "Star") {
			Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
			c.transform.position = new Vector2 (c.transform.position.x, max.y);
			trigger --;
			if(trigger < 0){
				Instantiate(enemy,c.transform.position, c.transform.rotation);
				trigger = triggerTmp;
			}

		} else if (layerName == "Enemy") {
			print ("removed");
			c.gameObject.GetComponent<Enemy> ().Bom ();
			Destroy (c.gameObject);
		} else {
			Destroy (c.gameObject);
		}

	}
}
