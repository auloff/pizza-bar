using PizzaBar.Core;
using System.Collections.Generic;
using UnityEngine;

namespace PizzaBar.Conveyor
{
    public class RadiusPoint : MonoBehaviour, IConveyorPoint
    {
        [SerializeField]
        private Transform _centerPoint = null;
        [SerializeField]
        private float _startAngle = 0f, _stopAngle = 0f, _speed = 0.1f;

        public Vector2 EndPoint { get; set; }

        private Dictionary<IPizza, float> _pizzaAngle;
        private float _newPosX, _newPosY, _newRotZ, _radius;
        private Vector2 _newRotation;

        void Start()
        {
            _pizzaAngle = new Dictionary<IPizza, float>();
            _radius = Vector2.Distance(this.transform.position, _centerPoint.position);
            EndPoint = this.transform.position;
        }

        public void MovePizza(IPizza pizza)
        {
            if (!_pizzaAngle.ContainsKey(pizza))
                _pizzaAngle.Add(pizza, _startAngle);

            float currentAngle = _pizzaAngle[pizza];
            _newPosX = _centerPoint.position.x + Mathf.Cos(currentAngle* Mathf.Deg2Rad) * _radius;
            _newPosY = _centerPoint.position.y + Mathf.Sin(currentAngle* Mathf.Deg2Rad) * _radius;
            pizza.PizzaObj.transform.position = new Vector2(_newPosX, _newPosY);

            LookAtCenter(pizza.PizzaObj.transform);

            if (currentAngle >= _stopAngle)
            {
                pizza.PizzaObj.transform.position = this.transform.position;
                _pizzaAngle.Remove(pizza);
            }
            else
            {
                _pizzaAngle[pizza] = currentAngle + _speed * Time.deltaTime;
            }
        }

        private void LookAtCenter(Transform objectToRotate)
        {
            _newRotation = _centerPoint.position - objectToRotate.position;
            _newRotation.Normalize();

            _newRotZ = Mathf.Atan2(_newRotation.y, _newRotation.x) * Mathf.Rad2Deg;
            objectToRotate.rotation = Quaternion.Euler(0f, 0f, _newRotZ - 90);
        }
    }
}