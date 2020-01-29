using AspNetCoreVueStarter.Model;
using System.Collections.Generic;

namespace AspNetCoreVueStarter.Repository
{
	public interface ICidadeRepository
    {
		List<Cidade> GetAll();
		List<RelatorioRegiao> GetCidadeRegiao();
		List<RelatorioUf> GetCidadeUf();
		Cidade Add(Cidade cidade);
		Cidade Find(int id);
		Cidade Remove(int id);
		Cidade FindName(string name);
		Cidade FindUF(string uf);
		Cidade FindRegiao(string regiao);
		Cidade FindIBGE(int ibge);
	}
}
