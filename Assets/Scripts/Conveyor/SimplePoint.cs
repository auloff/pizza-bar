using UnityEngine;
using PizzaBar.Core;

namespace PizzaBar.Conveyor
{
    public class SimplePoint : MonoBehaviour, IConveyorPoint
    {
        [SerializeField]
        private float speed = 0.1f;

        public Vector2 EndPoint { get; set; }

        void Awake()
        {
            EndPoint = this.transform.position;
        }

        public void MovePizza(IPizza pizza)
        {
            pizza.PizzaObj.transform.position = Vector2.MoveTowards(pizza.PizzaObj.transform.position, this.transform.position, speed * Time.deltaTime);
        }
    }
}
