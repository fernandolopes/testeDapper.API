using Microsoft.AspNetCore.Mvc;

namespace testeDapper.API.Controllers;

public class NotificationController : Controller
{
    // GET
    [HttpGet("")]
    public IEnumerable<NotificationModel> Get(
        [FromServices] NotificationRepository repository)
    {
        return repository.Get();
    }
    
    [HttpPost("")]
    public IActionResult Post(
        [FromServices] IUnitOfWork unitOfWork,
        [FromServices] NotificationRepository repository)
    {
        unitOfWork.BeginTransaction();
        repository.Save(new NotificationModel
        {
            Id = 1,
            Title = "Teste",
            Message = "Teste"
        });
        unitOfWork.Commit();
        return Ok();
    }
}