using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IMeistrijaDefectsData
    {
        Task<List<MeistrijaDefectModel>> FetchDefects();
        Task SetDefectPanaikintas(MeistrijaDefectModel defect);
    }
}