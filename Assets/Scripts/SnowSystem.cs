using UnityEngine;
using System.Collections;

public class SnowSystem : MonoBehaviour
{
    private ParticleSystem myParticles;
    private Transform playerTransform;
    float elapsed;
    float duration;
    float currentX;
    float result;
    float t;
    //Système qui accentue la neige du niveau 1 au fur et à mesure qu'on avance dans le niveau
    void Start()
    {
        myParticles = GetComponent<ParticleSystem>();
        playerTransform = FindFirstObjectByType<FlowerSystem>().GetComponent<Transform>();
        StartCoroutine(Wind());
    }

    // Update is called once per frame
    void Update()
    {
        var emission = myParticles.emission;
        emission.rateOverTime = playerTransform.position.x + 10;
    }

    IEnumerator Wind()
    {
        Debug.Log("wind start");
        elapsed = 0f;
        duration = 3f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            t = elapsed / duration;
            var Velocity = myParticles.velocityOverLifetime;
            currentX = Velocity.x.constant;
            result = Mathf.Lerp(currentX, playerTransform.position.x, t);
            Velocity.x = new ParticleSystem.MinMaxCurve(result);
            yield return null;
        }
    }
}
