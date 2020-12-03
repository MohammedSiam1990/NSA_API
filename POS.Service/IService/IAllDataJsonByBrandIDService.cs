namespace POS.Service.IService
{
    public interface IAllDataJsonByBrandIDService
    {
        string GetAllDataJsonByBrandID(int BrandID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL);

    }
}
