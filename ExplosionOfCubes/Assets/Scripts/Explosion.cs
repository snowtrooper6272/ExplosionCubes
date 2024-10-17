using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Cube))]
public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public float ExplosionForce => _explosionForce;
    public float ExplosionRadius => _explosionRadius;

    public void Explode(Cube[] repelledCubes) 
    {
        foreach (Cube cube in repelledCubes) 
        {
            Vector3 directionRepelled = (transform.position - cube.transform.position).normalized;
            cube.GetComponent<Rigidbody>().AddForce(directionRepelled * _explosionForce);
        }
    }

    public void Init(float explosionForce, float explosionRadius)
    {
        _explosionForce = explosionForce;
        _explosionRadius = explosionRadius;
    }
}
