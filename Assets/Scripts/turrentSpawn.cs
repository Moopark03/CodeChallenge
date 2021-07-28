using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrentSpawn : MonoBehaviour
{
    [SerializeField] GameObject go_Turret; //Turret prefab to create
    private Camera cam;
    private int rayLength = 300;
    private Ray ray;
    private RaycastHit hit;
    private GameObject hitObject;

    void Start()
    {
        cam = GetComponent<Camera>();
        hit = new RaycastHit();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, rayLength);
            hitObject = hit.transform.gameObject;

            if(hitObject.CompareTag("Turret"))
            {
                Destroy(hitObject);
            }
            else if(hitObject.CompareTag("playBoard")) //This allows turrets to be placed in a specific area
            {
                Vector3 spawnPoint = getClickPoint(); //spawnPoint gets the ground location to place the turret on
                if (spawnPoint != Vector3.zero)
                {
                    Vector3 screenSpawn = new Vector3(spawnPoint.x, spawnPoint.y + 120, spawnPoint.z); //drop from outside the camera
                    Instantiate(go_Turret, screenSpawn, go_Turret.transform.rotation);
                }
            }
        }
    }

    private Vector3 getClickPoint()
    {
        Vector3 pos_normal = new Vector3(0f, 0f, 0f);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            pos_normal = hit.point;
        }

        return pos_normal;
    }
}
