using Microsoft.AspNetCore.Mvc;
using pairProgrammingØvelse;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DRrestAPI.Controllers
{
    [Route("Record")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private RecordRepo recordRepo = new RecordRepo();

        public RecordController(RecordRepo repo)
        {
            this.recordRepo = repo;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // GET: api/<RecordController>
        [HttpGet]
        public IEnumerable<Record> GetAll()
        {
            return recordRepo.GetAll();
        }

        // GET api/<RecordController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // POST api/<RecordController>
        [HttpPost]
        public ActionResult<Record> Post([FromBody] Record value)
        {
            Record record = recordRepo.Add(value);
            return CreatedAtAction((nameof(GetAll)), new { title = record.Title }, record);
        }

        // PUT api/<RecordController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
