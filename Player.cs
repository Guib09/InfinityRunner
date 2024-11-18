namespace InfinityRunner
{
    public class Player
    {
        private string imagem;

        public Player(string imagem)
        {
            this.imagem = imagem;
        }

        public void Run()
        {
            // Lógica de movimento do jogador
        }

        public void Desenha()
        {
            // Lógica para desenhar o jogador na tela
        }

        public double GetY()
        {
            // Retorna a posição Y do jogador
            return 0; // Exemplo simples
        }

        public void SetY(double y)
        {
            // Define a posição Y do jogador
        }

        public void MoveY(double valor)
        {
            // Move o jogador na direção Y
        }
    }
}