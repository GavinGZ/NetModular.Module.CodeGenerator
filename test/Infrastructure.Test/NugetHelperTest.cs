﻿using Microsoft.Extensions.DependencyInjection;
using NetModular.Lib.Utils.Core.SystemConfig;
using NetModular.Module.CodeGenerator.Infrastructure;
using NetModular.Module.CodeGenerator.Infrastructure.NuGet;
using Xunit;

namespace Infrastructure.Test
{
    public class NugetHelperTest
    {
        private readonly NuGetHelper _nuGetHelper;

        public NugetHelperTest()
        {
            var service = new ServiceCollection();
            service.AddHttpClient();
            service.AddSingleton<SystemConfigModel>();
            service.AddSingleton<CodeGeneratorOptions>();
            service.AddSingleton<NuGetHelper>();
            _nuGetHelper = service.BuildServiceProvider().GetService<NuGetHelper>();
        }

        [Fact]
        public void GetVersionsTest()
        {
            var versions = _nuGetHelper.GetVersions();

            Assert.NotNull(versions.Lib_Auth_Web);
            Assert.NotNull(versions.Lib_Host_Web);
        }
    }
}
