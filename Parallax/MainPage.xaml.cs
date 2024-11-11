namespace Parallax;

public partial class MainPage : ContentPage
{
	bool estamorto = false;
	bool estapulando = false;
	const int tempoentreframes = 25;
	int velocidade = 0;
	int velocidade1 = 0;
	int velocidade2 = 0;
	int velocidade3 = 0;
	int larguraJanela = 0;
	int alturaJanela = 0;

	public MainPage()
	{
		InitializeComponent();
	}
	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		CalculaVelocidade(w);
		CorrigeTamanho(w, h);
	}

	void GerenciaImagens(HorizontalStackLayout HSL)
	{
		var view = (HSL.Children.First() as Image);
		if (view.WidthRequest + HSL.TranslationX <0)
		{
			HSL.Children.Remove(view);
			HSL.Children.Add(view);
			HSL.TranslationX=view.TranslationX;
		}
	}
	void CalculaVelocidade(double w)
	{
		velocidade = (int)(w * 0.01);
		velocidade1 = (int)(w * 0.001);
		velocidade2 = (int)(w * 0.004);
		velocidade3 = (int)(w * 0.008);
	}

	void CorrigeTamanho(double w, double h)
	{
		foreach (var a in HSLayer1.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in HSLayer2.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in HSLayerChao.Children)
			(a as Image).WidthRequest = w;

		HSLayer1.WidthRequest = w;
		HSLayer2.WidthRequest = w;
		HSLayerChao.WidthRequest = w;
	}

	void MoveCenario()
	{
		HSLayer1.TranslationX-=velocidade1;
		HSLayer2.TranslationX-=velocidade2;
        HSLayerChao.TranslationX-=velocidade;
	}

	void GerenciaImagens()
	{
		MoveCenario();
		GerenciaImagens(HSLayer1);
		GerenciaImagens(HSLayer2);
		GerenciaImagens(HSLayerChao);
	}

	async Task Desenha()
	{
		while (!estamorto)
		{
			GerenciaImagens();
			await Task.Delay(tempoentreframes);
		}
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		Desenha();
	}
	
	

}