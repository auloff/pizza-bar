using PizzaBar.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaBar.Conveyor
{
    public class SimpleConveyor : MonoBehaviour
    {
        public string tagToSearch;
        public GameObject points;

        private List<IConveyorPoint> _conveyorPoints;
        private List<IPizza> _pizzas;

        void Awake()
        {
            _conveyorPoints = new List<IConveyorPoint>();
            _pizzas = new List<IPizza>();
        }

        void Start()
        {
            foreach (Transform item in points.transform)
            {
                if(item.tag == tagToSearch)
                {
                    IConveyorPoint temp = item.GetComponent<IConveyorPoint>();
                    if (temp != null)
                    {
                        _conveyorPoints.Add(temp);
                    }
                }
            }
        }

        void Update()
        {
            foreach(var pizza in _pizzas)
            {
                if (pizza.currentMove < 0 || pizza.currentMove > _conveyorPoints.Count - 1)
                    pizza.currentMove = 0;

                _conveyorPoints[pizza.currentMove].MovePizza(pizza);

                if (_conveyorPoints[pizza.currentMove].EndPoint == (Vector2)pizza.PizzaObj.transform.position)
                    pizza.currentMove++;
            }
        }

        public void AddPizza(IPizza pizza)
        {
            _pizzas.Add(pizza);
        }

        public void RemovePizza(IPizza pizza)
        {
            _pizzas.Remove(pizza);
        }
    }
}
