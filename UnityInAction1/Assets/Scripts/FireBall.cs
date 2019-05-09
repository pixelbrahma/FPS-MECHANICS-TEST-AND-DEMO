using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private int damage = 1;

    private void Start()
    {
        transform.position += new Vector3(0, 0.25f, 0);
    }

    private void Update()
    {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        if(player!=null)
        {
            player.Hurt(damage);
        }
        Destroy(this.gameObject);
    }
}
