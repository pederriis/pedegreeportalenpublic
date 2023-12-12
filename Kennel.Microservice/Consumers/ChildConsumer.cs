using Kennel.Application.ApplicationServices;
using MassTransit;
using PedigreePortalen.Shared.KennelMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennel.Microservice.Consumers
{
    public static class ChildConsumer
    {
        //public class CreateChildConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ChildCommandsDto.V1.CreateChild>
        //{
        //    private readonly ChildApplicationService _applicationService;

        //    public CreateChildConsumer(ChildApplicationService applicationService)
        //    {
        //        _applicationService = applicationService;
        //    }

        //    public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ChildCommandsDto.V1.CreateChild> context)
        //    {
        //        var data = context.Message;

        //        ChildCommandsDto.V1.CreateChild child = new ChildCommandsDto.V1.CreateChild();

        //        child.ChildId = data.ChildId;
        //        child.AnimalId = data.AnimalId;
        //        child.LitterId = data.LitterId;
        //        child.IsDeleted = data.IsDeleted;

        //        await _applicationService.Handle(child);
        //    }
        //}

        //public class DeleteChildConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ChildCommandsDto.V1.DeleteChild>
        //{
        //    private readonly ChildApplicationService _applicationService;

        //    public DeleteChildConsumer(ChildApplicationService applicationService)
        //    {
        //        _applicationService = applicationService;
        //    }

        //    public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ChildCommandsDto.V1.DeleteChild> context)
        //    {
        //        var data = context.Message;

        //        ChildCommandsDto.V1.DeleteChild child = new ChildCommandsDto.V1.DeleteChild();

        //        child.ChildId = data.ChildId;
        //        child.IsDeleted = data.IsDeleted;

        //        await _applicationService.Handle(child);
        //    }
        //}

        //public class AddChildToLitterConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ChildCommandsDto.V1.AddChildToLitter>
        //{
        //    private readonly ChildApplicationService _applicationService;

        //    public AddChildToLitterConsumer(ChildApplicationService applicationService)
        //    {
        //        _applicationService = applicationService;
        //    }

        //    public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ChildCommandsDto.V1.AddChildToLitter> context)
        //    {
        //        var data = context.Message;

        //        ChildCommandsDto.V1.AddChildToLitter child = new ChildCommandsDto.V1.AddChildToLitter();

        //        child.ChildId = data.ChildId;
        //        child.LitterId = data.LitterId;
                
        //        await _applicationService.Handle(child);
        //    }
        //}
    }
}
