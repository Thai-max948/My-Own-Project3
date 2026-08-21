using RepFlow.Application;
using RepFlow.Domain;
using Xunit;

namespace RepFlow.Application.Tests;

public sealed class ArchitectureSmokeTests
{
    [Fact]
    public void ApplicationAndDomainAssembliesAreAvailable()
    {
        Assert.NotNull(typeof(ApplicationAssemblyMarker).Assembly);
        Assert.NotNull(typeof(DomainAssemblyMarker).Assembly);
    }
}
