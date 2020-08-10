#if NETCOREAPP
using Microsoft.AspNetCore.Mvc;

namespace EdFi.Ods.Tests.FakeExtension.Controllers
{
    [ApiController]
    [Route("[FakeExtension/Test]")]
    public class TestController : ControllerBase 
    {
    }
}
#endif
