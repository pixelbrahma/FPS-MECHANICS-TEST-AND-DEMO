using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private float enemySpeed = 5f;
    private const float baseSpeed = 7f;
    private static float exSpeed = 0;
    [SerializeField] private float obstacleRange = 3f;
    [SerializeField] private GameObject fireBallPrefab;
    private GameObject fireBall;
    private bool alive;

    private void Awake()
    {
        if (exSpeed == 0)
        {
            enemySpeed = baseSpeed;
        }
        else
        {
            enemySpeed = exSpeed;
        }
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    private void Start()
    {
        alive = true;
    }

    private void Update()
    {
        if (alive)
        {
            transform.Translate(0, 0, enemySpeed * Time.deltaTime);
            Debug.Log(enemySpeed);
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

    private void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
    }

    public void SetAlive(bool life)
    {
        alive = life;
    }

    private void OnSpeedChanged(float value)
    {
        enemySpeed = baseSpeed * value;
        exSpeed = enemySpeed;
    }
}
