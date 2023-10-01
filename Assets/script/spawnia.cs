using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefabricado del enemigo.
    public Transform respawnPoint; // Punto de reaparición.
    public int maxEnemies = 10; // Cantidad máxima de enemigos en la escena.
    public float respawnInterval = 5f; // Intervalo de respawn en segundos.
    public float spawnOffset = 5f; // Offset para evitar que los enemigos se generen en la misma posición.

    private int currentEnemies = 0; // Número actual de enemigos en la escena.

    private void Start()
    {
        // Iniciar el respawn de enemigos con un intervalo.
        InvokeRepeating("SpawnEnemies", 0f, respawnInterval);
    }

    private void SpawnEnemies()
    {
        // Calcular cuántos enemigos se pueden agregar sin exceder el límite.
        int enemiesToSpawn = maxEnemies - currentEnemies;

        // Respawnear la cantidad de enemigos necesaria hasta alcanzar el límite.
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            if (currentEnemies >= maxEnemies)
            {
                break; // No generes más enemigos si se alcanzó el límite.
            }

            // Aplicar una pequeña variación a la posición de generación
            Vector3 spawnPosition = respawnPoint.position + Random.insideUnitSphere * spawnOffset;

            // Instanciar el enemigo en la posición calculada
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            currentEnemies++;
        }
    }

    // Llama a esta función cuando un enemigo muere para decrementar el contador.
    public void EnemyDied()
    {
        currentEnemies--;
    }
}
