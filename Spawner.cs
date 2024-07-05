using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _storage;

    private Transform[] _places;
    private int _quantityOfPlace;

    private void Start()
    {
        for (int i = 0; i < _storage.childCount; i++)
        {
            _places[i] = _storage.GetChild(i).transform;
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _places[_quantityOfPlace].position, _speed);

        if (transform.position == _places[_quantityOfPlace].position)
        {
            AddNewLocation();
        }
    }

    private void AddNewLocation()
    {
        _quantityOfPlace++;

        if (_quantityOfPlace == _places.Length)
        {
            _quantityOfPlace = 0;
        }

        transform.forward = _places[_quantityOfPlace].transform.position - transform.position;
    }
}
