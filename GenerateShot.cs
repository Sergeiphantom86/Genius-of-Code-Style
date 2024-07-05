using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class GenerateShot : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _position;

    [SerializeField] private float _boost;
    [SerializeField] private float _delay;

    private void Start()
    {
        StartCoroutine(ReleaseEvenly());
    }

    private void Create()
    {
        GameObject newBullet = Instantiate(_prefab, transform.position + GetPosition(), Quaternion.identity);

        SetDirectionMovement(newBullet);
    }

    private Vector3 GetPosition()
    {
        return (_position.position - transform.position).normalized;
    }

    private void SetDirectionMovement(GameObject newBullet)
    {
        newBullet.transform.up = GetPosition();

        if (TryGetComponent(out Rigidbody _))
        {
            newBullet.GetComponent<Rigidbody>().velocity = GetPosition() * _boost;
        }
    }

    private IEnumerator ReleaseEvenly()
    {
        bool isWork = true;
        float delay = _delay;
        
        while (isWork)
        {
            Create();

            yield return new WaitForSeconds(delay);
        }
    }
}
