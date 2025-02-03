using Microsoft.AspNetCore.Mvc;
using Université_Domain.DataAdapters.DataAdaptersFactory;
using Université_Domain.Entities;
using Université_Domain.UseCases.UeUseCase.Create;
using Université_Domain.UseCases.UeUseCase.Delete;
using Université_Domain.UseCases.UeUseCase.Get;
using Université_Domain.UseCases.UeUseCase.Update;
using UniversiteDomain.Dtos;

namespace UniversiteRestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UeController(IRepositoryFactory repositoryFactory) : ControllerBase{

    [HttpGet("{id}")]
    public async Task<UeDto> getUe(long id)
    {
        GetUnUeUseCase ueUseCase = new GetUnUeUseCase(repositoryFactory);
        UeDto dto=new UeDto();
        var res =  dto.ToDto(await ueUseCase.ExecuteAsync(id));
        return res;
    }
    
    [HttpGet("all")]
    public async Task<List<Ue>> getUeall()
    {
        GetAllUeUseCase ueUseCase = new GetAllUeUseCase(repositoryFactory);
        
        return await ueUseCase.ExecuteAsync();;
    }

    [HttpPost("create")]
    public async Task<UeDto> createUe(Ue ue)
    {
        CreateUeUseCase ueUseCase = new CreateUeUseCase(repositoryFactory);
        UeDto dto = new UeDto();
        return dto.ToDto(await ueUseCase.ExecuteAsync(ue));

    }

    [HttpDelete("delete/{id}")]
    public async Task<String> deleteUe(long id)
    {
        DeleteUeUseCase ueUseCase = new DeleteUeUseCase(repositoryFactory);
        if (await ueUseCase.ExecuteAsync(id))
        {
            return "Ue deleted";
        }
        else
        {
            return "Ue not deleted";

        }
        
        
    }

    [HttpPut("update/{id}")]
    public async Task<UeDto> updateUe(long id, Ue ue)
    {
        UpdateUeUseCase ueUseCase = new UpdateUeUseCase(repositoryFactory);
        UeDto dto = new UeDto();
        var res = await ueUseCase.ExecuteAsync(id, ue);
        return dto.ToDto(res);
    }
    // finishing the crud for main entities , still need to handle the crud for the relation between the tables many to many ....
    
}