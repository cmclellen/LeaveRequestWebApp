// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

using CompanyABC.Core.Config;
using CompanyABC.Core.Email;
using CompanyABC.Core.Mappers;
using CompanyABC.WebApi.Mappers;

using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace CompanyABC.WebApi.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ApiControllerConvention());
                });
            For<IApplicationSettings>().Use<SystemApplicationSettings>();
            For<IMapper>().Use<AutoMapperWrapper>();
            For<IEmailSender>().Use<SystemEmailSender>();
        }
    }
}