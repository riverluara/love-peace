using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private float shipVelocity;
    private float currentHealthPoints;
    public ShipMovement shipMovement;
    public HealthPoints healthPoints;
    [SerializeField] private float lightShipDeceleration = 50.0f;
    [SerializeField] private float mediumShipDeceleration = 30.0f;
    [SerializeField] private float heavyShipDeceleration = 10.0f;

    [SerializeField] private float lightShipDemage = 30.0f;
    [SerializeField] private float mediumShipDemage = 20.0f;
    [SerializeField] private float heavyShipDemage = 10.0f;

  
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        shipVelocity = shipMovement.shipVelocity;
        currentHealthPoints = healthPoints.healthPoints;
    }
    public void ShipDeceleration(Collider ship)
    {
        shipMovement.FreezeRotation();
        if(ship.tag == "Light"){
            shipVelocity -= lightShipDeceleration;
        }
        else if(ship.tag == "Medium")
        {
            shipVelocity -= mediumShipDeceleration;
        }
        else if(ship.tag == "Heavy")
        {
            shipVelocity -= heavyShipDeceleration;
        }
        ChangeShipVelocity();
    }
    void ChangeShipVelocity()
    {
        
            shipMovement.ChangeVelocity(shipVelocity);

    }

    public void ShipDemage(Collider ship)
    {
        if (ship.tag == "Light")
        {
            currentHealthPoints -= lightShipDemage;
        }
        else if (ship.tag == "Medium")
        {
            currentHealthPoints -= mediumShipDemage;
        }
        else if (ship.tag == "Heavy")
        {
            currentHealthPoints -= heavyShipDemage;
        }
        ChangeHealthPoints(currentHealthPoints);
    }

   void ChangeHealthPoints(float shipHealth)
    {
        healthPoints.CurrentHealthPoints(shipHealth);
    }
}
