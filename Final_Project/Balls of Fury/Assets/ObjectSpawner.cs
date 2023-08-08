using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject boxPrefab;
    public GameObject ballCoinPrefab;   

    List<float> positions = new List<float> {-8.44f, -7.50f, -6.56f, -5.63f, -4.69f, -3.75f, -2.81f, -1.88f, -0.94f, 0.0f, 0.94f, 1.88f, 2.81f, 3.75f, 4.69f, 5.63f, 6.56f, 7.5f, 8.44f};
    int maxBoxes = 19;

    public void NextLevel()
    {
        int boxCount = Random.Range(1, maxBoxes-1);
        int randomIndex;
        float positionSelection;

        List<float> availablePositions = new List<float>(positions);
        GameObject newObject;  // Declare newObject here

        for (int i = 0; i < boxCount && availablePositions.Count > 0; i++)
        {
            randomIndex = Random.Range(0, availablePositions.Count);
            positionSelection = availablePositions[randomIndex];
            newObject = Instantiate(boxPrefab, new Vector3(positionSelection, 3.66f, 0), Quaternion.identity);
            availablePositions.RemoveAt(randomIndex);
        }

        randomIndex = Random.Range(0, availablePositions.Count);
        positionSelection = availablePositions[randomIndex];
        newObject = Instantiate(ballCoinPrefab, new Vector3(positionSelection, 3.66f, 0), Quaternion.identity);
        availablePositions.RemoveAt(randomIndex);
    }
}