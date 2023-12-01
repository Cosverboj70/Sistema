using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Api.Datos;
using Sistema_Api.Modelos;
using Sistema_Api.Modelos.Dto;

namespace Sistema_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CoordinacionesController : ControllerBase
	{
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<IEnumerable<CoordinacionDto>> GetCoordinaciones()
		{
			return Ok(CoordinacionStore.coordinacionList);
		}

		[HttpGet("id:int", Name="GetCoordinacion")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<CoordinacionDto> GetCoordinacion(int id)
		{
			if(id== 0)
			{
				return BadRequest();
			}
			var coordinacion = CoordinacionStore.coordinacionList.FirstOrDefault(v => v.Id == id);

			if(coordinacion == null)
			{
				return NotFound();
			}
			return Ok(coordinacion);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<CoordinacionDto> CrearCoordinacion([FromBody] CoordinacionDto coordinacionDto)
		{
			if(coordinacionDto==null)
			{
				return BadRequest(coordinacionDto);
			}
			if(coordinacionDto.Id>0)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			coordinacionDto.Id=CoordinacionStore.coordinacionList.OrderByDescending(v => v.Id).FirstOrDefault().Id+1;
			CoordinacionStore.coordinacionList.Add(coordinacionDto);
			return CreatedAtRoute("GetCoordinacion", new {id=coordinacionDto.Id,coordinacionDto});
		}

	}
}
