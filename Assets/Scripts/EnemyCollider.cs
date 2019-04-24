using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    [SerializeField] GameObject explode;
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "SceneLaser")
        {
            GetComponent<EnemyAi>().enabled = false;
            GetComponent<Rigidbody>().useGravity = true;
            explode.GetComponent<AudioSource>().Play();
            StartCoroutine(DestroySelf());
        }
    }
    IEnumerator DestroySelf()
    {
        yield return new WaitForSecondsRealtime(8.0f);
        Destroy(gameObject);
    }
}
