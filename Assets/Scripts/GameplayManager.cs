using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    static GameplayManager instance;

    [SerializeField] private Transform ballContainer;
    [SerializeField] private GameObject gameBallPrefab;
    [SerializeField] private GameObject displayBallPrefab;
    [SerializeField] private float baseBallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    static GameplayManager GetInstance ()
    {
        return instance;
    }

    static public Transform GetBallContainer()
    {
        return instance.ballContainer;
    }

    static public GameObject GetGameBallPrefab()
    {
        return instance.gameBallPrefab;
    }

    static public GameObject GetDisplayBallPrefab()
    {
        return instance.displayBallPrefab;
    }

    static public float getBallSpeed()
    {
        return instance.baseBallSpeed;
    }

}
