using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Université_Domain.DataAdapters.DataAdaptersFactory;
using Université_Domain.Entities;
using Université_Domain.UseCases.EtudiantUseCases.Create;
using UniversiteDomain.Dtos;

namespace UniversiteRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtudiantController(IRepositoryFactory repositoryFactory) : ControllerBase
    {
        // GET: api/<EtudiantController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EtudiantController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EtudiantController>
        /*[HttpPost]
        public void Post([FromBody] string value)
        {
        }*/

        // PUT api/<EtudiantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EtudiantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
        // POST api/<EtudiantController>
        [HttpPost]
        public async Task<EtudiantDto> PostAsync([FromBody] EtudiantDto etudiantDto)
        {
            // Converstion d'un EtudiantDto sans Id en Etudiant
            Etudiant etudiant = etudiantDto.ToEntity();
            // Création d'un étudiant
            CreateEtudiantUseCase uc=new CreateEtudiantUseCase(repositoryFactory);
            etudiant = await uc.ExecuteAsync(etudiant);
            // Conversion de l'étudiant avec son nouvel Id en EtudiantDto
            return new EtudiantDto().ToDto(etudiant);
        }
        
        /*
         *to check after 
         * // POST api/<EtudiantController>
        [HttpPost]
        public async Task<ActionResult<EtudiantDto>> PostAsync([FromBody] EtudiantDto etudiantDto)
        {
            CreateEtudiantUseCase createEtudiantUc = new CreateEtudiantUseCase(repositoryFactory);           
            Etudiant etud = etudiantDto.ToEntity();
            try
            {
                etud = await createEtudiantUc.ExecuteAsync(etud);
            }
            catch (Exception e)
            {
                // On récupère ici les exceptions personnalisées définies dans la couche domain
                // Et on les envoie avec le code d'erreur 400 et l'intitulé "erreurs de validation"
                ModelState.AddModelError(nameof(e), e.Message);
                return ValidationProblem();
            }
            EtudiantDto dto = new EtudiantDto().ToDto(etud);
            // On revoie la route vers le get qu'on n'a pas encore écrit!
            
            return CreatedAtAction(nameof(GetUnEtudiant), new { id = dto.Id }, dto);
        }*/
    }
}
