using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    WanderingAI wanderingAI;

    private void Start()
    {
        wanderingAI = GetComponent<WanderingAI>();
    }

    public void ReactToHit()
    {
        if(wanderingAI != null)
        {
            wanderingAI.SetAlive(false);
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        transform.Rotate(-60, 0, 0);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
