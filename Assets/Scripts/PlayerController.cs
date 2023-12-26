using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller; // Vari�vel para manipula��o do componente CharacterController (basicamente um rigidbody s� que mais flex�vel);
    public float gravity; // Ajusta a for�a da gravidade que ser� aplicada ao personagem
    private Vector3 vert, horz; // Vetores para armazenar as dire��es vertical e horizontal do movimento
    public float vert_speed = 5f, horz_speed = 5f; // Velocidades de movimento vertical e horizontal
    public float horz_input, vert_input; // Vari�veis para armazenar as entradas de teclado horizontal e vertical
    private Vector3 moveDirection; // Vetor para a dire��o na qual o objeto ser� movido
    public Vector3 teste;
    void Start()
    {
        controller = GetComponent<CharacterController>(); // O componente est� sendo atribu�do � vari�vel para poder ser manipulado dentro do script
    }

    void Update()
    {
        vert_input = Input.GetAxisRaw("Vertical"); // Obt�m a entrada vertical 2D do teclado (S ou seta para baixo = -1, 0, W ou seta para cima = 1)
        horz_input = Input.GetAxisRaw("Horizontal"); // Obt�m a entrada horizontal do teclado (A ou seta para a esquerda = -1, 0, D ou seta para direita = 1)
        MoveCha(); // Chama a fun��o de movimento

    }

    void MoveCha() // Fun��o para movimenta��o do personagem baseado no CharacterController
    {
        vert = vert_input * vert_speed * transform.forward; // Calcula o vetor vertical 2D multiplicando a entrada pelo vetor forward (z) do personagem e a velocidade
        horz = horz_input * horz_speed * transform.right; // Calcula o vetor horizontal multiplicando a entrada pelo vetor right (x) do personagem e a velocidade
        moveDirection = horz + vert; // Combina os vetores horizontal e vertical e permite uma poss�vel locomo��o na diagonal
        moveDirection.y -= gravity * Time.deltaTime; // Ajusta a dire��o vertical 3D para simular a gravidade (Esse vertical � diferente dos anteriores, seria o vertical tri-dimensional respons�vel pela posi��o de altura)
        controller.Move(moveDirection * Time.deltaTime); // Move o personagem na dire��o calculada multiplicada pelo tempo decorrido desde o �ltimo quadro renderizado (Time.deltaTime � detalhe de suaviza��o de movimento)
    }
}