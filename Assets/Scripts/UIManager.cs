using PizzaBar.Persons;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UIManager : MonoBehaviour
{
    public string toFormat = "Coins: ";
    [SerializeField]
    private Client[] _clients = null;

    private Text _text;
    private float _coins = 0;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    void Start()
    {
        foreach (var client in _clients)
        {
            client.EndEating += Client_EndEating;
        }
        _text.text = string.Concat(toFormat, _coins.ToString());
    }

    private void Client_EndEating(float obj)
    {
        _coins += obj;
        _text.text = string.Concat(toFormat, _coins.ToString());
    }
}
