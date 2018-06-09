using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatBlock : MonoBehaviour {

    [SerializeField] float movement;
    [SerializeField] float period;
    [SerializeField] float phase;

    private Vector3 Pos;

    private void Start()
    {
        Pos = transform.position;
    }
    void Update () {
        float time = Time.timeSinceLevelLoad;
        float factor = Mathf.Sin(time / period + phase*Mathf.PI);

        transform.position = Pos + Vector3.up * movement * factor;
	}
}
