using Microsoft.AspNetCore.Mvc;
using Université_Domain.DataAdapters.DataAdaptersFactory;
using Université_Domain.Entities;
using Université_Domain.UseCases.ParcoursUseCases.Create;
using Université_Domain.UseCases.ParcoursUseCases.Delete;
using Université_Domain.UseCases.ParcoursUseCases.Get;
using Université_Domain.UseCases.ParcoursUseCases.Update;
using UniversiteDomain.Dtos;

namespace UniversiteRestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParcoursController(IRepositoryFactory repositoryFactory) : ControllerBase{


    [HttpGet("{id}")]
    public async Task<ParcoursDto> getParcours(long id)
    {
        GetUnParcoursUseCase pr = new GetUnParcoursUseCase(repositoryFactory);
        try
        {
            var res = await pr.ExecuteAsync(id);
            ParcoursDto dto = new ParcoursDto();
            var res2=dto.ToDto(res);
            return res2;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
         
    }
    [HttpGet("all")]
    public async Task<List<ParcoursDto>> getParcours()
    {
        GetAllParcoursUseCase pr = new GetAllParcoursUseCase(repositoryFactory);
        try
        {
            var res =await pr.ExecuteAsync();
            ParcoursDto dto = new ParcoursDto();
            
            
            return dto.ToDtos(res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
         
    }

    [HttpDelete("delete/{id}")]
    public Task<bool> deleteParcours(long id) // fix delete cascade error 
    {
        DeleteParcoursUseCase del = new DeleteParcoursUseCase(repositoryFactory);
        return del.ExecuteAsync(id);
    }

    [HttpPost("add")]
    public async Task<ParcoursDto> addParcours(Parcours parcours)
    {
        CreateParcoursUseCase pr = new CreateParcoursUseCase(repositoryFactory);
        ParcoursDto dto = new ParcoursDto();
        var res= dto.ToDto(await pr.ExecuteAsync(parcours));
        return res;
    }

    [HttpPut("update/{id}")]
    public async Task<ParcoursDto> updateParcours(long id, Parcours parcours)
    {
        UpdateParcoursUseCase pr = new UpdateParcoursUseCase(repositoryFactory);
        ParcoursDto dto = new ParcoursDto();
        var res= dto.ToDto(await pr.ExecuteAsync(id, parcours));
        return res;
    }
    
}