using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    float maxVelocity = 300f;
    float minVelocity = -50f;
    public float shipVelocity = 0f;
    Rigidbody rb;
    // Use this for initialization

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * shipVelocity;
        switch (m_input.Mode)
        {
            case Ship.Light:
                LightShipMovement();
                break;

            case Ship.Medium:
                MediumShipMovement();
                break;

            case Ship.Heavy:
                HeavyShipMovement();
                break;

        }
    }

   

    [SerializeField, Tooltip("ShipClass options.")]
    private InputSettings m_input = new InputSettings
    {
        Mode = Ship.Light
    };

    [Serializable]
    private struct InputSettings
    {
        [Tooltip("Choose ship class.")] public Ship Mode;  
    }




    public enum Ship
    {
        Light,
        Medium,
        Heavy
    }

    private void LightShipMovement()
    {
        float lightAcceleration = 100f;
        float lightTurnRate = 40f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (shipVelocity < maxVelocity)
                shipVelocity += lightAcceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (shipVelocity > minVelocity)
                shipVelocity -= lightAcceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(lightTurnRate * Time.deltaTime * (-1), 0, 0), Space.Self);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(new Vector3(lightTurnRate * Time.deltaTime, 0, 0), Space.Self);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, (-2) * lightTurnRate * Time.deltaTime, 2 * lightTurnRate * Time.deltaTime), Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 2 * lightTurnRate * Time.deltaTime, (-2) * lightTurnRate * Time.deltaTime), Space.Self);
        }
    }

    private void MediumShipMovement()
    {
        float mediumAcceleration = 40f;
        float mediumTurnRate = 20f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (shipVelocity < maxVelocity)
                shipVelocity += mediumAcceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (shipVelocity > minVelocity)
                shipVelocity -= mediumAcceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(mediumTurnRate * Time.deltaTime * (-1), 0, 0), Space.Self);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(new Vector3(mediumTurnRate * Time.deltaTime, 0, 0), Space.Self);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, 0, 2 * mediumTurnRate * Time.deltaTime), Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, (-2) * mediumTurnRate * Time.deltaTime), Space.Self);
        }
    }

    private void HeavyShipMovement()
    {
        float HeavyAcceleration = 40f;
        float HeavyTurnRate = 5f;
        float HeavyTwistRate = 2f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (shipVelocity < maxVelocity)
                shipVelocity += HeavyAcceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (shipVelocity > minVelocity)
                shipVelocity -= HeavyAcceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(HeavyTurnRate * Time.deltaTime * (-1), 0, 0), Space.Self);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(new Vector3(HeavyTurnRate * Time.deltaTime, 0, 0), Space.Self);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, (-2) * HeavyTurnRate * Time.deltaTime, 0), Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 2 * HeavyTurnRate * Time.deltaTime, 0), Space.Self);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, 0, HeavyTwistRate * Time.deltaTime), Space.Self);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 0, (-1) * HeavyTwistRate * Time.deltaTime), Space.Self);
        }
    }
}