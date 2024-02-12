using System;
using ApiContacts.Domains.Repositories;
using ApiContacts.Infra;
using ApiContacts.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiContacts.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UsuarioRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Usuario> BuscaTodos()
        {
            return _databaseContext.Usuarios.ToList();
        }

        public Usuario BuscarPorId(Guid id)
        {
            Usuario usuario = _databaseContext.Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            return usuario;
        }

        public Usuario Criar(Usuario usuario)
        {
            usuario.CriadoEm = DateTime.Now;
            _databaseContext.Usuarios.Add(usuario);
            _databaseContext.SaveChanges();
            return usuario;
        }

        public Boolean Deletar(Guid id)
        {
            Usuario usuario = _databaseContext.Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuario == null)
            {
                return false;
            }
            else
            {
                _databaseContext.Usuarios.Remove(usuario);
                _databaseContext.SaveChanges();
                return true;
            }
        }

        public Usuario Editar(Usuario usuario)
        {
            Usuario usuarioNoBanco = _databaseContext.Usuarios.FirstOrDefault(x => x.Id == usuario.Id);

            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado na base");
            }
            else
            {
                usuarioNoBanco.Nome = usuario.Nome;
                usuarioNoBanco.Login = usuario.Login;
                usuarioNoBanco.Email = usuario.Email;
                usuarioNoBanco.Perfil = usuario.Perfil;
                usuarioNoBanco.AtualizadoEm = DateTime.Now;
                _databaseContext.SaveChanges();
                return usuarioNoBanco;
            }
        }

        public Usuario Autenticar(string login, string senha)
        {
            Usuario usuario = _databaseContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());

            bool senhaEhValida = usuario.SenhaValida(senha);

            if (senhaEhValida) return usuario;

            return null;
        }

        public Usuario BuscarPorEmailELogin(string email, string login)
        {
            Usuario usuario = _databaseContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());

            return usuario;
        }

        public Usuario AtualizarNovaSenha(AlterarSenha alterarSenha)
        {
            Usuario usuarioDb = BuscarPorId(alterarSenha.Id) ?? throw new Exception("Houve um erro ao tentar localizar o usuário, falha ao atualizar senha");

            if (!usuarioDb.SenhaValida(alterarSenha.SenhaAtual)) throw new Exception("A senha não é valida");

            if (usuarioDb.SenhaValida(alterarSenha.NovaSenha)) throw new Exception("A nova senha deve ser diferente da atual");

            usuarioDb.SetNovaSenha(alterarSenha.NovaSenha);
            usuarioDb.AtualizadoEm = DateTime.Now;
            _databaseContext.SaveChanges();

            return usuarioDb;
        }

        public bool AtualizarSenha(Usuario usuario)
        {
            Usuario usuarioNoBanco = _databaseContext.Usuarios.FirstOrDefault(x => x.Id == usuario.Id);

            if (usuarioNoBanco is null) return false;

            usuarioNoBanco.Senha = usuario.Senha;

            _databaseContext.SaveChanges();

            return true;
        }
    }
}

