using proyecto.Dto.Intput;
using Microsoft.EntityFrameworkCore;
using proyecto.Services.DbcontextConnect;

namespace proyecto.Services.operations
{
    public class ClaseOperations
    {
        private BryamProyectoContext _context;
        public ClaseOperations(BryamProyectoContext bryamProyectoContext)
        {
            _context = bryamProyectoContext;
        }

        public async Task<List<Clase>> getAll()
        {
            var result = await _context.Clases
                .AsNoTracking()
                   .ToListAsync();
            return result;
        }

        public async Task<Clase> getById(int id)
        {
            var result = await _context.Clases
                .AsNoTracking()
                   .Where(e => e.Id == id)
                   .FirstOrDefaultAsync();

            return result;
        }


        public async Task<Clase> create(ClaseDto dto)
        {
            var model = new Clase()
            {
                Nombre = dto.Nombre,
                IdCurso = dto.IdCurso
            };


            await _context.Clases.AddAsync(model);

            await _context.SaveChangesAsync();

            return model;

        }
    }
}
