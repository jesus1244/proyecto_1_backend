using proyecto.Dto.Intput;
using proyecto.Services.DbcontextConnect;
using Microsoft.EntityFrameworkCore;

namespace proyecto.Services.operations
{
    public class CursoOperations
    {
        private BryamProyectoContext _context;
        public CursoOperations(BryamProyectoContext bryamProyectoContext)
        {
            _context = bryamProyectoContext;
        }

        public async Task<List<Curso>> getAll()
        {
            var result = await _context.Cursos
                .AsNoTracking()
                   .ToListAsync();
            return result;
        }

        public async Task<Curso> getById(int id)
        {
            var result = await _context.Cursos
                .AsNoTracking()
                   .Where(e => e.Id == id)
                   .FirstOrDefaultAsync();

            return result;
        }


        public async Task<Curso> create(CursoDto dto)
        {
            var model = new Curso()
            {
                Nombre = dto.Nombre,
                IdPrograma = dto.IdPrograma
            };


            await _context.Cursos.AddAsync(model);

            await _context.SaveChangesAsync();

            return model;

        }
    }
}