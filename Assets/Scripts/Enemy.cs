using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
        public float speed;
        public float fieldSize;
        public float minTurn;
        public float maxTurn;
        public AudioSource destroyfx;

        public UIManager ui;

        // Update is called once per frame
        void Update() {
                int turnDirection = Random.Range(-1, 2);
                Debug.Log(turnDirection);
                float turnAmount = Random.Range(minTurn, maxTurn);
                transform.Rotate(transform.forward * turnAmount * turnDirection  * Time.deltaTime);
                transform.position += transform.up * speed * Time.deltaTime;
        }

        private void OnCollisionEnter2D(Collision2D collision) {
                if (collision.gameObject.CompareTag("Blast")) {
                        destroyfx.Play();
                        ui.playerScore++;
                        transform.position = Random.insideUnitCircle * fieldSize;
                }

                if (collision.gameObject.CompareTag("Boundary"))
                        transform.Rotate(Vector3.forward * 180);
        }
}
