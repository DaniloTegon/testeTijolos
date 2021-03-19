using System;
using System.Collections.Generic;
using System.Linq;

namespace testeTijolos
{
	class Program
	{
		static void Main(string[] args)
		{
			int[][] tijolos = new int[][] {
							  new int[] { 1, 2, 2, 1 },
							  new int[] { 3, 1, 2 },
							  new int[] { 1, 3, 2 },
							  new int[] { 2, 4 },
							  new int[] { 3, 1, 2 },
							  new int[] { 1, 3, 1, 1 }};

			Console.WriteLine("A posição da parede com menos tijolos é a posição " + RetornaPosicaoMenosTijolos(6, tijolos));
			Console.Read();
		}

		static int RetornaPosicaoMenosTijolos(int tamanhoParede, int[][] tijolos)
		{
			Dictionary<int, int> fissuras = new Dictionary<int, int>();

			for (int posicao = 1; posicao < tamanhoParede; posicao++)
				fissuras.Add(posicao, 0);

			for (int i = 0; i < tijolos.Count(); i++)
			{
				int posicao = 0;
				int[] linhaAtual = tijolos[i];

				for (int j = 0; j < linhaAtual.Count(); j++)
				{
					posicao = posicao + linhaAtual[j];

					if (posicao != tamanhoParede)
						fissuras[posicao] = fissuras.Where(_ => _.Key == posicao).FirstOrDefault().Value + 1;
				}
			}

			return fissuras.Values.Max();
		}
	}
}
