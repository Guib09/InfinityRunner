namespace InfinityRunner;
public partial class MainPage : ContentPage
{
	

	bool estamorto = false;

	bool tapuland = false;
	

	const int TimeToFrame = 25;

	int velocidadedaprimeiraimg = 0;
	
	int velocidadedasegundaimg = 0;
	
	int velocidadedaterceiraimg = 0;
	
	int velecidadedochao = 0;
	
	int alturadajanela = 0;

	int larguradajanela = 0;

	//------------------------------------------------------------------------//

	public MainPage()
	{
		InitializeComponent();
	}


	//------------------------------------------------------------------------//



	//------------------------------------------------------------------------//
	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		FixScreenSize(w, h);
		CalculateSpeed(w);
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Drawn();
	}
	//------------------------------------------------------------------------//

	void FixScreenSize(double w, double h)
	{
		foreach (var A in primeiraimg.Children)
			(A as Image).WidthRequest = w;
		foreach (var A in segundaimg.Children)
			(A as Image).WidthRequest = w;
		foreach (var A in terceiraimg.Children)
			(A as Image).WidthRequest = w;
		foreach (var A in quartaimg.Children)
			(A as Image).WidthRequest = w;

		primeiraimg.WidthRequest = w * 1.5;
		segundaimg.WidthRequest = w * 1.5;
		terceiraimg.WidthRequest = w * 1.5;
		quartaimg.WidthRequest = w * 1.5;
	}

	//------------------------------------------------------------------------//
	void CalculateSpeed(double w)
	{
		velocidadedaprimeiraimg = (int)(w * 0.001);
		velocidadedasegundaimg = (int)(w * 0.004);
		velocidadedaterceiraimg = (int)(w * 0.008);
		velecidadedochao = (int)(w * 0.01);
	}

	//------------------------------------------------------------------------//
	async Task Drawn()
	{
		while (!estamorto)
		{
			ManageScenes();
			await Task.Delay(TimeToFrame);
		}
	}

	//------------------------------------------------------------------------//
	void MoveScene()
	{
		primeiraimg.TranslationX -= velocidadedaprimeiraimg;
		segundaimg.TranslationX -= velocidadedasegundaimg;
		terceiraimg.TranslationX -= velocidadedaterceiraimg;
		quartaimg.TranslationX -= velecidadedochao;
	}

	//------------------------------------------------------------------------//
	void ManageScenes()
	{
		MoveScene();
		ManageScene(primeiraimg);
		ManageScene(segundaimg);
		ManageScene(terceiraimg);
		ManageScene(quartaimg);
	}


	//------------------------------------------------------------------------//

	void ManageScene(HorizontalStackLayout HSL)
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
		while (!estamorto)
		{
			GerenciaCenarios();
		    Player.Desenha();
            await Task.Delay9tempoEntreFrames):;
		}
	  }


	//------------------------------------------------------------------------//
}