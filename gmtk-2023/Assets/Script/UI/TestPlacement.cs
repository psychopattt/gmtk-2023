using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlacement : MonoBehaviour
{
    [SerializeField] private EntityPlacer entityPlacer;
    [SerializeField] private GameObject entity;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject entityInstance = Instantiate(entity);
            entityPlacer.PlaceEntity(entityInstance.GetComponent<Entity>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
