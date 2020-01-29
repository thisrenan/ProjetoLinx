using AspNetCoreVueStarter.Model;
using AspNetCoreVueStarter.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AspNetCoreVueStarter.Controllers
{
	[Route("api/[controller]/[action]")]
	public class CidadeController : Controller
	{
		#region Dependencias

		private ICidadeRepository _cidade;

		public CidadeController(ICidadeRepository cidade)
		{
			_cidade = cidade;
		}

		#endregion

		[HttpGet]
		public List<Cidade> Get()
		{
			return _cidade.GetAll();
		}

		[HttpGet]
		public List<RelatorioRegiao> GetCidadeRegiao()
		{
			return _cidade.GetCidadeRegiao();
		}


		[HttpGet]
		public List<RelatorioUf> GetCidadeUf()
		{
			return _cidade.GetCidadeUf();
		}

		[HttpGet("{id}")]
		public Cidade Get(int id)
		{
			Cidade _listaCidadeUnica = _cidade.Find(id);
			return _listaCidadeUnica;
		}

		[HttpPost]
		public async void Post()
		{
			string conteudoJSON = string.Empty;
			using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
			{
				conteudoJSON = await reader.ReadToEndAsync();
			}

			Cidade cidade = JsonConvert.DeserializeObject<Cidade>(conteudoJSON);
			_cidade.Add(cidade);
		}

		// DELETE api/<controller>/5
		[HttpDelete("{id}")]
		public void Remove(int id)
		{
			_cidade.Remove(id);
		}
	}
}
