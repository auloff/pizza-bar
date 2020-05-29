using UnityEngine;

namespace PizzaBar.Core
{
    public interface IPizza
    {
        GameObject PizzaObj { get; set; }
        float Price { get; set; }
        int currentMove { get; set; }
    }
}