using Microsoft.AspNetCore.Identity;
using Université_Domain.Entities;


namespace UniversiteEFDataProvider.Entities;

public class UniversiteUser:IdentityUser, IUniversiteUser {
    [PersonalData]
    public Etudiant? Etudiant { get; set; }
    [PersonalData]
    public long? EtudiantId { get; set; }
}