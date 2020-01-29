using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreVueStarter.Model
{
	[Table("cidade", Schema = "public")]
	public class Cidade
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Display(Name = "ID da Cidade")]
		public int idCidade { get; set; }

		[Required]
		[Column(TypeName = "character varying(255)")]
		[Display(Name = "Nome da Cidade")]
		public string cidade { get; set; }

		[Required]
		[Column(TypeName = "double precision")]
		[Display(Name = "Latitude da cidade")]
		public double latitude { get; set; }

		[Required]
		[Column(TypeName = "double precision")]
		[Display(Name = "Longitude da cidade")]
		public double longitude { get; set; }

		[Required]
		[Column(TypeName = "character varying(255)")]
		[Display(Name = "Regiao da Cidade")]
		public string regiao { get; set; }

		[Required]
		[Column(TypeName = "character varying(2)")]
		[Display(Name = "UF da Cidade")]
		public string uf { get; set; }

		[Required]
		[Column(TypeName = "integer")]
		[Display(Name = "IBGE da Cidade")]
		public int ibge { get; set; }
	}
}
