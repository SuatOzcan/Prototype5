using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private GameManager _gameManagerScript;
    [SerializeField]
    private int _pointValue;

    [SerializeField]
    private ParticleSystem _explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(),
            ForceMode.Impulse);

        transform.position = RandomSpawnPosition();

        _gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
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

    private void OnMouseDown()
    {
        if (_gameManagerScript.isGameActive)
        {
            Destroy(gameObject);
            _gameManagerScript.UpdateScore(_pointValue);
            Instantiate(_explosionParticle, transform.position, _explosionParticle.transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sensor")
        Destroy(gameObject);

        if(gameObject.CompareTag("Good") && other.tag == "Sensor")
        {
            _gameManagerScript.GameOver();
        }
    }
}
