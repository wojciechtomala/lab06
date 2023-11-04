using System;
using System.ComponentModel.DataAnnotations;
namespace zajecia3.Models
{
    public class Dane
    {
        // NAME:
        [Required(ErrorMessage = "Podaj Imie")]
        [MinLength(2, ErrorMessage = "Imie musi zawierać co najmniej 2 znaki")]
        public string Imie { get; set; }
        
        // SURNAME:
        [Required(ErrorMessage = "Podaj Nazwisko")]
        [MinLength(2, ErrorMessage = "Nazwisko musi zawierać co najmniej 2 znaki")]
        public string Nazwisko { get; set; }


        // EMAIL:
        [Required(ErrorMessage = "Wymagany poprawny adres email: example@domain.com")]
        [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
        public string Email { get; set; }
        
        // PASSWORD:
        [Required(ErrorMessage = "Podaj Hasło")]
        [MinLength(8, ErrorMessage = "Hasło musi mieć co najmniej 8 znaków")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$", ErrorMessage = "Hasło musi zawierać co najmniej jedną cyfrę, jedną dużą literę i jedną małą literę")]
        [DataType(DataType.Password)]
        public string Haslo { get; set; }

        // REPEAT PASSWORD:
        [Required(ErrorMessage = "Potwierdź Hasło")]
        [Compare("Haslo", ErrorMessage = "Hasło i jego potwierdzenie muszą być takie same")]
        [DataType(DataType.Password)]
        public string PotwierdzenieHasla { get; set; }

        // PHONE:
        [Required(ErrorMessage = "Podaj Nr telefonu")]
        [DataType(DataType.PhoneNumber)]
        public string NrTelefonu { get; set; }

        // AGE:
        [Required(ErrorMessage = "Podaj Wiek")]
        [Range(11, 80, ErrorMessage = "Wiek musi być pomiędzy 11 a 80 lat")]
        public int Wiek { get; set; }

        // CITY:
        [Required(ErrorMessage = "Wybierz Miasto")]
        [EnumDataType(typeof(Miasto), ErrorMessage = "Wybrane miasto nie jest dostępne")]
        public Miasto WybraneMiasto { get; set; }
        public enum Miasto
        {
            [Display(Name = "Warszawa")]
            Warszawa,

            [Display(Name = "Kraków")]
            Krakow,

            [Display(Name = "Poznań")]
            Poznan,

            [Display(Name = "Wrocław")]
            Wroclaw,

            [Display(Name = "Gdańsk")]
            Gdansk
        }

        /*
        [Required(ErrorMessage = "Prosze podaj Temat")]
        public string Temat { get; set; }
        [Required(ErrorMessage = "Prosze podaj Tresc")]
        [MinLength(10), MaxLength(50)]
        public string Tresc { get; set; }
        */
    }
}
