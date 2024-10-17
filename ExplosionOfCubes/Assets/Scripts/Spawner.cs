using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static List<Cube> CreateCubes(int createCubesCount, Cube template) 
    {
        List<Cube> generatedCubes = new List<Cube>();

        for (int i = 0; i < createCubesCount; i++) 
        {
            Cube newCube = Instantiate(template);
            generatedCubes.Add(newCube);
        }

        return generatedCubes;
    }
}
