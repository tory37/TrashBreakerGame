using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMachineController : MonoBehaviour
{
    #region Properties
    [SerializeField] private float maxRotationSpeed;
    [SerializeField] private float thrust;
    
    #endregion

    #region Variables
    float rotationSpeed = 0;
    Rigidbody m_Rigidbody;
    GameObject ballToLaunch;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        SpawnBall();
    }

    void SpawnBall()
    {
        ballToLaunch = GameObject.Instantiate(GameplayManager.GetDisplayBallPrefab(), transform);
        ballToLaunch.transform.SetPositionAndRotation(transform.position + (transform.forward * -25), transform.rotation);
    }

    void LaunchBall()
    {
        Vector3 position = ballToLaunch.transform.position;
        Quaternion rotation = ballToLaunch.transform.rotation;
        GameObject.Destroy(ballToLaunch);
        GameObject instantiatedBall = GameObject.Instantiate(GameplayManager.GetGameBallPrefab(), GameplayManager.GetBallContainer());
        instantiatedBall.GetComponent<Rigidbody>().MovePosition(position);
        instantiatedBall.GetComponent<Rigidbody>().MoveRotation(rotation);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }

        if (Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotationSpeed = Input.GetAxis("Engine") * maxRotationSpeed;

        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotationSpeed);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);

    }
}
