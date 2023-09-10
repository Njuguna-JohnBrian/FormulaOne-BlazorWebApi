using FormulaOne.Client.Pages;
using FormulaOne.Shared.Models;

namespace FormulaOne.Client.Services;

public interface IDriverService
{
    Task<IEnumerable<Driver>?> All();
    
    Task<Driver?> GetDriver(int id);
    
    Task<bool?> AddDriver(Driver driver);
    
    Task<bool> Update(Driver driver);
    
    Task<bool> Delete(int id);
}