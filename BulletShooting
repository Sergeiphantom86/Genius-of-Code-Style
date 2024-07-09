using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BulletShooting : MonoBehaviour
{
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private float _boost;
    [SerializeField] private float _delay;

    private Transform _target;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = true;
        WaitForSeconds delay = new(_delay);

        while (isWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Rigidbody newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();

            newBullet.transform.up = direction;
            bulletRigidbody.velocity = direction * _boost;

            yield return delay;
        }
    }
}
