namespace InfinityRunner;
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
	Player player;
	 



	public MainPage()
	{
		InitializeComponent();
		player = new Player (imgPlayer);
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
	void CorrigeTamanhoCenario (double w, double h)
	{
		foreach (var a in Layer1.Children)
		(a as Image).WidthRequest = w;
		foreach (var a in Layer2.Children)
		(a as Image).WidthRequest = w;
		foreach (var a in Layer3.Children)
		(a as Image).WidthRequest = w;
		
		Layer1.WidthRequest = w * 1.5;
		Layer2.WidthRequest = w * 1.5;
		Layer3.WidthRequest = w * 1.5;
	}
	void GerenciaCenarios()
	{
		MoveCenario();
		GerenciaCenarios (Layer1);
		GerenciaCenarios (Layer2);
		GerenciaCenarios (Layer3);
		
	}
	void MoveCenario()
	{
		Layer1.TranslationX -= velocidade1;
		Layer2.TranslationX -= velocidade2;
		Layer3.TranslationX -= velocidade3;
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
	async Task  Desenha()
	{
		while (!estaMorto)
		{
			GerenciaCenarios();
			player.Desenha();
			await Task.Delay (tempoEntreFrames);
		}
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		Desenha();
    }


}