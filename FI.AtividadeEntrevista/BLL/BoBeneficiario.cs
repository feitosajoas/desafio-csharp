using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario
    {
        
        public long Incluir(DML.Beneficiario beneficiario)
        {
            DAL.DaoBeneficiario bene = new DAL.DaoBeneficiario();
            return bene.Incluir(beneficiario);
        }

        
        public static void Alterar(DML.Beneficiario beneficiario)
        {
            DAL.DaoBeneficiario bene = new DAL.DaoBeneficiario();
            bene.Alterar(beneficiario);
        }

        
        public static DML.Beneficiario Consultar(long id)
        {
            DAL.DaoBeneficiario bene = new DAL.DaoBeneficiario();
            return bene.Consultar(id);
        }

        
        public static void Excluir(long id)
        {
            DAL.DaoBeneficiario bene = new DAL.DaoBeneficiario();
            bene.Excluir(id);
        }

        
        public List<DML.Beneficiario> Listar()
        {
            DAL.DaoBeneficiario bene = new DAL.DaoBeneficiario();
            return bene.Listar();
        }

        
        public List<DML.Beneficiario> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        {
            DAL.DaoBeneficiario bene = new DAL.DaoBeneficiario();
            return bene.Pesquisa(iniciarEm, quantidade, campoOrdenacao, crescente, out qtd);
        }

        
        public static bool VerificarExistencia(string CPF)
        {
            DAL.DaoBeneficiario bene = new DAL.DaoBeneficiario();
            return bene.VerificarExistencia(CPF);
        }

        public static bool VerificarExistencia(string CPF, long IdCliente)
        {
            DAL.DaoBeneficiario bene = new DAL.DaoBeneficiario();
            return bene.VerificarExistencia(CPF, IdCliente);
        }
    }
}
