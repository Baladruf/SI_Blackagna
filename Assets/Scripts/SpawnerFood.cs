using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFood : MonoBehaviour {

    public static SpawnerFood instance;
    public class FoodPos
    {
        public Vector3 position;
        public Food food;

        public FoodPos(Vector3 p)
        {
            position = p;
            food = null;
        }
    }

    [SerializeField] Transform[] posSpawn;
    private List<FoodPos> freePlace, foodAlive;

    [SerializeField] float delaySpawn = 5;
    private float timerSpawn;
    [SerializeField] GameObject prefabFood;

    private void Awake()
    {
        instance = this;
        freePlace = new List<FoodPos>();
        foodAlive = new List<FoodPos>();
        for(int i = 0; i < posSpawn.Length; i++)
        {
            freePlace.Add(new FoodPos(posSpawn[i].position));
        }
        timerSpawn = delaySpawn;
    }

    // Update is called once per frame
    void Update () {
		if(freePlace.Count > 0)
        {
            timerSpawn = delaySpawn;
            int nbRandom = Random.Range(0, freePlace.Count);
            var gFood = Instantiate(prefabFood, freePlace[nbRandom].position, Quaternion.identity);
            var scriptFood = freePlace[nbRandom];
            freePlace.Remove(scriptFood);
            scriptFood.food = gFood.GetComponent<Food>();
            foodAlive.Add(scriptFood);
        }
        timerSpawn = Mathf.Max(0, timerSpawn - Time.deltaTime);
	}

    public void BackToTheList(FoodPos foodPos)
    {
        foodAlive.Remove(foodPos);
        foodPos.food = null;
        freePlace.Add(foodPos);
    }
}
