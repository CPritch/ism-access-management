using AccessManager.Data;
using AccessManager.Components.Pages;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using AccessManager.Hubs;
using Microsoft.AspNetCore.SignalR;
using MudBlazor;

namespace AccessManager.Tests.Components.Pages
{
    public class DoorManagementTests
    {
        [Fact]
        public void DoorManagement_RendersDoorsCorrectly()
        {
            using TestContext ctx = new TestContext();

            var doorRepositoryMock = Substitute.For<IDoorRepository>();
            doorRepositoryMock.GetAllDoors().Returns(new List<Door>
            {
                new Door(1, "Front Door"),
                new Door(2, "Back Door", isOpen: true, isLocked: false)
            });
            var hubContextMock = Substitute.For<IHubContext<DoorStatusHub>>();
            var popoverServiceMock = Substitute.For<MudPopoverProvider>();
            var jsApiServiceMock = Substitute.For<IJsApiService>();
            ctx.Services.AddSingleton(doorRepositoryMock);
            ctx.Services.AddSingleton(hubContextMock);
            ctx.Services.AddSingleton(jsApiServiceMock);
            ctx.Services.AddScoped(sp => popoverServiceMock);

            var cut = ctx.RenderComponent<DoorManagement>();

            var mudCards = cut.FindAll("div.mud-card");
            Assert.Equal(2, mudCards.Count);
        }
    }
}
