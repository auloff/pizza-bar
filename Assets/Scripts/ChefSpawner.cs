using PizzaBar.Conveyor;
using PizzaBar.Core;
using UnityEngine;

namespace PizzaBar.Persons
{
    public class ChefSpawner : MonoBehaviour
    {
        public Transform spawnPoint;
        public SimpleConveyor conveyor;

        public GameObject pizzaPrefab;

        public int firstPoint = 0;
        public float delay = 10f;

        private float _nextSpawnTime = 0.0f;

        void Update()
        {
            if (pizzaPrefab == null || conveyor == null)
            {
                Debug.LogWarning("Nothing to spawn!");
                return;
            }

            if (Time.time > _nextSpawnTime)
            {
                GameObject pizzaObj = Instantiate(pizzaPrefab, spawnPoint.position, pizzaPrefab.transform.rotation);
                IPizza pizza = pizzaObj.GetComponent<IPizza>();
                pizza.currentMove = firstPoint;
                conveyor.AddPizza(pizza);
                _nextSpawnTime += delay;
            }
        }
    }
}