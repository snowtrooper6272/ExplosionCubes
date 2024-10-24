using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube), typeof(Rigidbody))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private Ray ray;
    private Rigidbody _rigidbody;

    public float ExplosionForce => _explosionForce;
    public float ExplosionRadius => _explosionRadius;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void ExplodeNewCubes(Cube[] repelledCubes) 
    {
        foreach (Cube cube in repelledCubes) 
        {
            Vector3 directionRepelled = (transform.position - cube.transform.position).normalized;
            cube.GetComponent<Rigidbody>().AddForce(directionRepelled * _explosionForce);
        }
    }

    public void Explode() 
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (var hit in hits) 
        {
            if(hit.gameObject.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    public void Init(float explosionForce, float explosionRadius)
    {
        _explosionForce = explosionForce;
        _explosionRadius = explosionRadius;
    }
}
