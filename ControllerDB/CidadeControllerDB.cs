using AspNetCoreVueStarter.DataAccess;
using AspNetCoreVueStarter.Model;
using AspNetCoreVueStarter.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreVueStarter.ControllerDB
{
	public class CidadeControllerDB : ICidadeRepository
	{
		private readonly ArchDataContext _contexto;

		public CidadeControllerDB(ArchDataContext ctx)
		{
			_contexto = ctx;
		}

		/// <summary>
		/// Buscar todas as cidades
		/// </summary>
		public List<Cidade> GetAll()
		{
			List<Cidade> data = this._contexto.Cidades.ToList();
			return data;
		}

		/// <summary>
		/// Buscar cidades por regiao
		/// </summary>
		public List<RelatorioRegiao> GetCidadeRegiao()
		{
			 var query = this._contexto.Cidades.GroupBy(p => p.regiao).Select(g => new { regiao = g.Key, count = g.Count() });

			var listRelatorioRegiao = new List<RelatorioRegiao>();
			foreach (var row in query)
			{
				var relatorioRegiao = new RelatorioRegiao();				
				relatorioRegiao.regiao = row.regiao;
				relatorioRegiao.count = row.count;			
				listRelatorioRegiao.Add(relatorioRegiao);
			}

			return listRelatorioRegiao;	

		}

		/// <summary>
		/// Buscar cidades por UF
		/// </summary>
		public List<RelatorioUf> GetCidadeUf()
		{
			var query = this._contexto.Cidades.GroupBy(p => p.uf).Select(g => new { uf = g.Key, count = g.Count() });

			var listRelatorioUf = new List<RelatorioUf>();
			foreach (var row in query)
			{
				var relatorioUf = new RelatorioUf();
				relatorioUf.uf = row.uf;
				relatorioUf.count = row.count;
				listRelatorioUf.Add(relatorioUf);
			}

			return listRelatorioUf;
		}


		/// <summary>
		/// Insere uma cidade no banco da dados.  
		/// </summary>
		[HttpPost]
		public Cidade Add(Cidade model)
		{
			_contexto.Cidades.Add(model);
			_contexto.SaveChanges();
			return model;
		}

		/// <summary>
		/// Atualizar uma cidade no banco da dados.  
		/// </summary>
		[HttpPost]
		public Cidade Update(Cidade model)
		{
			_contexto.Cidades.Update(model);
			_contexto.SaveChanges();

			return model;
		}

		/// <summary>
		/// Remove uma cidade no banco da dados.  
		/// </summary>
		public Cidade Remove(int id)
		{
			var cidade = new Cidade();
			cidade = Find(id);
			_contexto.Cidades.Remove(cidade);
			_contexto.SaveChanges();
			return cidade;
		}

		/// <summary>
		/// Buscar uma cidade pelo ID
		/// </summary>
		public Cidade Find(int id)
		{
			Cidade model = _contexto.Cidades.FirstOrDefault(v => v.idCidade == id);
			return model;
		}

		/// <summary>
		/// Buscar uma cidade pelo nome
		/// </summary>
		public Cidade FindName(string name)
		{
			Cidade model = _contexto.Cidades.FirstOrDefault(v => v.cidade == name);
			return model;
		}

		/// <summary>
		/// Buscar uma cidade pelo uf
		/// </summary>
		public Cidade FindUF(string uf)
		{
			Cidade model = _contexto.Cidades.FirstOrDefault(v => v.uf == uf);
			return model;
		}

		/// <summary>
		/// Buscar uma cidade pela regiao
		/// </summary>
		public Cidade FindRegiao(string regiao)
		{
			Cidade model = _contexto.Cidades.FirstOrDefault(v => v.regiao == regiao);
			return model;
		}

		/// <summary>
		/// Buscar uma cidade pelo ibge
		/// </summary>
		public Cidade FindIBGE(int ibge)
		{
			Cidade model = _contexto.Cidades.FirstOrDefault(v => v.ibge == ibge);
			return model;
		}
	}
}
