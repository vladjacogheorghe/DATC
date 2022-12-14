using WebAPI.Services;
using WebAPI.Domain;
using WebAPI.Models;
// using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await usersService.GetUsers();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpGet("{type}/{userId}", Name = "GetUser")]
        public async Task<IActionResult> Get(string type, string userId)
        {
            UserType userType = (UserType)Enum.Parse(typeof(UserType), type.ToUpper());

            var model = await usersService.GetUser(userType.ToString(), userId);
            if (model == null)
                return NotFound();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpGet("{type}", Name = "GetUsersByType")]
        public async Task<IActionResult> GetByType(string type)
        {
            UserType userType = (UserType)Enum.Parse(typeof(UserType), type.ToUpper());

            var model = await usersService.GetUsersByType(userType.ToString());
            if (model == null)
                return NotFound();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<IActionResult> Create([FromBody] UserCreateInputModel inputCreateModel)
        {
            if (inputCreateModel == null)
                return BadRequest();

            // if (!ModelState.IsValid)
            //     return new UnprocessableObjectResult(ModelState);

            var model = ToDomainModel(inputCreateModel);
            await usersService.AddUser(model);

            var outputModel = ToOutputModel(model);
            //return CreatedAtRoute("GetUser",
            //     new { type = inputModel.PartitionKey, userId = inputModel.RowKey }, inputModel);
            return Ok();
        }

        [HttpPut("{type}/{userId}", Name = "UpdateUser")]
        public async Task<IActionResult> Update(string type, string userId,
            [FromBody] UserInputModel inputModel)
        {
            if (inputModel == null ||
                !type.ToUpper().Equals(inputModel.Type.ToUpper()) ||
                !userId.ToUpper().Equals(inputModel.UserId.ToUpper()))
                return BadRequest("Types and/or UserIds are not the same!");
            try
            {
                UserType userType = (UserType)Enum.Parse(typeof(UserType), type.ToUpper());

                if (!await usersService.UserExists(userType.ToString(), userId))
                    return NotFound("User doesn't exist!");

                // if (!ModelState.IsValid)
                //     return new UnprocessableObjectResult(ModelState);

                var model = ToDomainModel(inputModel);
                await usersService.UpdateUser(model);

            }
            catch (ArgumentException)
            {
                return UnprocessableEntity();
            }
            return NoContent();
        }

        [HttpDelete("{type}/{userId}", Name = "DeleteUser")]
        public async Task<IActionResult> Delete(string type, string userId)
        {
            UserType userType = (UserType)Enum.Parse(typeof(UserType), type.ToUpper());
            if (!await usersService.UserExists(userType.ToString(), userId))
                return NotFound();

            await usersService.DeleteUser(userType.ToString(), userId);

            return NoContent();
        }

        #region " Mappings "

        private UserOutputModel ToOutputModel(UserEntity model)
        {
            return new UserOutputModel
            {
                Type = model.PartitionKey,
                UserId = model.RowKey,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                RegistrationDate = model.RegistrationDate,
                Timestamp = model.Timestamp
            };
        }

        private List<UserOutputModel> ToOutputModel(List<UserEntity> model)
        {
            return model.Select(item => ToOutputModel(item))
                        .ToList();
        }

        private UserEntity ToDomainModel(UserInputModel inputModel)
        {
            return new UserEntity
            {
                PartitionKey = ((UserType)Enum.Parse(typeof(UserType), inputModel.Type.ToUpper())).ToString(),
                RowKey = inputModel.UserId,
                FirstName = inputModel.FirstName,
                LastName = inputModel.LastName,
                Email = inputModel.Email,
                Latitude = inputModel.Latitude ,//!= null ? (double)inputModel.Latitude : 0.0f,
                Longitude = inputModel.Longitude //!= null ? (double)inputModel.Longitude : 0.0f
            };
        }
        private UserEntity ToDomainModel(UserCreateInputModel inputCreateModel)
        {
            return new UserEntity
            {
                PartitionKey = ((UserType)Enum.Parse(typeof(UserType), inputCreateModel.Type.ToUpper())).ToString(),
                RowKey = inputCreateModel.UserId,
                FirstName = inputCreateModel.FirstName,
                LastName = inputCreateModel.LastName,
                Email = inputCreateModel.Email,
                RegistrationDate = DateTime.Now
            };
        }

        private UserInputModel ToInputModel(UserEntity model)
        {
            return new UserInputModel
            {
                Type = model.PartitionKey,
                UserId = model.RowKey,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Latitude = model.Latitude,
                Longitude = model.Longitude
            };
        }

        private UserCreateInputModel ToCreateInputModel(UserEntity model)
        {
            return new UserCreateInputModel
            {
                Type = model.PartitionKey,
                UserId = model.RowKey,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
            };
        }

        #endregion

    }
}