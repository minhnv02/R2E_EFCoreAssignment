using Rookies_EFCoreAssignment.Domain.Entities;
using Rookies_EFCoreAssignment.Domain.Interfaces;
using System.Linq.Expressions;

namespace Rookies_EFCoreAssignment.Application.Services.ImPl
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _salaryRepository;

        public SalaryService(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        public async Task<IEnumerable<Salary>> GetSalaries()
        {
            return await _salaryRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Salary>> GetSalaries(params Expression<Func<Salary, object>>[] includeProperties)
        {
            return await _salaryRepository.GetAllAsync(null, includeProperties);
        }

        public async Task<Salary> GetSalary(long id)
        {
            return await _salaryRepository.GetAsync(x => x.Id == id);
        }

        public async Task<Salary> GetSalary(long id, params Expression<Func<Salary, object>>[] includeProperties)
        {
            return await _salaryRepository.GetAsync(x => x.Id == id, includeProperties);
        }

        public async Task<Salary> GetSalary(Func<Salary, bool> expression, params Expression<Func<Salary, object>>[] includeProperties)
        {
            return await _salaryRepository.GetAsync(expression, includeProperties);
        }

        public async Task<bool> CreateSalary(Salary salary)
        {
            if (salary == null)
                return false;
            await _salaryRepository.AddAsync(salary);
            var isSuccess = await _salaryRepository.SaveChangeAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> UpdateSalary(Salary salary)
        {
            if (salary == null)
                return false;
            var salaryExisted = await _salaryRepository.GetAsync(x => x.Id == salary.Id);
            if (salaryExisted == null)
                return false;

            salaryExisted.Amount = salary.Amount;

            _salaryRepository.Update(salary);
            var isSuccess = await _salaryRepository.SaveChangeAsync() > 0;
            return isSuccess;
        }

        public async Task<bool> DeleteSalary(long id)
        {
            var salary = await _salaryRepository.GetAsync(x => x.Id == id);
            if (salary == null)
                return false;
            _salaryRepository.Delete(salary);
            var isSuccess = await _salaryRepository.SaveChangeAsync() > 0;
            return isSuccess;
        }
    }
}
