using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
        public float speed;
        public float turnSpeed;
        public float acceleration;
        public float fieldSize;
        public AudioSource blastfx;

        public Blast blast;
        
        // Update is called once per frame
        void Update(){
                if (Input.GetKey("w"))
                        speed += acceleration * Time.deltaTime;
                if (Input.GetKey("s"))
                        speed -= acceleration * Time.deltaTime;
                if (Input.GetKey("a"))
                        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
                if (Input.GetKey("d"))
                        transform.Rotate(Vector3.forward * -turnSpeed * Time.deltaTime);

                if (Input.GetKeyDown(KeyCode.Space)){
                        Instantiate(blast, transform.position, transform.rotation);
                        blastfx.Play();
                }

                transform.position += transform.up * speed * Time.deltaTime;
        }

        private void OnCollisionEnter2D(Collision2D collision){
                if (collision.gameObject.CompareTag("Enemy"))
                        transform.position = Random.insideUnitCircle * fieldSize;

                if (collision.gameObject.CompareTag("Boundary"))
                        transform.Rotate(Vector3.forward * 180);
        }
}
