using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Rigidbody targetRb;

    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float maxTorque = 4;
    private float maxPosition = 4;
    private float yPosition = -6;

    private float rotationSpeed = 20;
    private bool isRotate = false;

    // Start is called before the first frame update
    void Start() {
        // transform.position = RandomPosition();
        // targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        if (targetRb.CompareTag("Meteor")) {
            targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        } else if (targetRb.CompareTag("Player")) {
            isRotate = true;
        }
    }

    // Update is called once per frame
    void Update() {
        if (isRotate) {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }

    private float RandomTorque() {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomForce() {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private Vector3 RandomPosition() {
        return new Vector3(Random.Range(-maxPosition, maxPosition), yPosition);
    }
}
