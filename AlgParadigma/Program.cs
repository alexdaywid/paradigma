using System;

namespace AlgParadigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] entrada = { 3, 2, 1, 6, 0, 5 };
            //int[] entrada = { 7,5,13,9,1,6,4 };

            int indexMaiorValordeEndtrada;
            int maiorValordaEntrada = PegarMaiorValor(entrada, out indexMaiorValordeEndtrada);

            Arvore arvore = new Arvore(maiorValordaEntrada, indexMaiorValordeEndtrada);
            for (int i = 0; i < entrada.Length; i++)
            {
                if (entrada[i] != maiorValordaEntrada)
                    arvore.Inserir(entrada[i], i);
            }


            arvore.Imprimir(arvore.Raiz);

            int PegarMaiorValor(int[] entrada, out int index)
            {
                int maiorValor = 0;
                index = 0;
                for (int i = 0; i < entrada.Length; i++)
                {
                    if (entrada[i] > maiorValor)
                    {
                        maiorValor = entrada[i];
                        index = i;
                    }

                }
                return maiorValor;
            }
            Console.ReadKey();

        }
    }
}





public class NoArvore
{
    public NoArvore(int valor, int index)
    {
        Valor = valor;
        Index = index;
    }

    public int Valor { get; set; }
    public int Index { get; set; }
    public NoArvore GalhoEsquerdo { get; set; }
    public NoArvore GalhoDireito { get; set; }
}


public class Arvore
{
    public NoArvore Raiz { get; set; }
    public Arvore(int valor, int index)
    {
        Raiz = new NoArvore(valor, index);
    }

    public void Inserir(int valor, int index)
    {
        Inserir(null, valor, index);
    }

    protected virtual void Inserir(NoArvore noArvore, int valor, int index)
    {
        if (noArvore is null)
            noArvore = Raiz;

        if (valor < noArvore.Valor && index < Raiz.Index)
        {
            if (noArvore.GalhoEsquerdo is null)
                noArvore.GalhoEsquerdo = new NoArvore(valor, index);
            else
                Inserir(noArvore.GalhoEsquerdo, valor, index);
        }
        else
        {
            if (noArvore.GalhoDireito is null)
                noArvore.GalhoDireito = new NoArvore(valor, index);
            else if (noArvore.GalhoDireito.Valor < valor)
            {
                var menorValor = noArvore.GalhoDireito.Valor;
                noArvore.GalhoDireito.Valor = valor;
                Inserir(noArvore.GalhoDireito, menorValor, index);
            }
            else
            {
                Inserir(noArvore.GalhoDireito, valor, index);
            }

        }
    }

    public void Imprimir(NoArvore raiz)
    {
        if (raiz != null)
        {
            Console.WriteLine($"          {raiz.Valor}  ");

            Imprimir(raiz.GalhoEsquerdo);
            Imprimir(raiz.GalhoDireito);

        }
    }



}

