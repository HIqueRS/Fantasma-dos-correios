using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    private GameObject[] _prefabLayout;

    private void Start()
    {
        _prefabLayout = new GameObject[3];

        _prefabLayout[0] = Resources.Load<GameObject>("Layout_Models/Model_1");
        _prefabLayout[1] = Resources.Load<GameObject>("Layout_Models/Model_2");
        _prefabLayout[2] = Resources.Load<GameObject>("Layout_Models/Model_3");
    }

    private int RandomizeLayout()
    {
        return Random.Range(0, 3);
    }

    public GameObject InstantiateLayout(Vector3 colliderPosition)
    {
        Vector3 layoutPosition;

        layoutPosition.x = 0;
        layoutPosition.y = colliderPosition.y - 20;
        layoutPosition.z = 0;

        return GameObject.Instantiate(_prefabLayout[RandomizeLayout()], layoutPosition, Quaternion.identity);
    }
}
