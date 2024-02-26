﻿using Ardalis.SharedKernel;
using Autofac;
using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.Services;

namespace Clean.Architecture.Core;

/// <summary>
/// An Autofac module that is responsible for wiring up services defined in the Core project.
/// </summary>
public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    

    builder.RegisterType<WriteService>()
      .As<Clean.Architecture.Core.Interfaces.IWriteService<PersonWriteDAO>>().InstancePerLifetimeScope();



  }
}
