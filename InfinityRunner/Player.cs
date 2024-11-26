using System.Linq.Expressions;
using FFImageLoading.Maui;

public delegate void CallBack();
public class Player:Animacao
{
    public Player(CachedImageView a) : base(a)
    {
            for(int numero = 1; numero <= 7; numero++)
                Animacao1.Add($"corre{numero.ToString("D2")}.png");

            for(int numero2 = 1; numero2 <= 2; numero2++)
                Animacao2.Add($"morto{numero2.ToString("D2")}.png");
            SetAnimacaoAtiva(1);
        }

    public void Die()
    {
        loop = false;
        SetAnimacaoAtiva(2);
    }
    public void Run()
    {
        loop = true;
        SetAnimacaoAtiva(1);
        Play();
    }
     
    public void MoveY (int s)
    {
        ImageView.TranslationY +=s;
    }
    public double GetY ()
    {
        return ImageView.TranslationY;
    }
    public void SetY (double a)
    {
        ImageView.TranslationY = a;
    }
}

        