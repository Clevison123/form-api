using FormAPI.Data;
using FormAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FormAPI.Services
{
    public class FormService
    {
        private readonly AppDbContext _context;

        public FormService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PersonForm>> GetAllAsync()
        {
            return await _context.Forms.ToListAsync();
        }

        public async Task<PersonForm?> GetByIdAsync(int id)
        {
            return await _context.Forms.FindAsync(id);
        }

        public async Task<PersonForm> AddAsync(PersonForm form)
        {
            await _context.Forms.AddAsync(form);
            await _context.SaveChangesAsync();
            return form;
        }


        public async Task<PersonForm?> UpdateAsync(int id, PersonForm form)
        {
            var existing = await _context.Forms.FindAsync(id);
            if (existing == null) return null;

            existing.Name = form.Name;
            existing.Email = form.Email;
            existing.Phone = form.Phone;
            existing.Age = form.Age;
            existing.Gender = form.Gender;
            existing.Address = form.Address;
            existing.Country = form.Country;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAllAsync()
        {
            var allForms = await _context.Forms.ToListAsync();
            if (!allForms.Any()) return false;

            _context.Forms.RemoveRange(allForms);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
