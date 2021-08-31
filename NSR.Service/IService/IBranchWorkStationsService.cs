using NSR.Data.Entities;

namespace NSR.Service.IService
{
    public interface IBranchWorkStationsService
    {
        bool ValidateBranchWorkStations(BranchWorkStations branchWorkStations);
        void AddBranchWorkStations(BranchWorkStations branchWorkStations);
        void UpdateBranchWorkStations(BranchWorkStations branchWorkStations);
        int ValidateNameAlreadyExist(BranchWorkStations branchWorkStations);
        string GetWorkStations();

    }
}
