using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrow : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] float power;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rigidbody.AddForce(new Vector3(-power, 0, 0), ForceMode.Impulse);       //Right after the ball is spawned it is thrown into the character.
    }
}
