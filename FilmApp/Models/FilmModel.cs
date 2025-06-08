using System.ComponentModel.DataAnnotations;


namespace FilmApp.Models
{
    public class FilmModel
    {
        // Primær nøkkel
        public int Id { get; set; }
        //Fremmed nøkkel
        [Required(ErrorMessage = "Skriv inn Film navn")]
        public string Navn { get; set; } = string.Empty;

        [Required(ErrorMessage = "Skriv inn årstalll")]
        [Range(1900, 2024, ErrorMessage = "Året må være mellom 1900 og 2024")]
        public int? AAr { get; set; }

        [Required(ErrorMessage = "Skriv inn poeng")]
        [Range(1,5, ErrorMessage = "Poeng må være mellom 1 og 5")]
        public int? Poeng { get; set; }



    }
}
