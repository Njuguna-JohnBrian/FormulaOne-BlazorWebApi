using FormulaOne.Client.Services;
using FormulaOne.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace FormulaOne.Client.Pages;

public partial class DriverDetails

{
    protected string Message = string.Empty;

    protected Driver driver { get; set; } = new Driver();

    [Parameter] public string Id { get; set; }

    [Inject] private IDriverService _driverService { get; set; }

    [Inject] private NavigationManager _navigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrEmpty(Id))
        {
            //add
        }
        else
        {
            //update
            var driverId = Convert.ToInt32(Id);

            var apiDriver = await _driverService.GetDriver(driverId);

            if (apiDriver != null)
                driver = apiDriver;
        }
    }

    private void HandleFailedRequest()
    {
        Message = "Something went wrong. Form Not Submitted";
    }

    private void GoToDrivers()
    {
        _navigationManager.NavigateTo("/drivers");
    }

    private async Task DeleteDriver()
    {
        if (!string.IsNullOrEmpty(Id))
        {
            var driverId = Convert.ToInt32(Id);
            var result = await _driverService.Delete(driverId);
            if (result)
                GoToDrivers();
            else
                Message = "Something went wrong. Driver not deleted";
        }
    }

    private async void HandleValidRequest()
    {
        if (string.IsNullOrEmpty(Id))
        {
            var result = await _driverService.AddDriver(driver);
            if (result != null)
                GoToDrivers();
            else
                Message = "Something went wrong. Driver not added";
        }
        else
        {
            var result = await _driverService.Update(driver);
            if (result)
                GoToDrivers();
            else
                Message = "Something went wrong. Driver not updated";
        }
    }
}