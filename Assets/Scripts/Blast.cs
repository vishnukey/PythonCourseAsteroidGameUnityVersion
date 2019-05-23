using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour {
        public float speed;
	
	// Update is called once per frame
	void Update () {
                transform.position += transform.up * speed * Time.deltaTime;
	}

        private void OnCollisionEnter2D(Collision2D collision) {
                if (!collision.gameObject.CompareTag("Player")) Destroy(this.gameObject);
        }
}
