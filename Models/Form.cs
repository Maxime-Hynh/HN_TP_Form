using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class Form
    {

        [DisplayName("Nom")]
        public string Nom { get; set; }
        [DisplayName("Prénom")]

        public string Prenom { get; set; }
        [DisplayName("Sexe")]
        [RegularExpression(@"Homme|Femme|Autre")]
        public string Sexe { get; set; }
        [DisplayName("Adresse")]

        public string Adresse { get; set; }
        [DisplayName("Code Postal")]
        [RegularExpression(@"[0-9]+")]
        [StringLength(5)]
        [MinLength(5)]
        public string CodePostal { get; set; }
        [DisplayName("Ville")]

        public string Ville { get; set; }
        [DisplayName("Adresse mail")]
        [RegularExpression(@"^([\w]+)@([\w]+)\.([\w]+)$")]

        public string Email { get; set; }
        [DisplayName("Date de début de formation")]

        public DateTime DateDebut { get; set; }
        [DisplayName("Formation suivie")]
        [RegularExpression(@"Cobol|Csharp|Dual")]
        //[AllowedValues("Cobol","CSharp","Dual")]
               
        public string Formation { get; set; }
        [DisplayName("Formation Cobol")]
        public string AvisCobol { get; set; }
        [DisplayName("Formation C#")]
        public string AvisCsharp { get; set; }

    }
}
