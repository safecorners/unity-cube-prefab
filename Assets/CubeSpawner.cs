using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    private  List<GameObject> cubes;
    private List<GameObject> cubesToRemove;
    public float scalingFactor = 0.95f;
    private int numberOfCubes = 0;

    // Start is called before the first frame update
    void Start()
    {
        cubes = new List<GameObject>();
        cubesToRemove = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CreateCube();
        UpdateCubes();
        RemoveCubes();
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(cubePrefab);
        cube.name = "Cube" + numberOfCubes++;
        RandomizeColor(cube);
        RandomizeLocation(cube);
        cubes.Add(cube);
    }

    private void RandomizeColor(GameObject cube)
    {
        Color color = new Color(Random.value, Random.value, Random.value, 1.0f);
        cube.GetComponent<Renderer>().material.color = color;
    }

    private void RandomizeLocation(GameObject cube)
    {
        cube.transform.position = Random.insideUnitSphere;
    }

    private void UpdateCubes()
    {
        foreach (GameObject cube in cubes)
        {
            UpdateCube(cube);
        }
    }

    private void UpdateCube(GameObject cube)
    {
        float scale = cube.transform.localScale.x;
        scale *= scalingFactor;
        cube.transform.localScale = Vector3.one * scale;

        if (scale <= 0.1f)
        {
            cubesToRemove.Add(cube);
        }
    }

    private void RemoveCubes()
    {
        foreach (GameObject cube in cubesToRemove)
        {
            cubes.Remove(cube);
            Destroy(cube);
        }
    }
}
