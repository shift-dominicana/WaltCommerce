using BussinesLayer.Repositories.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.Core
{
    public class CoreController<TIService, TEntity, TViewModel> : ControllerBase, ICoreController<TEntity>
    where TEntity : class
    where TViewModel : class
    where TIService : IRepository<TEntity, TViewModel>
    {

        private readonly TIService _service;
        public CoreController(TIService service)
        {
            _service = service;
        }


        [HttpGet]
        public virtual async Task<IActionResult> Get()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var reqResult = await _service.GeTModelByIdAsync(id);
            if (reqResult != null) return Ok(reqResult);
            return NoContent();
        }


        [HttpPost]
        public virtual async Task<IActionResult> Create(TEntity entity)
        {
            var reqResult = await _service.CreateAsync(entity);
            if (reqResult != null) return Ok(reqResult);
            return BadRequest("Error Creating the Entity");
        }

        [HttpPut]
        public virtual async Task<IActionResult> Edit(TEntity entity)
        {
            var reqResult = await _service.EditAsync(entity);
            if (reqResult != null)
            {
                return Ok(reqResult);
            }

            return BadRequest("Error Updating");
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var reqResult = await _service.DeleteByIdAsync(id);
            if (reqResult)
            {
                return Ok();
            }
            return BadRequest("Error Deleting entity");
        }

    }
}
