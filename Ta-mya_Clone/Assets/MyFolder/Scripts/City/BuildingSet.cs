using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSet : MonoBehaviour
{
    Vector3 position = new Vector3(8, 0, 0);
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
       
        
        //newObj.transform.position = new Vector3(8, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Instantiate(obj, position, Quaternion.identity);
        }
    }
}
