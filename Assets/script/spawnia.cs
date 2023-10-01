using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefabricado del enemigo.
    public Transform respawnPoint; // Punto de reaparici�n.
    public int maxEnemies = 10; // Cantidad m�xima de enemigos en la escena.
    public float respawnInterval = 5f; // Intervalo de respawn en segundos.
    public float spawnOffset = 5f; // Offset para evitar que los enemigos se generen en la misma posici�n.

    private int currentEnemies = 0; // N�mero actual de enemigos en la escena.

    private void Start()
    {
        // Iniciar el respawn de enemigos con un intervalo.
        InvokeRepeating("SpawnEnemies", 0f, respawnInterval);
    }

    private void SpawnEnemies()
    {
        // Calcular cu�ntos enemigos se pueden agregar sin exceder el l�mite.
        int enemiesToSpawn = maxEnemies - currentEnemies;

        // Respawnear la cantidad de enemigos necesaria hasta alcanzar el l�mite.
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            if (currentEnemies >= maxEnemies)
            {
                break; // No generes m�s enemigos si se alcanz� el l�mite.
            }

            // Aplicar una peque�a variaci�n a la posici�n de generaci�n
            Vector3 spawnPosition = respawnPoint.position + Random.insideUnitSphere * spawnOffset;

            // Instanciar el enemigo en la posici�n calculada
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            currentEnemies++;
        }
    }

    // Llama a esta funci�n cuando un enemigo muere para decrementar el contador.
    public void EnemyDied()
    {
        currentEnemies--;
    }
}
