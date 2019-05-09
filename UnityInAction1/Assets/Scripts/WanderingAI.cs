using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 5f;
    [SerializeField] private float obstacleRange = 3f;
    [SerializeField] private GameObject fireBallPrefab;
    private GameObject fireBall;
    private bool alive;

    private void Start()
    {
        alive = true;
    }

    private void Update()
    {
        if (alive)
        {
            transform.Translate(0, 0, enemySpeed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 1f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (fireBall == null)
                    {
                        fireBall = Instantiate(fireBallPrefab) as GameObject;
                        fireBall.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        fireBall.transform.rotation = transform.rotation;
                    }
                }
                else if ((hit.distance < obstacleRange) && (hitObject.tag != "FireBall"))
                {
                    float angle = Random.Range(-120, 120);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool life)
    {
        alive = life;
    }
}
