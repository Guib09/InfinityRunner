namespace InfinityRunner
{
    public partial class MainPage : ContentPage
    {
        bool Morreu = false;
        bool pulo = false;
        const int TempoEntreFrames = 25;
        int velocidade1 = 0;
        int velocidade2 = 0;
        int velocidade = 0;
        int LarguraJanela = 0;
        int AlturaJanela = 0;
        Player player;
        const int ForcaGravidade = 6;
        bool EstaNoChao = true;
        bool EstaNoAr = false;
        bool EstaPulando = false;
        int TempoPulando = 0;
        int TempoNoAr = 0;
        const int ForcaPulo = 12;
        const int maxTempoPulando = 10;
        const int maxTempoNoAr = 4;

        public MainPage()
        {
            InitializeComponent();
            player = new Player(imgplayer); // Inicializa o jogador
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            player.Run();  // Inicia o movimento do jogador quando a página aparecer
            Desenha();     // Começa a desenhar/atualizar o cenário
        }

        protected override void OnSizeAllocated(double w, double h)
        {
            base.OnSizeAllocated(w, h);
            CorrigeTamanhoCenario(w, h);
            CalcularVelocidade(w);
        }

        void CalcularVelocidade(double w)
        {
            velocidade1 = (int)(w * 0.001);
            velocidade2 = (int)(w * 0.004);
            velocidade = (int)(w * 0.01);
        }

        void CorrigeTamanhoCenario(double w, double h)
        {
            foreach (var a in HSLayer1.Children)
                (a as Image).WidthRequest = w;
            foreach (var b in HSLayer2.Children)
                (b as Image).WidthRequest = w;
            foreach (var c in HSLayerChao.Children)
                (c as Image).WidthRequest = w;
            HSLayer1.WidthRequest = w * 1.5;
            HSLayer2.WidthRequest = w * 1.5;
            HSLayerChao.WidthRequest = w * 1.5;
        }

        void GerenciarCenarios()
        {
            MoverCenarios();
            GerenciarCenario(HSLayer1);
            GerenciarCenario(HSLayer2);
            GerenciarCenario(HSLayerChao);
        }

        void MoverCenarios()
        {
            HSLayer1.TranslationX -= velocidade1;
            HSLayer2.TranslationX -= velocidade2;
            HSLayerChao.TranslationX -= velocidade;
        }

        void GerenciarCenario(HorizontalStackLayout HSL)
        {
            var view = (HSL.Children.First() as Image);
            if (view.WidthRequest + HSL.TranslationX < 0)
            {
                HSL.Children.Remove(view);
                HSL.Children.Add(view);
                HSL.TranslationX = view.TranslationX;
            }
        }

        async Task Desenha()
        {
            while (!Morreu)
            {
                GerenciarCenarios();
                if (!EstaPulando && !EstaNoAr)
                {
                    AplicaGravidade();
                    player.Desenha();
                }
                else
                    AplicaPulo();
                await Task.Delay(TempoEntreFrames);
            }
        }

        void AplicaPulo()
        {
            EstaNoChao = false;
            if (EstaPulando && TempoPulando >= maxTempoPulando)
            {
                EstaPulando = false;
                EstaNoAr = true;
                TempoNoAr = 0;
            }
            else if (EstaNoAr && TempoNoAr >= maxTempoNoAr)
            {
                EstaPulando = false;
                EstaNoAr = false;
                TempoPulando = 0;
                TempoNoAr = 0;
            }
            else if (EstaPulando && TempoPulando < maxTempoPulando)
            {
                player.MoveY(-ForcaPulo);  // Move o jogador para cima ao pular
                TempoPulando++;
            }
            else if (EstaNoAr)
                TempoNoAr++;
        }

        void OnGridTapped(object sender, TappedEventArgs e)
        {
            if (EstaNoChao)  // Só inicia o pulo se o jogador estiver no chão
                EstaPulando = true;
        }

        void AplicaGravidade()
        {
            if (!EstaNoChao) // Aplica a gravidade apenas se o jogador não estiver no chão
            {
                if (player.GetY() < 0)
                    player.MoveY(ForcaGravidade);  // Move para baixo com a força da gravidade
                else if (player.GetY() >= 0)
                {
                    player.SetY(0);  // Quando o jogador chegar ao chão, ajusta sua posição para 0
                    EstaNoChao = true;
                }
            }
        }
    }
}


