using Microsoft.Maui.Controls;
using System;

namespace InfinityRunner
{
    public class Player
    {
        public Image Image { get; set; }
        public double TranslationY { get; set; }
        public double HeightRequest => Image.HeightRequest;

        // Construtor do jogador, onde você pode passar a imagem do jogador
        public Player(Image image)
        {
            Image = image;
            TranslationY = 0;
        }

        // Método para o movimento do jogador (exemplo básico de correr)
        public void Run()
        {
            // Aqui você pode definir como o jogador vai se mover
        }

        // Método para o pulo do jogador
        public void Jump()
        {
            TranslationY -= 100; // Move o jogador para cima (exemplo)
        }

        // Método para atualizar a posição do jogador
        public void Desenha()
        {
            // Aqui você pode atualizar a posição ou animação do jogador
            Image.TranslationY = TranslationY;
        }
    }
}
