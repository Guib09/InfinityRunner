namespace InfinityRunner;

public partial class MainPage : ContentPage
{
	bool estaMorto=false;
	bool estaPulando=false;
	const int tempoEntreFrames=25;
	int velocidade1=0;
	int velocidade2=0;
	int velocidade3=0;
	int velocidade=0;
	int larguraJanela=0;
	int alturaJanela=0;

    protected override void OnSizeAllocated(double width, double height)
    {

        base.OnSizeAllocated(width, height);
		CorrigeTamanhoCenario(width,height);
		CalculaVelocidade(width);
		 
		 void CalculaVelocidade(double w)
		 {
			velocidade1=(int)(w* 0 001);
			velocidade24=(int)(w* 0 004);
			velocidade(int)(w* 0 008);
			velocidade= (int)(w* 001);
		 }
           
		   
	








    }










}

