using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBackend.Api.Mappers;
using StoreBackend.Api.Models.Requests;
using StoreBackend.Exceptions;
using StoreBackend.Facade;

namespace StoreBackend.Api.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierFacade supplierFacade;

        public SupplierController(ISupplierFacade supplierFacade)
        {
            this.supplierFacade = supplierFacade;
        }

        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            var suppliers = await supplierFacade.GetAllAsync();
            var models = SupplierMapper.ToModel(suppliers);
            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplier(Guid id)
        {
            try
            {
                var supplier = await supplierFacade.GetByIdAsync(id);
                var model = SupplierMapper.ToModel(supplier);
                return Ok(model);
            }
            catch (ResourceNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier([FromBody] CreateSupplierRequestModel supplier)
        {
            var dto = SupplierMapper.ToDto(supplier);
            var addedSupplier = await supplierFacade.AddAsync(dto);
            var model = SupplierMapper.ToModel(addedSupplier);
            return CreatedAtAction(nameof(GetSupplier), new { id = model.SupplierResourceId }, model);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(Guid id)
        {
            try
            {
                await supplierFacade.DeleteAsync(id);
                return Ok();
            }
            catch (ResourceNotFoundException)
            {
                return NotFound();
            }
        }
    }
}