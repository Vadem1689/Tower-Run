using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreation;
    [SerializeField] private Tower _towerTemplate;
    [SerializeField] private int _humanTowerCount;

    private void Start()
    {
        GenerateLevel1();
    }

    private void GenerateLevel1()
    {
        float roadLengh = _pathCreation.path.length;
        float distanceBetweenTower = roadLengh / _humanTowerCount;

        float distanceTrabelled = 0f;
        Vector3 spawnPoint;

        for (int i = 0; i < _humanTowerCount; i++)
        {
            distanceTrabelled += distanceBetweenTower;
            spawnPoint = _pathCreation.path.GetPointAtDistance(distanceTrabelled, EndOfPathInstruction.Stop);

            Instantiate(_towerTemplate, spawnPoint, Quaternion.identity);
        }
    }
}
