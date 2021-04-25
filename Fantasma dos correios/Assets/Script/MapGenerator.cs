using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    [SerializeField] private GameObject[] _prefabLayout;

    private int RandomizeLayout()
    {
        return Random.Range(0, 3);
    }

    public void InstantiateLayout(Vector3 colliderPosition)
    {
        Vector3 layoutPosition;

        layoutPosition.x = 0;
        layoutPosition.y = colliderPosition.y + 30;
        layoutPosition.z = 0;

        GameObject.Instantiate(_prefabLayout[RandomizeLayout()], layoutPosition, Quaternion.identity);
    }
}
