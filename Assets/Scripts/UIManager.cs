using PizzaBar.Persons;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UIManager : MonoBehaviour
{
    public string toFormat = "Coins: ";
    [SerializeField]
    private Client _client = null;

    private Text _text;
    private float _coins = 0;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    void Start()
    {
        if (_client != null) 
            _client.EndEating += Client_EndEating;

        _text.text = string.Concat(toFormat, _coins.ToString());
    }

    private void Client_EndEating(float obj)
    {
        _coins += obj;
        _text.text = string.Concat(toFormat, _coins.ToString());
    }
}
