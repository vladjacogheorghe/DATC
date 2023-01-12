using System.Web.Http.Cors;
using WebAPI.Services;
using WebAPI.Domain;
using WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://127.0.0.1:5173/", headers: "*", methods: "*")]
    [ApiController]
    [Route("[controller]")]
    public class FindingsController : ControllerBase
    {
        private readonly IFindingsService findingsService;

        public FindingsController(IFindingsService findingsService)
        {
            this.findingsService = findingsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await findingsService.GetFindings();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpGet("{plantId}/{findingId}", Name = "GetFinding")]
        public async Task<IActionResult> Get(string plantId, string findingId)
        {

            var model = await findingsService.GetFinding(plantId, findingId);
            if (model == null)
                return NotFound();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpGet("{plantId}", Name = "GetFindingsByPlantId")]
        public async Task<IActionResult> GetByType(string plantId)
        {
            var model = await findingsService.GetFindingsByType(plantId);
            if (model == null)
                return NotFound();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpPost(Name = "CreateFinding")]
        public async Task<IActionResult> Create([FromBody] FindingInputModel inputCreateModel)
        {
            if (inputCreateModel == null)
                return BadRequest();

            var model = ToDomainModel(inputCreateModel);
            await findingsService.AddFinding(model);

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpPut("{plantId}/{FindingId}", Name = "UpdateFinding")]
        public async Task<IActionResult> Update(string plantId, string findingId,
            [FromBody] FindingInputModel inputModel)
        {
            if (inputModel == null ||
                !plantId.ToUpper().Equals(inputModel.PlantId.ToUpper()) ||
                !findingId.ToUpper().Equals(inputModel.FindingId.ToUpper()))
                return BadRequest("PlantIds and/or FindingIds are not the same!");
            try
            {

                if (!await findingsService.FindingExists(plantId, findingId))
                    return NotFound("Finding doesn't exist!");

                // if (!ModelState.IsValid)
                //     return new UnprocessableObjectResult(ModelState);

                var model = ToDomainModel(inputModel);
                await findingsService.UpdateFinding(model);

                var outputModel = ToOutputModel(model);
                return Ok(outputModel);
            }
            catch (ArgumentException)
            {
                return UnprocessableEntity();
            }
            return NoContent();
        }

        [HttpDelete("{plantId}/{FindingId}", Name = "DeleteFinding")]
        public async Task<IActionResult> Delete(string plantId, string findingId)
        {
            if (!await findingsService.FindingExists(plantId, findingId))
                return NotFound();

            await findingsService.DeleteFinding(plantId, findingId);

            return NoContent();
        }

        #region " Mappings "

        private FindingOutputModel ToOutputModel(FindingEntity model)
        {
            return new FindingOutputModel
            {
                PlantId = model.PartitionKey,
                FindingId = model.RowKey,
                UserId = model.UserId,
                Radius = model.Radius,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Timestamp = model.Timestamp
            };
        }

        private List<FindingOutputModel> ToOutputModel(List<FindingEntity> model)
        {
            return model.Select(item => ToOutputModel(item))
                        .ToList();
        }

        private FindingEntity ToDomainModel(FindingInputModel inputModel)
        {
            return new FindingEntity
            {
                PartitionKey = inputModel.PlantId,
                RowKey = inputModel.FindingId,
                UserId = inputModel.UserId,
                Radius = inputModel.Radius,
                Latitude = inputModel.Latitude,
                Longitude = inputModel.Longitude
            };
        }
        // private FindingEntity ToDomainModel(FindingCreateInputModel inputCreateModel)
        // {
        //     return new FindingEntity
        //     {
        //         PartitionKey = inputCreateModel.PlantId,
        //         RowKey = inputCreateModel.FindingId,
        //         Radius = inputCreateModel.Radius,
        //         Latitude = inputCreateModel.Latitude,
        //         Longitude = inputCreateModel.Longitude
        //     };
        // }

        private FindingInputModel ToInputModel(FindingEntity model)
        {
            return new FindingInputModel
            {
                PlantId = model.PartitionKey,
                FindingId = model.RowKey,
                UserId = model.UserId,
                Radius = model.Radius,
                Latitude = model.Latitude,
                Longitude = model.Longitude
            };
        }

        // private FindingCreateInputModel ToCreateInputModel(FindingEntity model)
        // {
        //     return new FindingCreateInputModel
        //     {
        //         PlantId = model.PartitionKey,
        //         FindingId = model.RowKey,
        //         Radius = model.Radius,
        //         Latitude = model.Latitude,
        //         Longitude = model.Longitude
        //     };
        // }

        #endregion 
    }
}