﻿using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollOptionController : ControllerBase
    {
        public CoutryhouseContext Context { get; }

        public PollOptionController(CoutryhouseContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<PollOption> options = Context.PollOptions.ToList();
            return Ok(options);
        }

        [HttpGet("{optionId}/{pollId}")]
        public IActionResult GetById(int optionId, int pollId)
        {
            PollOption? option = Context.PollOptions
                .Where(x => x.OptionId == optionId && x.PollId == pollId)
                .FirstOrDefault();
            if (option == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(option);
        }

        [HttpPost]
        public IActionResult Add(PollOption option)
        {
            Context.PollOptions.Add(option);
            Context.SaveChanges();
            return Ok(option);
        }

        [HttpPut]
        public IActionResult Update(PollOption option)
        {
            var existingOption = Context.PollOptions
                .Where(x => x.OptionId == option.OptionId && x.PollId == option.PollId)
                .FirstOrDefault();
            if (existingOption == null)
            {
                return BadRequest("Not Found");
            }

            // Обновление значений
            Context.Entry(existingOption).CurrentValues.SetValues(option);
            Context.SaveChanges();
            return Ok(option);
        }

        [HttpDelete("{optionId}/{pollId}")]
        public IActionResult Delete(int optionId, int pollId)
        {
            PollOption? option = Context.PollOptions
                .Where(x => x.OptionId == optionId && x.PollId == pollId)
                .FirstOrDefault();
            if (option == null)
            {
                return BadRequest("Not Found");
            }
            Context.PollOptions.Remove(option);
            Context.SaveChanges();
            return Ok();
        }
    }
}