using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Degree { get; set; }
        public string Location { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static List<WeatherData> weatherDatas = new()
        {
            new WeatherData() { Id = 1, Date = "21.01.2022", Degree=10, Location = "��������"},
            new WeatherData() { Id = 23, Date = "10.08.2019", Degree = 20, Location = "�����"},
            new WeatherData() { Id = 24, Date = "05.11.2020", Degree = 15, Location = "����"},
            new WeatherData() { Id = 25, Date = "07.02.2021", Degree = 0, Location = "�����"},
            new WeatherData() { Id = 30, Date = "30.05.2022", Degree = 3, Location = "�����������"}
        };
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{index}")]
        public IActionResult Get(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("������ ��������");
            }
            return Ok(Summaries[index]);
        }

        [HttpGet("find-by-name")]
        public IActionResult GetFindbyname(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("������� ���������� ������");
            }
            int count = Summaries.Count(s => s == name);
            return Ok(count);
        }

        [HttpGet]
        public List<WeatherData> GetAll()
        {
            return weatherDatas;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == id)
                {
                    return Ok(weatherDatas[i]);
                }
            }
            return BadRequest("����� ������ �� ����������");
        }
        [HttpPost]
        public IActionResult Add(WeatherData data)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == data.Id)
                {
                    return BadRequest("������ � ����� ���� ��� ����");
                }
            }
            weatherDatas.Add(data);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(WeatherData data)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == data.Id)
                {
                    weatherDatas[i] = data;
                    return Ok();
                }
            }
            return BadRequest("����� ������ �� ����������");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == id)
                {
                    weatherDatas.RemoveAt(i);
                    return Ok();
                }
            }
            return BadRequest("����� ������ �� ����������");
        }
    }
}