using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCC.DAL;

namespace TCC.BLL
{
    public class BLL
    {
        public string Login(string nome, string senha)
        {
            DAL.DAL dal = new DAL.DAL();
            var result = dal.LoginSistema(nome, senha);
            return result;
        }

        public string CadastrarUsuario(string Matricula, string Senha, string Email)
        {
            DAL.DAL dal = new DAL.DAL();
            var result = dal.CadastrarUsuario(Matricula, Senha, Email);
            return result;
        }

        public void AtualizarUsuario(string Matricula, string Nome, string sobreNome, string cidade, string estado, string pais, string sexo, string estadoCivil)
        {
            DAL.DAL dal = new DAL.DAL();
            dal.AtualizarUsuario(Matricula, Nome, sobreNome, cidade, estado, pais, sexo, estadoCivil);
        }

        public string AlterarSenha(string nome, string senha)
        {
            DAL.DAL dal = new DAL.DAL();
            var result = dal.AlterarSenha(nome, senha);
            return result;
        }
        public List<string> Detalhes(string id)
        {
            DAL.DAL dal = new DAL.DAL();
            var result = dal.Detalhes(id);
            return result;
        }

        public string ClimaTempo(string cidade)
        {
            DAL.DAL dal = new DAL.DAL();
            var result = dal.ClimaTempo(cidade);
            return result;
        }
    }
}