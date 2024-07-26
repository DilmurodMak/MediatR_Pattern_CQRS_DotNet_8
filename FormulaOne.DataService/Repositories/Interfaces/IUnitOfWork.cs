namespace FormulaOne.DataService.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAchieveRepository Achievements { get; }
        IDriverRepository Drivers { get; }
        Task<bool> CompleteAsync();
    }
}