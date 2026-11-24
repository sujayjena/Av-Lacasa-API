using AVLacasa.Application.Models;
using AVLacasa.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLacasa.Application.Interfaces
{
    public interface IMasterDataRepository
    {
        Task<IEnumerable<SelectListResponse>> GetReportingToEmployeeForSelectList(ReportingToEmpListParameters parameters);
        Task<IEnumerable<EmployeesListByReportingTo_Response>> GetEmployeesListByReportingTo(int EmployeeId);
    }
}
