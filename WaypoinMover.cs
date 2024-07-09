using UnityEngine;

public class WaypoinMover : MonoBehaviour
{
    private Transform[] _places;
    private Transform _storage;
    private float _speed;
    private int _quantityOfPlace;

    private void Start()
    {
        _places = new Transform[_storage.childCount];

        for (int i = 0; i < _places.Length; i++)
            _places[i] = _storage.GetChild(i);
    }

    private void Update()
    {
        Transform pointByNumberInArray = _places[_quantityOfPlace];

        transform.position = Vector3.MoveTowards(transform.position, pointByNumberInArray.position, _speed * Time.deltaTime);

        if (transform.position == _places[_quantityOfPlace].position)
            GoToNextDestination();
    }

    private void GoToNextDestination()
    {
        _quantityOfPlace = _quantityOfPlace++ % _places.Length;

        transform.forward = _places[_quantityOfPlace].transform.position - transform.position;
    }
}
