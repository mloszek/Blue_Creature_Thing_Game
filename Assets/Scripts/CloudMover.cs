using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour {

    public float speed;
    
    void FixedUpdate ()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "background")
        Destroy(gameObject);
    }
}
