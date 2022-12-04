using WebAPI.Services;
using WebAPI.Domain;
using WebAPI.Models;
// using Fiver.Azure.Table.Client.OtherLayers;
// using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet("{type}", Name = "GetUsersByTpe")]
        public async Task<IActionResult> GetByType(string type)
        {
            UserType userType = (UserType)Enum.Parse(typeof(UserType), type.ToUpper());

            var model = await usersService.GetUsersByType(userType.ToString());
            if (model == null)
                return NotFound();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserInputModel inputModel)
        {
            if (inputModel == null)
                return BadRequest();

            // if (!ModelState.IsValid)
            //     return new UnprocessableObjectResult(ModelState);

            var model = ToDomainModel(inputModel);
            await usersService.AddUser(model);

            var outputModel = ToOutputModel(model);
            //return CreatedAtRoute("GetUser",
            //     new { type = inputModel.PartitionKey, userId = inputModel.RowKey }, inputModel);
            return Ok();
        }

        [HttpPut("{type}/{userId}")]
        public async Task<IActionResult> Update(string type, string userId,
            [FromBody] UserInputModel inputModel)
        {
            if (inputModel == null ||
                type != inputModel.Type ||
                userId != inputModel.UserId)
                return BadRequest();
            try
            {
                UserType userType = (UserType)Enum.Parse(typeof(UserType), type.ToUpper());

                if (!await usersService.UserExists(userType.ToString(), userId))
                    return NotFound();

                // if (!ModelState.IsValid)
                //     return new UnprocessableObjectResult(ModelState);

                var model = ToDomainModel(inputModel);
                await usersService.UpdateUser(model);

            }
            catch (ArgumentException e)
            {
                return UnprocessableEntity();
            }
            // if (!await usersService.UserExists(userType, userId))
            //     return NotFound();

            // if (!ModelState.IsValid)
            //     return new UnprocessableObjectResult(ModelState);

            // var model = ToDomainModel(inputModel);
            // await usersService.UpdateUser(model);

            return NoContent();
        }

        [HttpDelete("{type}/{userId}")]
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
                Type = ((UserType)Enum.Parse(typeof(UserType), inputModel.Type.ToUpper())).ToString(),
                UserId = inputModel.UserId,
                FirstName = inputModel.FirstName,
                LastName = inputModel.LastName,
                Email = inputModel.Email
                // RegistrationDate = DateTime.Now
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
            };
        }

        #endregion
    }
}