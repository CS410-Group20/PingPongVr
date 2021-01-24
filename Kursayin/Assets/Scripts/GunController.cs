using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private Transform _target;
    [SerializeField] private float forceWeight;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            Rigidbody ball = Instantiate(_ball, _target.position, Quaternion.identity).GetComponent<Rigidbody>();
            ball.velocity = _target.forward.normalized * forceWeight;
            yield return new WaitForSeconds(2);
        }
    }
}
