using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkersSpawnerController : MonoBehaviour
{
    public GameObject workerPrefab;

    public GameObject SpawnWorker()
    {
        GameObject worker = Instantiate(workerPrefab);
        worker.transform.position = transform.position;
        worker.transform.rotation = Quaternion.Euler(Random.Range(-60, 60), Random.Range(-60, 60), Random.Range(-60, 60));
        return worker;
    }
}
