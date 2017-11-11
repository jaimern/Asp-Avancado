﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace Loja.Mvc.Helpers
{
    public class CulturaHelper
   { 
        public CulturaHelper()
        {
            ObterRegiao();
        }
        public const string LinguagemPadrao = "pt-BR";

        public string Abreviacao{ get; set; }
        public CultureInfo CultureInfo { get; private set; }
        public string NomeNativo { get; private set; }
        public List<string> LinguagensSuportadas { get; }
        = new List<string> { LinguagemPadrao, "es", "en-US" };

        private void ObterRegiao()
        {
            var linguagem = LinguagemPadrao;
            var linguagemSelecionada = HttpContext.Current.Request.Cookies[Cookie.LinguagemSelecionada];

            if (linguagemSelecionada !=null && LinguagensSuportadas.Contains(linguagemSelecionada.Value))
            {
                linguagem = linguagemSelecionada.Value;
            }

            var cultura =  CultureInfo.CreateSpecificCulture(linguagem);
            this.CultureInfo = cultura;

            var regiao = new RegionInfo(cultura.LCID);
            NomeNativo = regiao.NativeName;
            Abreviacao = regiao.TwoLetterISORegionName.ToLower();
        }
    }
}