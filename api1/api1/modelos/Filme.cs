using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api1.modelos
{
    public class Filme
    {
        [Required(ErrorMessage ="Titulo é obrigatorio")]// infomra que esse campo é obrigatorio 
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Diretor é obrigatorio ")]
        public string Diretor { get; set; }
        public string Genero { get; set; }
        [Range (1,600, ErrorMessage ="duração de ver ser entre 1 minuto a 600 minutos")]// limita entre 1 a 600 
        public int duracao { get; set; }
        [Key]
        [Required]
        public int Id { get;  set; }
    }
}
