using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector;
    [SerializeField] float period;

    private float movementFactor;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update () {
        movementFactor =
            (Mathf.Sin(Time.timeSinceLevelLoad / period) + 1f) / 2f;
        Vector3 translation = movementFactor * movementVector;
        transform.position = startPos + translation;

	}
}
