using Sistema_Api.Modelos.Dto;

namespace Sistema_Api.Datos
{
	public static class CoordinacionStore
	{
		public static List<CoordinacionDto> coordinacionList = new List<CoordinacionDto>
		{
				new CoordinacionDto{Id=1, Nombre="Centro Culiacan"},
				new CoordinacionDto{Id=2, Nombre="Norte Mochis"}

		};
	}
}
