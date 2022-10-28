using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShip : MonoBehaviour
{
    [SerializeField] private Vector3[] CreatePos;
    [SerializeField] private GameObject[] CreateShips;
    private int[] Num = new int[4];

    void Awake()
    {
        for (int i = 0; i < SelectShip.SelectShipNum.Length; i++)
        {
            Num[i] = int.Parse(SelectShip.SelectShipNum[i]);
            Debug.Log(i+"”Ô–Ú‚Ìƒf[ƒ^:"+SelectShip.SelectShipNum[i]);
        }

        for (int i = 0; i < 2; i++)
        {
            Instantiate(CreateShips[Num[i]], CreatePos[i], Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
