using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesGenerator : MonoBehaviour
{
    public GameObject cubePrefab;


    float[] minX = { -4f , -1f, 1f};
    float[] maxX = { -1f, 1f , 4f};

    float gap = 3f;
    float minY = 2f;
    float maxY = 3.5f;
    float minZ = -0.5f;
    float maxZ = -2;

    public int rowElementIndex = 0;

    public void ResetValues()
    {
        rowElementIndex = 0;
        minY = 2f;
        maxY = 3.5f;
    }

    public GameObject GenerateCube()
    {
        GameObject cube = Instantiate(cubePrefab);
        Vector3 newPos = new Vector3(Random.Range(minX[rowElementIndex], maxX[rowElementIndex]), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        cube.transform.position = newPos;
        cube.transform.rotation = Quaternion.Euler(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
        
        rowElementIndex++;
        if (rowElementIndex == 3)
        {
            rowElementIndex = 0;
            minY = maxY + gap;
            maxY = maxY + gap;
        }
        return cube;
    }

}
