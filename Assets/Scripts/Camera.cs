using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    //public float minX, maxX;
    public float timeLerp;
    public float maxYLimit;
    public float minYLimit;

    void FixedUpdate()
    {
        // Define a nova posição da câmera
        Vector3 newPosition = player.position + new Vector3(0, 0, -10);

        // Mantém a câmera acima do maxYLimit
        if (player.position.y > maxYLimit)
        {
            newPosition.y = player.position.y + 0.1f; // Adiciona uma pequena folga
        }
        // Limita a posição mínima da câmera no eixo Y
        newPosition.y = Mathf.Max(newPosition.y, minYLimit);

        // Suaviza o movimento da câmera
        newPosition = Vector3.Lerp(transform.position, newPosition, timeLerp);

        // Limita a posição da câmera no eixo X
        //newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Atualiza a posição da câmera
        transform.position = newPosition;
    }
}
