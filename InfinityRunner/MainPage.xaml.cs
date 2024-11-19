namespace InfinityRunner
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
		player = new Player(imgplayer);
		player.Run();
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
    
  