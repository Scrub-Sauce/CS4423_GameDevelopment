using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Config")]
    public float pauseTime = 1.5f;
    public float diminishingFactor = 0.99f;
    int selector;


    [Header("Prefabs")]
    public GameObject coinPrefab;
    public GameObject superCoinPrefab;
    public GameObject sHStopperPrefab;
    public GameObject sVStopperPrefab;
    public GameObject mHStopperPrefab;
    public GameObject mVStopperPrefab;
    public GameObject lHStopperPrefab;
    public GameObject lVStopperPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjectsRoutine());
    }

    IEnumerator SpawnObjectsRoutine(){
        while(true){
            Vector3 randomSpawnPos = new Vector3(Random.Range(-5f, 5f), 6, 0);
            GameObject newObject;
            switch (Random.Range(0, 8))
            {
                case 0:
                    newObject = Instantiate(coinPrefab,randomSpawnPos,Quaternion.identity);
                    break;
                case 1:
                     newObject = Instantiate(superCoinPrefab,randomSpawnPos,Quaternion.identity);
                    break;
                case 2:
                     newObject = Instantiate(sHStopperPrefab,randomSpawnPos,Quaternion.identity);
                    break;
                case 3:
                     newObject = Instantiate(sVStopperPrefab,randomSpawnPos,Quaternion.identity);
                    break;
                case 4:
                     newObject = Instantiate(mHStopperPrefab,randomSpawnPos,Quaternion.identity);
                    break;
                case 5:
                     newObject = Instantiate(mVStopperPrefab,randomSpawnPos,Quaternion.identity);
                    break;
                case 6:
                     newObject = Instantiate(lHStopperPrefab,randomSpawnPos,Quaternion.identity);
                    break;
                case 7:
                     newObject = Instantiate(lVStopperPrefab,randomSpawnPos,Quaternion.identity);
                    break;
                default:
                    Debug.Log("Error: Instantiation outside of acceptable range.");
                    break;
            }
            yield return new WaitForSeconds(pauseTime);
            pauseTime = diminishingFactor * pauseTime;
        }
    }
}
