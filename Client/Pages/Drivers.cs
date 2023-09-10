using FormulaOne.Client.Services;
using FormulaOne.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace FormulaOne.Client.Pages;

public partial class Drivers
{
    [Inject] private IDriverService driverService { get; set; }

    public IEnumerable<Driver> _drivers { get; set; } = new List<Driver>();

    protected override async Task OnInitializedAsync()
    {
        var apiDrivers = await driverService.All();

        if (apiDrivers != null)
        {
            IEnumerable<Driver> enumerable = apiDrivers as Driver[] ?? apiDrivers.ToArray();
            if (enumerable.Any())
                _drivers = enumerable;
        }
    }
}