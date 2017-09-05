using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using GestaoEscolar.Controllers;

namespace GestaoEscolar.Models
{
    public class Cliente
    {
        //Basico
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(200, MinimumLength = 8, ErrorMessage = "Nome deve ser valido")]
        [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "Nome deve conter apenas Letras")]
        [DisplayName("Nome")]
        public string Nome { get; set; } // nome completo do aluno, sem abreviações, de acordo com a certidão de nascimento

        [DisplayName("Função")]
        public string Contato_Funcao { get; set; }

        [DisplayName("Contato")]
        public string Contato_Nome { get; set; }

        [DisplayName("CNPJ/CPF")]
        public string Cgc_Cpf { get; set; }

        [DisplayName("Inscrição Estadual")]
        public string Inscr_Estadual { get; set; }

        //Endereco Residencial

        [DisplayName("Endereco")]
        public string Endereco { get; set; }

        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [DisplayName("UF")]
        public string Estado { get; set; }

        [DisplayName("CEP")]
        public string Cep { get; set; }

        [DisplayName("Telefone 1")]
        public string Telefone1 { get; set; }

        [DisplayName("Telefone 2")]
        public string Telefone2 { get; set; }

        [DisplayName("Telefone 3")]
        public string Telefone3 { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Observação")]
        public string Obs { get; set; }

        [DisplayName("Preço Base")]
        public decimal Preco_Base { get; set; }
    }
}