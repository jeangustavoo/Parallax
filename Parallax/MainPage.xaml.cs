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

	async Task Desenhar()
	{
		while (!estamorto)
		{
			GerenciaImagens();
			await Task.Delay(tempoentreframes);
		}
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

	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		CalculaVelocidade(w);
		CorrigeTamanho(w, h);
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		Desenhar();
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
		foreach (var a in HsLayer1.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in HsLayer2.Children)
			(a as Image).WidthRequest = w;
		foreach (var a in HsLayer4Chao.Children)
			(a as Image).WidthRequest = w;

		HsLayer1.WidthRequest = w;
		HsLayer2.WidthRequest = w;
		HsLayer4Chao.WidthRequest = w;
	}

	void MoveCenario()
	{
		HsLayer1.TranslationX-=velocidade1;
		HsLayer2.TranslationX-=velocidade2;
        HsLayer4Chao.TranslationX-=velocidade;
	}

	void GerenciaImagens()
	{
		MoveCenario();
		GerenciaImagens(HsLayer1);
		GerenciaImagens(HsLayer2);
		GerenciaImagens(HsLayer4Chao);
	}

	async Task Desenha()
	{
		while (!estamorto)
		{
			GerenciaImagens();
			await Task.Delay(tempoentreframes);
		}
	}
	
	

}