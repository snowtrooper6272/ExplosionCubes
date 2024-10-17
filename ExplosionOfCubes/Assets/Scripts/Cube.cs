using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private int _ratioOfReductions;
    [SerializeField] private int _chanceNewGeneration;
    [SerializeField] private int _minCountChilds = 2;
    [SerializeField] private int _maxCountChilds = 6;
    [SerializeField] private Explosion _exception;
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private int _increaseStrengthNewGeneration;

    public event System.Action<int, int> CubePressed;

    private int _minChanceNewGeneration = 0;
    private int _maxChanceNewGeneration = 100;

    private void OnMouseDown()
    {
        if (_chanceNewGeneration >= Random.Range(_minChanceNewGeneration, _maxChanceNewGeneration + 1))
        {
            Cube[] generatedCubes = Spawner.CreateCubes(Random.Range(_minCountChilds, _maxCountChilds + 1), this).ToArray();

            InitNewGeneration(generatedCubes);
            _exception.Explode(generatedCubes);
        }

        Destroy(gameObject);
    }

    public void Init(Vector3 scale, int chanceNewGeneration, Color color) 
    {
        transform.localScale = scale;
        _chanceNewGeneration = chanceNewGeneration;
        _renderer.material.color = color;
    }

    private void InitNewGeneration(Cube[] generatedCubes)
    {
        foreach (Cube generatedCube in generatedCubes) 
        {
            generatedCube.Init(transform.localScale / _ratioOfReductions, _chanceNewGeneration / 2, new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
            generatedCube._exception.Init(_exception.ExplosionForce * _increaseStrengthNewGeneration, _exception.ExplosionRadius * _increaseStrengthNewGeneration);
        }
    }
}
