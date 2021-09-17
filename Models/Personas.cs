using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria.Models
{
    public class Personas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<PersonaPasatiempo> Pasatiempos { get; set; } = new List<PersonaPasatiempo>();
    }
	public class Pasatiempo
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
	}

	public class PersonaPasatiempo
	{
		public int Id { get; set; }
		public int PersonaId { get; set; }
		public Personas Personas { get; set; }
		public int PasatiempoId { get; set; }
		public Pasatiempo Pasatiempo { get; set; }
	}

	public class PersonaView
	{
		public int Id { get; set; }
		public string Nombre { get; set; }

		public PersonaView(Personas p)
		{
			Id = p.Id;
			Nombre = p.Nombre;
			if (p.Pasatiempos != null)
				Pasatiempos = p.Pasatiempos.Select(x => x.Pasatiempo);
		}

		public IEnumerable<Pasatiempo> Pasatiempos { get; set; } = new List<Pasatiempo>();
	}
}

