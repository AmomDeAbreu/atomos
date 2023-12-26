using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller; // Variável para manipulação do componente CharacterController (basicamente um rigidbody só que mais flexível);
    public float gravity; // Ajusta a força da gravidade que será aplicada ao personagem
    private Vector3 vert, horz; // Vetores para armazenar as direções vertical e horizontal do movimento
    public float vert_speed = 5f, horz_speed = 5f; // Velocidades de movimento vertical e horizontal
    public float horz_input, vert_input; // Variáveis para armazenar as entradas de teclado horizontal e vertical
    private Vector3 moveDirection; // Vetor para a direção na qual o objeto será movido
    public Vector3 teste;
    void Start()
    {
        controller = GetComponent<CharacterController>(); // O componente está sendo atribuído à variável para poder ser manipulado dentro do script
    }

    void Update()
    {
        vert_input = Input.GetAxisRaw("Vertical"); // Obtém a entrada vertical 2D do teclado (S ou seta para baixo = -1, 0, W ou seta para cima = 1)
        horz_input = Input.GetAxisRaw("Horizontal"); // Obtém a entrada horizontal do teclado (A ou seta para a esquerda = -1, 0, D ou seta para direita = 1)
        MoveCha(); // Chama a função de movimento

    }

    void MoveCha() // Função para movimentação do personagem baseado no CharacterController
    {
        vert = vert_input * vert_speed * transform.forward; // Calcula o vetor vertical 2D multiplicando a entrada pelo vetor forward (z) do personagem e a velocidade
        horz = horz_input * horz_speed * transform.right; // Calcula o vetor horizontal multiplicando a entrada pelo vetor right (x) do personagem e a velocidade
        moveDirection = horz + vert; // Combina os vetores horizontal e vertical e permite uma possível locomoção na diagonal
        moveDirection.y -= gravity * Time.deltaTime; // Ajusta a direção vertical 3D para simular a gravidade (Esse vertical é diferente dos anteriores, seria o vertical tri-dimensional responsável pela posição de altura)
        controller.Move(moveDirection * Time.deltaTime); // Move o personagem na direção calculada multiplicada pelo tempo decorrido desde o último quadro renderizado (Time.deltaTime é detalhe de suavização de movimento)
    }
}