using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    [SerializeField] int minNbFood = 5, maxNbFood = 15;
    private int nbFood;
    private Collider colliderFood;
    public SpawnerFood.FoodPos spFood;

    private void Awake()
    {
        nbFood = Random.Range(minNbFood, maxNbFood + 1);
        colliderFood = GetComponent<Collider>();
    }

    public void Eat()
    {
        nbFood--;
        if(nbFood <= 0)
        {
            colliderFood.enabled = false;
            SpawnerFood.instance.BackToTheList(this);
            print("food finish");
            //Destroy(gameObject);
        }
    }
}
