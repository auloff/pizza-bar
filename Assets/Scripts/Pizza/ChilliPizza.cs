using UnityEngine;

namespace PizzaBar.Core
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class ChilliPizza : MonoBehaviour, IPizza
    {
        public GameObject PizzaObj { get; set; }

        [SerializeField]
        private float _price;
        public float Price { get => _price; set => _price = value; }

        public int currentMove { get; set; }

        void Awake()
        {
            PizzaObj = this.gameObject;
        }
    }
}