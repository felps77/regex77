using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtStr_Rgx
{
    public class ExtrStr
    {
        /// <summary>
        /// Retorna o item desejado da coleção de valores encontrados que estão intercalados entre duas strings (de 'ini' até o primeiro 'fim' encontrado).
        /// </summary>
        /// <param name="texto">Texto onde se deseja realizar a busca.</param>
        /// <param name="pos">Número do grupo desejado da coleção em ordem crescente.</param>
        /// <param name="ini">String de início onde se inicia a busca.</param>
        /// <param name="fim">String até aonde se faz a busca.</param>
        /// <param name="regexOptions">Modo como se deseja pesquisar a string. Opção padrão é 'IgnoreCase'.</param>
        /// <returns>Retorna ou não a posição da string encontrada. Caso não encontre nada, será uma string vazia.</returns>
        public string ExtStr_Pos(string texto, int pos, string ini, string fim, RegexOptions regexOptions)
        {
            // Coleção vetorizada que retorna todos os padrões buscados
            MatchCollection matches = null;

            // Variável que armazenará o valor possível encontrado
            string valor_mtc = "";

            // Expressão regular que busca conforme os parâmetros passados
            matches = Regex.Matches(texto, @"(?<=" + ini + @")[\s\S]*?(?=" + fim + @")", regexOptions);

            int i = 1;
            // Loop que itera entre a coleção formada
            foreach (Match match in matches)
            {
                if (i < pos)
                {
                    i++;
                    continue;
                }
                valor_mtc = match.Value;
                break; // Quando encontrar o primeiro padrão, retorna o seu respectivo valor
            }
            return valor_mtc;
        }

        /// <summary>
        /// Retorna o primeiro valor intercalado entre duas strings (de 'ini' até o último 'fim' encontrado).
        /// </summary>
        /// <param name="texto">Texto onde se deseja realizar a busca.</param>
        /// <param name="ini">String de início onde se inicia a busca.</param>
        /// <param name="fim">String até aonde se faz a busca.</param>
        /// <param name="regexOptions">Modo como se deseja pesquisar a string. Opção padrão é 'IgnoreCase'.</param>
        /// <returns>Retorna ou não a primeira string encontrada. Caso não encontre, será uma string vazia.</returns>
        public string ExtStr_Default(string texto, string ini, string fim, RegexOptions regexOptions)
        {
            // Coleção vetorizada que retorna todos os padrões buscados
            MatchCollection matches = null;

            // Variável que armazenará o valor possível encontrado
            string valor_mtc = "";

            // Expressão regular que busca conforme os parâmetros passados
            matches = Regex.Matches(texto, @"(?<=" + ini + @")[\s\S]*(?=" + fim + @")", regexOptions);

            // Loop que itera entre a coleção formada
            foreach (Match match in matches)
            {
                valor_mtc = match.Value;
                break; // Quando encontrar o primeiro padrão, retorna o seu respectivo valor
            }
            return valor_mtc;
        }
    }
}
