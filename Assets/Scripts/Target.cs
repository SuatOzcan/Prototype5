using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]
    private int _ForceMin = 13;
    [SerializeField]
    private int _ForceMax = 16;
    private float _torqMax = 10;
    private float _xRange = 4;
    private float _ySpawn = -6;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(),
            ForceMode.Impulse);

        transform.position = RandomSpawnPosition();
    }

    private Vector3 RandomTorque()
    {
        return new Vector3( RandomTorqValue(), RandomTorqValue(), RandomTorqValue());
    }

    private float RandomTorqValue()
    {
        return Random.Range(-_torqMax, _torqMax);
    }

    private Vector3 RandomForce()
    {
        return Random.Range(_ForceMin, _ForceMax) * Vector3.up;
    }

    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _ySpawn, 0);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
