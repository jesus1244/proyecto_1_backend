using Microsoft.EntityFrameworkCore;
using proyecto.Dto.Intput;
using proyecto.Services.DbcontextConnect;

namespace proyecto.Services.operations
{
    public class ProgramasOperations
    {
        private BryamProyectoContext _context;
        public ProgramasOperations(BryamProyectoContext bryamProyectoContext)
        {
            _context = bryamProyectoContext;
        }

        public async Task<List<Programa>> getAll()
        {
            var result = await _context.Programas
                .AsNoTracking()
                   .ToListAsync();
            return result;
        }

        public async Task<Programa> getById(int id)
        {
            var result = await _context.Programas
                .AsNoTracking()
                   .Where(e => e.Id == id)
                   .FirstOrDefaultAsync();

            return result;
        }


        public async Task<Programa> create(ProgramaDto dto)
        {
            var model = new Programa()
            {
                Nombre = dto.Nombre
            };


            await _context.Programas.AddAsync(model);

            await _context.SaveChangesAsync();

            return model;

        }
    }
}
