using Microsoft.AspNetCore.Mvc;
using Université_Domain.DataAdapters.DataAdaptersFactory;

namespace UniversiteRestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoteController(IRepositoryFactory repositoryFactory) : ControllerBase{

    
    //[HttpGet("/{id}")]
    
}