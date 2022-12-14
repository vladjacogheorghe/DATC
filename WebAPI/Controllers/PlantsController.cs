using System;
using WebAPI.Services;
using WebAPI.Domain;
using WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("plants")]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantsService plantsService;

        public PlantsController(IPlantsService plantsService)
        {
            this.plantsService = plantsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await plantsService.GetPlants();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpGet("{plantId}", Name = "GetPlant")]
        public async Task<IActionResult> Get(string plantId)
        {
            var model = await plantsService.GetPlant(plantId);
            if (model == null)
                return NotFound();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpPost(Name = "CreatePlant")]
        public async Task<IActionResult> Create([FromBody] PlantInputModel inputCreateModel)
        {
            if (inputCreateModel == null)
                return BadRequest();

            // if (!ModelState.IsValid)
            //     return new UnprocessableObjectResult(ModelState);

            var model = ToDomainModel(inputCreateModel);
            await plantsService.AddPlant(model);

            var outputModel = ToOutputModel(model);
            return Ok();
        }

        [HttpPut("{plantId}", Name = "UpdatePlant")]
        public async Task<IActionResult> Update(string plantId,
            [FromBody] PlantInputModel inputModel)
        {
            if (inputModel == null ||
                !plantId.ToUpper().Equals(inputModel.PlantId.ToUpper()))
                return BadRequest("PlantIds are not the same!");
            try
            {
                if (!await plantsService.PlantExists(plantId))
                    return NotFound("Plant doesn't exist!");

                var model = ToDomainModel(inputModel);
                await plantsService.UpdatePlant(model);

            }
            catch (ArgumentException)
            {
                return UnprocessableEntity();
            }
            return NoContent();
        }

        [HttpDelete("{plantId}", Name = "DeletePlant")]
        public async Task<IActionResult> Delete(string plantId)
        {
            if (!await plantsService.PlantExists(plantId))
                return NotFound();

            await plantsService.DeletePlant(plantId);

            return NoContent();
        }

        #region " Mappings "

        private PlantOutputModel ToOutputModel(PlantEntity model)
        {
            return new PlantOutputModel
            {
                PlantId = model.PartitionKey,
                Name = model.Name,
            };
        }

        private List<PlantOutputModel> ToOutputModel(List<PlantEntity> model)
        {
            return model.Select(item => ToOutputModel(item))
                        .ToList();
        }

        private PlantEntity ToDomainModel(PlantInputModel inputModel)
        {
            return new PlantEntity
            {
                PartitionKey = inputModel.PlantId,
                RowKey = inputModel.PlantId,
                Name = inputModel.Name
            };
        }
        private PlantInputModel ToInputModel(PlantEntity model)
        {
            return new PlantInputModel
            {
                PlantId = model.PartitionKey,
                Name = model.Name,
            };
        }

        #endregion
    }
}