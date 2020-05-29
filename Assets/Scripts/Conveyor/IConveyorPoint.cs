using PizzaBar.Core;
using UnityEngine;

namespace PizzaBar.Conveyor
{
    public interface IConveyorPoint
    {
        Vector2 EndPoint { get; set; }
        void MovePizza(IPizza pizza);
    }
}