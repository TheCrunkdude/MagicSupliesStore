using System;
namespace MagicstoreAPI.Infrastructures.Entities.SeedData
{
	public static class BeersSeedData
	{
		public static List<Beers> beers()
		{
			return new List<Beers>()
			{
				new Beers {id = 1, nombre = "IPA Classic", estilo = "IPA", pais = "USA",},
				new Beers { id = 2, nombre = "Golden Ale", estilo = "Ale", pais = "UK" },
                new Beers { id = 3, nombre = "Stout Premium", estilo = "Stout", pais = "Ireland" },
                new Beers { id = 4, nombre = "Amber Lager", estilo = "Lager", pais = "Germany" }
            };
		}
		
	}
}

