using AutoMapper;
using bancoAzure.Context;
using bancoAzure.Interfaces;
using bancoAzure.Models;
using Microsoft.EntityFrameworkCore;

namespace bancoAzure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TesteContext _context;
        private readonly IMapper _mapper;

        public UsuarioRepository(TesteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Add(UsuarioCreate usuario)
        {
            await _context.AddAsync(_mapper.Map<Usuario>(usuario));
            
            _context.SaveChanges();
        }

        public async Task Excluir(int id)
        {
            var usuario = await _context.usuarios.FindAsync(id);

            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            _context.usuarios.Remove(usuario);

            _context.SaveChanges();
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            var usuarios = await _context.usuarios.ToListAsync();

            return usuarios;
        }
    }
}
