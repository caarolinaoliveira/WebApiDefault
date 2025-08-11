using Microsoft.AspNetCore.Mvc;

namespace MinhaPrimeiraAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    // Get api/values
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<string>> ObterTodos()
    {
        return new string[] { "value1", "value2" };
    }

    // Get api/values/obter-por-id-5
    [HttpGet("obter-por-id/{id}")]
    public ActionResult<string> ObterPorId(int id)
    {
        return "value " + id;
    }

    // POST api/values
    [HttpPost]
    [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult Post(Product product)
    {
        if (product.Id == 0)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Post), product);
    }

    // PUT api/values

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
