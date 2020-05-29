using PizzaBar.Conveyor;
using PizzaBar.Core;
using System;
using System.Collections;
using UnityEngine;

namespace PizzaBar.Persons
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class Client : MonoBehaviour
    {
        public float pizzaMoveDelay;
        public SimpleConveyor conveyor;
        public Transform arm;

        [Min(0)]
        public float eatingDelay;

        public event Action<float> EndEating;

        private bool _isEating = false, _needMove = false;
        private IPizza _eatingPizza;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isEating) return;

            _eatingPizza = collision.transform.GetComponent<IPizza>();
            if (_eatingPizza == null) return;

            _isEating = true;
            _needMove = true;
            conveyor?.RemovePizza(_eatingPizza);

        }

        private void Update()
        {
            if (!_needMove) return;

            if (_eatingPizza.PizzaObj.transform.position != arm.position)
            {
                _eatingPizza.PizzaObj.transform.position = Vector3.Lerp(_eatingPizza.PizzaObj.transform.position, arm.position, pizzaMoveDelay* Time.deltaTime);
            }
            else
            {
                _needMove = false;
                StartCoroutine(StartEatingPizza());
            }
        }

        private IEnumerator StartEatingPizza()
        {
            yield return new WaitForSeconds(eatingDelay);

            EndEating?.Invoke(_eatingPizza.Price);

            Destroy(_eatingPizza.PizzaObj);
            _eatingPizza = null;
            _isEating = false;
        }
    }
}