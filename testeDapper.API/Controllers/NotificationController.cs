using Microsoft.AspNetCore.Mvc;
using testeDapper.API.Models;

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
        [FromServices] NotificationRepository repository,
        [FromBody] NotificationModel model)
    {
        try
        {
            unitOfWork.BeginTransaction();
            repository.Save(model);
            unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            unitOfWork.Rollback();
        }
        return Ok();
    }
}