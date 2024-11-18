using Microsoft.Maui.Controls;


namespace InfinityRunner
{
    public partial class MainPage : ContentPage
    {
        bool estaMorto = false;
        bool estaPulando = false;
        const int tempoEntreFrames = 25;
        int velocidade1 = 0;
        int velocidade2 = 0;
        int velocidade3 = 0;
        int velocidade = 0;
        int larguraJanela = 0;
        int alturaJanela = 0;
        const int forcaGravidade = 6;
        bool estanoChao = true;
        bool estanoAr = false;
        int tempoPulando = 0;
        int temponoAr = 0;
        const int forcaPulo = 8;
        const int maxTempoPulando = 6;
        const int maxTemponoAr = 4;
        Player player;
    public class Player
{
    private string _sprite;

    public Player(string sprite)
    {
        _sprite = sprite;
    }

    public void Run()
    {
        // Lógica para o personagem correr
    }

    public void Desenha()
    {
        // Lógica para desenhar o personagem
    }

    public void MoveY(int distance)
    {
        // Mover o personagem no eixo Y
    }

    public void SetY(int y)
    {
        // Definir a posição Y do personagem
    }

    public int GetY()
    {
        // Retornar a posição Y do personagem
        return 0; // Ajuste conforme necessário
    }
}


        public MainPage()
        {
            InitializeComponent();
            // Substitua o caminho "sonic.png" por um correto para o seu projeto
            player = new Player("sonic.png");
            player.Run();
        }

        protected override void OnSizeAllocated(double w, double h)
        {
            base.OnSizeAllocated(w, h);
            CorrigeTamanhoCenario(w, h);
            CalculaVelocidade(w);
        }

        void CalculaVelocidade(double w)
        {
            velocidade1 = (int)(w * 0.001);
            velocidade2 = (int)(w * 0.004);
            velocidade3 = (int)(w * 0.008);
            velocidade = (int)(w * 0.01);
        }

        void CorrigeTamanhoCenario(double w, double h)
        {
            // Certifique-se de que img1, img2, img3 estão declarados como ImageViews ou qualquer outro tipo esperado
            foreach (var a in img1.Children)
                (a as Image).WidthRequest = w;
            foreach (var a in img2.Children)
                (a as Image).WidthRequest = w;
            foreach (var a in img3.Children)
                (a as Image).WidthRequest = w;

            img1.WidthRequest = w * 1.5;
            img2.WidthRequest = w * 1.5;
            img3.WidthRequest = w * 1.5;
        }

        void GerenciaCenarios()
        {
            MoveCenario();
            GerenciaCenarios(img1);
            GerenciaCenarios(img2);
            GerenciaCenarios(img3);
        }

        void MoveCenario()
        {
            img1.TranslationX -= velocidade1;
            img2.TranslationX -= velocidade2;
            img3.TranslationX -= velocidade3;
        }

        void GerenciaCenarios(HorizontalStackLayout horizontalStackLayout)
        {
            var view = (horizontalStackLayout.Children.First() as Image);
            if (view.WidthRequest + horizontalStackLayout.TranslationX < 0)
            {
                horizontalStackLayout.Children.Remove(view);
                horizontalStackLayout.Children.Add(view);
                horizontalStackLayout.TranslationX = view.TranslationX;
            }
        }

        async Task Desenha()
        {
            while (!estaMorto)
            {
                GerenciaCenarios();
                player.Desenha();
                await Task.Delay(tempoEntreFrames);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ = Desenha(); // Adicionando "await" para garantir que o método assíncrono seja executado corretamente
        }

        void AplicaGravidade()
        {
            if (player.GetY() < 0)
                player.MoveY(forcaGravidade);
            else if (player.GetY() >= 0)
            {
                player.SetY(0);
                estanoChao = true;
            }
        }

        void AplicaPulo()
        {
            estanoChao = false;
            if (estaPulando && tempoPulando >= maxTempoPulando)
            {
                estaPulando = false;
                estanoAr = true;
                temponoAr = 0;
            }
            else if (estanoAr && temponoAr >= maxTemponoAr)
            {
                estaPulando = false;
                estanoAr = false;
                tempoPulando = 0;
                temponoAr = 0;
            }
            else if (estaPulando && tempoPulando < maxTempoPulando)
            {
                player.MoveY(-forcaPulo);
                tempoPulando++;
            }
            else if (estanoAr)
                temponoAr++;
        }
    }
}