using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly AppDbContext _context;
        public ContatoRepositorio(AppDbContext context) => _context = context;
        public ContatoModel ListarPorId(int id) => _context.Contatos.FirstOrDefault(x => x.Id == id);

        public List<ContatoModel> BuscarTodos() => _context.Contatos.ToList();

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;

        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorId(contato.Id);
            if (contatoDb == null) throw new Exception("Houve um erro na atualização do contato");
            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _context.Contatos.Update(contatoDb);
            _context.SaveChanges();

            return contatoDb;
        }

        public bool Excluir(int Id)
        {
            ContatoModel contatoDb = ListarPorId(Id);
            if (contatoDb == null) throw new Exception("Houve um erro na exclusão do contato");
            _context.Contatos.Remove(contatoDb);
            _context.SaveChanges();

            return true;
        }
    }
}
