using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenerTheCollector : MonoBehaviour
{
    [SerializeField]
    GameObject prefabPickup;
    List<GameObject> pickups = new List<GameObject>();

    public GameObject TargetPickup
    {
        get
        {
            if (pickups.Count > 0)
            {
                return pickups[0];
            }
            else
            {
                return null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // calculate world position of mouse click
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // create pickup and add to list
            GameObject pickup = Instantiate<GameObject>(prefabPickup);
            pickup.transform.position = worldPosition;
            pickups.Add(pickup);
        }
    }

    public void RemovePickup(GameObject pickup)
    {
        pickups.Remove(pickup);
        Destroy(pickup);
    }
}
