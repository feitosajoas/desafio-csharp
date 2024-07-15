using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAtividadeEntrevista.Models
{
    public class BeneficiarioModel
    {
        public long Id { get; set; }

        public long IdCliente { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$", ErrorMessage = "Digite um CPF válido")]
        public string CPF { get; set;}

        public Beneficiario GetBeneficiario(long idCliente = 0)
        {
            var beneficiario = new Beneficiario
            {
                Nome = Nome,
                CPF = CPF,
            };

            if (idCliente > 0)
                beneficiario.IdCliente = idCliente;

            return beneficiario;
        }

        public static BeneficiarioModel ConvertToModel(Beneficiario beneficiario)
        {
            var model = new BeneficiarioModel
            {
                Id = beneficiario.Id,
                CPF = beneficiario.CPF,
                Nome = beneficiario.Nome,
            };

            return model;
        }
    }
}